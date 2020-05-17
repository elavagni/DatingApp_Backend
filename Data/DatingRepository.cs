using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Helpers;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Like> GetLike(int userId, int recipientId)
        {
            return await _context.Likes.FirstOrDefaultAsync(u => u.LikerId == userId && u.LikeeId == recipientId);
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMainPhoto);
        }

        public async Task<Photo> GetPhoto(int Id)
        {
            var photo = await _context.Photos.IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == Id);
            return photo;
        }

        public async Task<User> GetUser(int Id, bool isRequestorLoggedUser)
        {
            var query = _context.Users.AsQueryable();

            if (isRequestorLoggedUser) 
                await query.IgnoreQueryFilters().ToListAsync();
            
            var user = await query.FirstOrDefaultAsync(u => u.Id == Id);

            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.OrderByDescending(u => u.LastActive).AsQueryable();

            users = users.Where(u => u.Id != userParams.UserId);

            users = users.Where(u => u.Gender == userParams.Gender);

            if (userParams.LikesReceived)
            {
                //Get the likes the user has received
                var userLikerIds = await GetUserIdsByLikeType(userParams.UserId, true);
                //Get the users that have liked the current user
                users = users.Where(u => userLikerIds.Contains(u.Id));
            }
            if (userParams.LikesGiven)
            {
                //Get the likes the user has given
                var userLikeeIds = await GetUserIdsByLikeType(userParams.UserId, false);
                //Get the users that the current user has liked
                users = users.Where(u => userLikeeIds.Contains(u.Id));
            }

            if (userParams.MinAge != 18 || userParams.MaxAge != 99)
            {
                users = users.Where(u => u.DateOfBirthDay.CalculateAge() >= userParams.MinAge
                && u.DateOfBirthDay.CalculateAge() <= userParams.MaxAge);
            }

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch (userParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(u => u.Created);
                        break;
                    default:
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }

            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        private async Task<IEnumerable<int>> GetUserIdsByLikeType(int id, bool likesReceived)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (likesReceived)
            {
                return user.LikesReceived.Select(x=> x.LikerId);
            }
            else
            {
                return user.LikesGiven.Select(x=> x.LikeeId);
            }
        }

        public async Task<bool> SaveAll()
        {
            int result =  await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Message> GetMessage(int messageId)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == messageId);
        }
        public async Task<PagedList<Message>> GetMessagesForUser(MessageParams messageParams)
        {
            var messages = _context.Messages.AsQueryable();

            switch (messageParams.MessageContainer)
            {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.RecipientDeleted == false);
                    break;
                case "Outbox":
                    messages = messages.Where(u => u.SenderId == messageParams.UserId && u.SenderDeleted == false);
                    break;
                default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId &&
                                              u.RecipientDeleted==false && u.IsRead == false);
                    break;
            }

            messages = messages.OrderByDescending(d => d.MessageSent);
            return await PagedList<Message>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<Message>> GetMessageThread(int userId, int recipientId)
        {
             var messages = await _context.Messages               
                .Where(m => (m.RecipientId == userId && m.RecipientDeleted == false && m.SenderId == recipientId ) 
                   || (m.RecipientId == recipientId && m.SenderId == userId && m.SenderDeleted == false))
                .OrderByDescending(m => m.MessageSent)
                .ToListAsync();

                return messages;
        }
    }
}
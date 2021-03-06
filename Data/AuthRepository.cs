using System;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _context.Users.Include(p=> p.Photos).FirstOrDefaultAsync(x => x.UserName == userName);

            if(user == null)
            {
                return null;
            }
            //Since we are using Identity now, we are not going to be validating passwords anymore
            // if(!VerifyPasswordHash(password,user.PasswordHash, user.PasswordSalt))
            //     return null;

            //Auth succesfull
            return user;    
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i =0; i< computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, paswordSalt;            
            CreatePasswordHash(password,out passwordHash,out paswordSalt);

            // user.PasswordHash = passwordHash;
            // user.PasswordSalt = paswordSalt;

            await _context.Users.AddAsync(user); 
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] paswordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()            )
            {
                paswordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string userName)
        {
            if(await _context.Users.AnyAsync(x=> x.UserName == userName))
                return true;
            return false;

        }
    }
}
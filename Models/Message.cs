using System;

namespace DatingApp.API.Models
{
    public class Message
    {
        public int Id { set; get; }
        public int SenderId { set; get; }
        public User Sender { set; get; }
        public int RecipientId { set; get; }
        public User Recipient { set; get; }
        public string Content { set; get; }
        public bool IsRead { set; get; }
        public DateTime? DateRead { set; get; }
        public DateTime MessageSent { set; get; }
        public Boolean SenderDeleted { set; get; }
        public Boolean RecipientDeleted { set; get; }
    }
}
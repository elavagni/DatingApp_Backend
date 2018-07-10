using System;

namespace DatingApp.API.DTOs
{
    public class MessageForCreationDto
    {
        public int SenderId { set; get; }
        public int RecipientId { set; get; }
        public DateTime MessageSent { set; get; }
        public string Content { set; get; }

        public MessageForCreationDto()
        {
            MessageSent = DateTime.Now;
        }
    }
}
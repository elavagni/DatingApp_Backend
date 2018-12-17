using System;

namespace DatingApp.API.DTOs
{
    public class MessageToReturnDto
    {
        public int Id { set; get; }
        public int SenderId { set; get; }
        public string SenderKnownAs { set; get; }
        public string SenderPhotoUrl { set; get; }
        public int RecipientId { set; get; }
        public string RecipientKnownAs { set; get; }
        public string RecipienPhotoUrl { set; get; }
        public string Content { set; get; }
        public bool isRead { set; get; }
        public DateTime? DateRead { set; get; }
        public DateTime MessageSent { set; get; }
    }
}

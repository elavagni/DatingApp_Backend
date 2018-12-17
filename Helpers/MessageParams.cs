namespace DatingApp.API.Helpers
{
    public class MessageParams
    {
        private const int MaxPageSize  = 50;
        public int PageNumber {set;get;}
       
        private int pageSize =10;

        public int PageSize
        {
            get { return pageSize; }
            set {pageSize = (value > MaxPageSize) ? MaxPageSize : value;}
        }

        public int UserId {set;get;}
        public string MessageContainer {set;get;} = "Unread";
    }
}
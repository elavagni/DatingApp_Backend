namespace DatingApp.API.Helpers
{
    public class UserParams
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
        public string Gender {set;get;}
        public int MinAge {set;get;} = 18;
        public int MaxAge {set;get;} = 99;
        public string OrderBy {set;get;}
    }
}
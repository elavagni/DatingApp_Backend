namespace DatingApp.API.Models
{
    public class Like
    {
        public int LikerId {set;get;}
        public int LikeeId {set;get;}
        //User giving the like
        public virtual User Liker {set;get;}
        //User receiving the like
        public virtual User Likee {set;get;}
    }
}
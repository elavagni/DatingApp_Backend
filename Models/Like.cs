namespace DatingApp.API.Models
{
    public class Like
    {
        public int LikerId {set;get;}
        public int LikeeId {set;get;}
        //User giving the like
        public User Liker {set;get;}
        //User receiving the like
        public User Likee {set;get;}
    }
}
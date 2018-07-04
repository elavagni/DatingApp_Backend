namespace DatingApp.API.Helpers
{
    public class PaginationHeader
    {
        public int CurrentPage {set;get;}
        public int ItemsPerPage {set;get;}
        public int TotalItems {set;get;}
        public int TotalPages {set;get;}

        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        } 
    }
}
namespace FinanceKnowHow.ViewModels
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Items { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public PaginatedList(IEnumerable<T> items, int count, int currentPage, int pageSize)
        {
            Items = items;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count/(double)pageSize);
        }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
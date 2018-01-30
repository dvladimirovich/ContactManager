namespace ContactManager.WEB.Modules
{
    public class Options
    {
        private int    pageIndex;
        private int    pageSize;
        private string sortDirection;
        private string sortBy;
        private string filterBy;
        private string searchBy;

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public string SortDirection
        {
            get { return sortDirection; }
            set { sortDirection = value; }
        }

        public string SortBy
        {
            get { return sortBy; }
            set { sortBy = value; }
        }

        public string FilterBy
        {
            get { return filterBy; }
            set { filterBy = value; }
        }

        public string SearchBy
        {
            get { return searchBy; }
            set { searchBy = value; }
        }

        public Options(int pageIndex, int pageSize, string sortDirection, string sortBy, string filterBy, string searchBy)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            SortDirection = sortDirection;
            SortBy = sortBy;
            FilterBy = filterBy;
            SearchBy = searchBy;
        }
    }
}

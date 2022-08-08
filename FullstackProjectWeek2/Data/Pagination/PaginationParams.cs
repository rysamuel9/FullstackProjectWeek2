﻿namespace FullstackProjectWeek2.Data.DAL.Pagination
{
    public class PaginationParams
    {
        private const int _maxItemPerPage = 50;
        private int itemsPerPage;

        public int Page { get; set; }
        public int ItemsPerPage
        {
            get => itemsPerPage;
            set => itemsPerPage = value > _maxItemPerPage ? _maxItemPerPage : value;
        }
    }
}

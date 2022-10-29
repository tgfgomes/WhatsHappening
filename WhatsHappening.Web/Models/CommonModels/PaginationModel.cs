using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace WhatsHappening.Web.Models.CommonModels
{
    public class PaginationModel
    {
        private const int DefaultPageSize = 10;

        private int _pageSize = DefaultPageSize;
        private int? _currentPage = null;
        private int? _totalPages = null;

        private int _startPage = 0;
        private int _endPage = 0;

        private readonly RouteValueDictionary _queryParams = new RouteValueDictionary();


        public string Action { get; set; }
        public string Controller { get; set; }
        public RouteValueDictionary QueryParams { get { return _queryParams; } }


        private void CalculateStartPageAndEndPage()
        {
            int sp = Math.Max(1, CurrentPage - (10 / 2));
            int ep = Math.Min(TotalPages, CurrentPage + (10 / 2));
            _startPage = ep - sp == 9 ? sp : Math.Max(1, ep - 10);
            _endPage = Math.Min(TotalPages, _startPage + 9);
        }

        public int StartPage
        {
            get
            {
                CalculateStartPageAndEndPage();
                return _startPage;
            }
        }

        public int EndPage
        {
            get
            {
                CalculateStartPageAndEndPage();
                return _endPage;
            }
        }


        public int TotalPages
        {
            get { return _totalPages.HasValue && _totalPages > 0 ? _totalPages.Value : 1; }
        }

        public int CurrentPage
        {
            get { return _currentPage.HasValue && _currentPage > 0 ? _currentPage.Value : 1; }
            set { SetCurrentPage(value); }
        }

        public int PageSize
        {
            get { return _pageSize > 0 ? _pageSize : DefaultPageSize; }
            set
            {
                _pageSize = value;
                CalculateAndSetTotalPages(0, true);
            }
        }

        public void CalculateAndSetTotalPages(int count, bool resetCurrentPage = false)
        {
            _totalPages = (count + PageSize - 1) / PageSize;
            if (resetCurrentPage)
                CurrentPage = 1;
        }

        public void SetCurrentPage(int page)
        {
            if (!_totalPages.HasValue)
                throw new Exception("Set TotalPages first");
            if (page > _totalPages && _totalPages > 0)
                _currentPage = _totalPages.Value;
            else if (page <= 1)
                _currentPage = 1;
            else
                _currentPage = page;
            if (_currentPage <= 0)
                _currentPage = 1;
        }



    }
}
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using KitundaChurch.Models;
using MoreLinq;

namespace ReflectionIT.Mvc.Paging
{

    public class PaginList<T> : List<T>, IPagingList where T : class
    {
        private int _pageSize;
        public Model modelin { get; set; }

        public int PageIndex { get; }
        public int PageCount { get; }
        public string Action { get; set; }
        
        public string SortExpression { get; }

        public string DefaultSortExpression { get; }

        public static  PaginList<T> Create(IOrderedQueryable<T> qry, int pageSize, int pageIndex, Model modelin,string sortExpression, string defaultSortExpression)
        {
            var pageCount = (int)Math.Ceiling( qry.Count() / (double)pageSize);

            return new PaginList<T>( qry.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                                        pageSize, pageIndex, pageCount);
        }

        public static PaginList<T> CreateAsync(IQueryable<T> qry, int pageSize, int pageIndex, string sortExpression, string defaultSortExpression)
        {

            

            return new PaginList<T>(qry.OrderBy(sortExpression).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                                     pageSize, pageIndex, (int)Math.Ceiling(qry.Count() / (double)pageSize));
        }

        private PaginList(List<T> list, int pageSize, int pageIndex, int pageCount)
            : base(list)
        {
            this.PageIndex = pageIndex;
            this.PageCount = pageCount;
            //  this.Action = "Index"; // please note this line code 
            this.Action = "SummaryAsync";
        }

        private PaginList(List<T> list, int pageSize, int pageIndex, int pageCount, string sortExpression, string defaultSortExpression)
            : this(list, pageSize, pageIndex, pageCount)
        {

            this.SortExpression = sortExpression;
            this.DefaultSortExpression = defaultSortExpression;
        }

        public PaginList(IEnumerable<T> collection, int pageSize, int pageIndex) : base(collection)
        {
            this._pageSize = pageSize;
            PageIndex = pageIndex;
           
            
        }

        public RouteValueDictionary RouteValue { get; set; }

        public RouteValueDictionary GetRouteValueForPage(int pageIndex)
        {

            RouteValueDictionary dict =
                this.RouteValue == null ? new RouteValueDictionary() :
                new RouteValueDictionary(this.RouteValue);

            dict["page"] = pageIndex;

            if (this.SortExpression != this.DefaultSortExpression)
            {
                dict["sortExpression"] = this.SortExpression;
            }

            return dict;
        }

        public RouteValueDictionary GetRouteValueForSort(string sortExpression)
        {

            RouteValueDictionary dict =
                this.RouteValue == null ? new RouteValueDictionary() :
                new RouteValueDictionary(this.RouteValue);

            if (sortExpression == this.SortExpression)
            {
                sortExpression = "-" + sortExpression;
            }

            dict["sortExpression"] = sortExpression;

            return dict;
        }

        public int NumberOfPagesToShow { get; set; } = PagingOptions.Current.DefaultNumberOfPagesToShow;

        public int StartPageIndex
        {
            get
            {
                int half = (int)((NumberOfPagesToShow - 0.5) / 2);
                var start = Math.Max(1, this.PageIndex - half);
                if (start + NumberOfPagesToShow - 1 > this.PageCount)
                {
                    start = this.PageCount - NumberOfPagesToShow + 1;
                }
                return Math.Max(1, start);
            }
        }

        public int StopPageIndex
        {
            get
            {
                return Math.Min(this.PageCount, StartPageIndex + NumberOfPagesToShow - 1);
            }
        }

        public int TotalRecordCount => throw new NotImplementedException();

        internal static object CreateAsync(List<Matoleo> listed, int pageSize, int page, Matoleo matoleo, string sortExpression, string v)
        {
            throw new NotImplementedException();
        }
    }
}
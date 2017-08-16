﻿using System.Collections.Generic;

namespace Foundation.Domain.Retrievers
{
    public class PagedResults<T>
    {
        /// <summary>
        /// The page number this page represents.
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// The size of this page.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// The total number of pages available.
        /// </summary>
        public int PagesCount { get; set; }

        /// <summary>
        /// The total number of records available.
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// The records this page represents.
        /// </summary>
        public IEnumerable<T> Results { get; set; }
    }
}

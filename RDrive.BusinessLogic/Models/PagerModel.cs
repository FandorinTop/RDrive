﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.BusinessLogic.Models
{
    public class PagerModel
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int PagesCount
        {
            get
            {
                int result = 0;
                if (PageSize > 0 && TotalCount > 0)
                {
                    result = (int)Math.Ceiling(TotalCount / (double)PageSize);
                }
                return result;
            }
        }
    }
}

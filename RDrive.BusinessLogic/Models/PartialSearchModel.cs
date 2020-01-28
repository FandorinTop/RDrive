using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.BusinessLogic.Models
{
    class PartialSearchModel : PagerModel
    {
        public string SearchQuery { get; set; }

        public string Title { get; set; }
    }
}

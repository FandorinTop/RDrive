using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.ViewModels.PagingViewModels
{
    public class PartialSearchViewModel : PagerViewModel
    {
            public string SearchQuery { get; set; }
            public string Title { get; set; }
    }
}


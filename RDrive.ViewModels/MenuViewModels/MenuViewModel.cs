using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.ViewModels.MenuViewModels
{
    public class MenuViewModel
    {
        public List<MenuViewModelItem> Items { get; set; }

        public MenuViewModel()
        {
            Items = new List<MenuViewModelItem>();
        }
    }

    public class MenuViewModelItem
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Title { get; set; }
    }
}

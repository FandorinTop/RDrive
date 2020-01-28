using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.ViewModels.AdminViewModels.DriverViewModel
{
    public class ShowDriversAdminView
    {
        public List<ShowDriversAdminViewItem> Drivers { get; set; }

        public ShowDriversAdminView()
        {
            Drivers = new List<ShowDriversAdminViewItem>();
        }
    }

    public class ShowDriversAdminViewItem
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
    }
}

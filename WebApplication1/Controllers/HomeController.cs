using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDrive.BusinessLogic.Fabrics.Interface;
using RDrive.BusinessLogic.Services.Interfaces;
using RDrive.Shared.Constants;
using RDrive.Shared.Exceptions.BaseExceptions;
using RDrive.ViewModels.AdminViewModels.DriverViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Base = WebApplication1.Controllers.BaseController.BaseController;

namespace WebApplication1.Controllers
{
    public class HomeController : Base
    {
        #region Constructors
        public HomeController(IMenuItemsFabric menuItemsFabric) : base(menuItemsFabric)
        {
        }
        #endregion

        public IActionResult Index()
        {
            if (UserRoles.Contains("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }

            return View("Login");
        }

        public IActionResult Landing()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

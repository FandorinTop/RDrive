using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDrive.BusinessLogic.Fabrics.Interface;
using RDrive.BusinessLogic.Services.Interfaces;
using RDrive.Shared.Constants;
using RDrive.Shared.Exceptions.BaseExceptions;
using RDrive.ViewModels.AdminViewModels.DriverViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = AppConstants.SUPER_ADMIN_ROLE)]
    public class AdminController : BaseController.BaseController
    {
        private IAdminService _adminService;

        public AdminController(IAdminService adminService, IMenuItemsFabric menuItemsFabric) : base(menuItemsFabric)
        {
            _adminService = adminService;
        }
        //HOMEPAGE
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

         
        [HttpGet]
        public async Task<IActionResult> ShowDrivers()
        {
            ShowDriversAdminView result = await _adminService.ShowDrivers();

            return View(viewName: "Teachers/Teachers", result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDrivers(CreateNewDriverAdminView viewModel)
        {
            try
            {
                await _adminService.CreateDriver(viewModel);

                return RedirectToAction("ShowTeachers");
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                return View(viewName: "Teachers/RegisterNewTeacher");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditDriversAccount(string userName)
        {
            EditDriverAdminViewModel result = await _adminService.LoadDataForEditDriverAccount(userName);

            return View(viewName: "Drivers/EditDriverAccount", result);
        }

        [HttpPost]
        public async Task<IActionResult> EditDriverInformation(EditDriverAdminViewModel viewModel)
        {
            try
            {
                await _adminService.EditDriverInformation(viewModel);

                return await EditDriversAccount(viewModel.Username);
            }
            catch (BaseException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                var result = await _adminService.LoadDataForEditDriverAccount(viewModel.Username);

                return View(viewName: "Drivers/EditDriverAccount", result);
            }

        }
        
    }

}

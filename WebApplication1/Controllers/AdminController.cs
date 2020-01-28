using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RDrive.BusinessLogic.Fabrics.Interface;
using RDrive.BusinessLogic.Services.Interfaces;
using RDrive.DataAccess.Repositories;
using RDrive.Shared.Constants;
using RDrive.Shared.Exceptions.BaseExceptions;
using RDrive.Shared.Exceptions.BusinessLogicExceptions;
using RDrive.ViewModels.AdminViewModels.DriverViewModel;
using RDrive.ViewModels.AdminViewModels.DriverViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApplication1.Controllers
{
    [Authorize(Roles = AppConstants.ADMIN_ROLE)]
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

            return View(viewName: "Drivers/Drivers", result);
        }
        [HttpGet]
        public async Task<IActionResult> RegisterDriver()
        {
            CreateNewDriverAdminView result = await _adminService.LoadDataForRegisterDriverPage();
            return View(viewName: "Drivers/RegisterDriver", result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDriver([FromForm]CreateNewDriverAdminView viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _adminService.CreateDriver(viewModel);
                    return RedirectToAction("ShowDrivers");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                    return View(viewName: "Drivers/RegisterDriver");
                }
            }
            
             return View(viewName: "Drivers/RegisterDriver");
        }
        
        public async Task<IActionResult> EditDriver(int id)
        {
            EditDriverAdminViewModel result = await _adminService.LoadDataForEditDriverAccount(id);

            return View(viewName: "Drivers/EditDriver", result);
        }

        [HttpPost]
        public async Task<IActionResult> EditDriverInformation(EditDriverAdminViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _adminService.EditDriverInformation(viewModel);
                    return RedirectToAction("ShowDrivers");

                    return await EditDriver(viewModel.Id);
                }
                catch (BaseException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                    var result = await _adminService.LoadDataForEditDriverAccount(viewModel.Id);

                    return View(viewName: "Drivers/EditDriver", result);
                }
            }
            return View(viewName: "Drivers/EditDriver", await _adminService.LoadDataForEditDriverAccount(viewModel.Id));

        }
       
        [HttpPost]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            try
            {
                await _adminService.DeleteDriver(id);
                return RedirectToAction("ShowDrivers");
                return new JsonResult(new OkResult());
            }
            catch (AdminException)
            {
                return RedirectToAction("ShowDrivers");
            }
        }

    }

}

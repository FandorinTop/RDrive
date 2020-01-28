using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RDrive.BusinessLogic;
using RDrive.BusinessLogic.Extention;
using RDrive.BusinessLogic.Helpers;
using RDrive.BusinessLogic.Mappers.Interfaces;
using RDrive.BusinessLogic.Providers.Interfaces;
using RDrive.BusinessLogic.Services.Interfaces;
using RDrive.DataAccess.Interfaces;
using RDrive.Entities.Entities;
using RDrive.Entities;
using RDrive.Shared.Constants;
using RDrive.Shared.Exceptions.BusinessLogicExceptions;
using RDrive.ViewModels.AdminViewModels.DriverViewModel;
using RDrive.ViewModels.AccountViewModels;
using RDrive.BusinessLogic.Helpers.Interfaces;

namespace RDrive.BusinessLogic.Services
{
    // TO DO 
    public class AdminService : IAdminService
    {
        #region Properties
        private IDriverRepository _driverRepository;

        private IAccountMapper _accountMapper;
        private IDriverMapper _driverMapper;

        private IDateParseHelper _dateParseHelper;

        private IEmailProvider _emailProvider;

        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        #endregion

        #region Constructors
        public AdminService(
            IDriverRepository driverRepository,
            IDriverMapper driverMapper,
            IAccountMapper accountMapper,
            IDateParseHelper dateParseHelper,
            IEmailProvider emailProvider,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _driverRepository = driverRepository;

            _driverMapper = driverMapper;
            _accountMapper = accountMapper;

            _dateParseHelper = dateParseHelper;

            _emailProvider = emailProvider;

            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Drivers
        public async Task<ShowDriversAdminView> ShowDrivers()
        {
            List<Driver> drivers = await _driverRepository.GetAllDrivers();

            ShowDriversAdminView result = _driverMapper.MapDriverModelsToViewModels(drivers);


            return result;
        }

        public async Task<CreateNewDriverAdminView> LoadDataForRegisterDriverPage()
        {
            var result =  new CreateNewDriverAdminView();

            return result;
        }

        public async Task CreateDriver(CreateNewDriverAdminView viewModel)
        {
           

            var driver = new Driver();

            driver.Email = viewModel.Email;
            driver.UserName = viewModel.Username;

            if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
            {
                throw new AdminException("Passwords are different");
            }

            if (!(await _userManager.FindByEmailAsync(viewModel.Email) is null) || !(await _userManager.FindByNameAsync(viewModel.Username) is null))
            {
                throw new AdminException("Account with such Email or UserID already exists");
            }

            driver.BirthDate = _dateParseHelper.ParseStringToDatetime(viewModel.BirthDate);

            _accountMapper.MapDriverViewModelToModel(viewModel, driver);
            /// TODOOOOOOOOOOO
            driver.EmailConfirmed = true;
            ///
            IdentityResult result = await _userManager.CreateAsync(driver, viewModel.Password);

            if (!result.Succeeded)
            {
                string responseError = result.GetFirstError();

                throw new AdminException(responseError);
            }

            AppUser registeredDriver = await _userManager.FindByNameAsync(viewModel.Username);

            await _userManager.AddToRoleAsync(registeredDriver, AppConstants.DRIVER_ROLE);
        }

        public async Task<EditDriverAdminViewModel> LoadDataForEditDriverAccount(string userName)
        {
            Driver driver = await _driverRepository.GetDriverByName(userName);

            if (driver is null)
            {
                throw new AdminException("User not found");
            }


            EditDriverAdminViewModel viewModel = _driverMapper.MapEditDriverModelsToEditViewModels(driver);

            return viewModel;
        }

        public async Task EditDriverInformation(EditDriverAdminViewModel viewModel)
        {
            var user = await _userManager.FindByNameAsync(viewModel.Username) as Driver;

            if (user is null)
            {
                throw new AdminException("User not found.");
            }

            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.MiddleName = viewModel.MiddleName;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.BirthDate = _dateParseHelper.ParseStringToOnlyYearDatetime(viewModel.BirthDate).Value;

            user.AddressLine = viewModel.AddressLine;

            await _userManager.UpdateAsync(user);
        }

        #endregion
    }
}

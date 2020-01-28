using System.Collections.Generic;
using System.Linq;
using RDrive.BusinessLogic.Mappers.Interfaces;
using RDrive.Entities.Entities;
using RDrive.ViewModels.AdminViewModels.DriverViewModel;

namespace RDrive.BusinessLogic.Mappers
{
    public class DriverMapper : IDriverMapper
    {
        public ShowDriversAdminView MapDriverModelsToViewModels(List<Driver> model)
        {
            var viewModel = new ShowDriversAdminView();

            foreach (Driver driver in model)
            {
                var viewModelItem = new ShowDriversAdminViewItem();
                viewModelItem.UserName = driver.UserName;
                viewModelItem.FullName = $"{driver.LastName} {driver.FirstName} {driver.MiddleName}";

                viewModel.Drivers.Add(viewModelItem);
            }

            return viewModel;
        }

        public EditDriverAdminViewModel MapEditDriverModelsToEditViewModels(Driver driver)
        {

            var viewModel = new EditDriverAdminViewModel();

            viewModel.Id = driver.Id;
            viewModel.FirstName = driver.FirstName;
            viewModel.LastName = driver.LastName;
            viewModel.MiddleName = driver.MiddleName;
            viewModel.PhoneNumber = driver.PhoneNumber;
            viewModel.BirthDate = driver.BirthDate.ToString("yyyy");
            viewModel.Username = driver.UserName;
            viewModel.Email = driver.Email;
            viewModel.AddressLine = driver.AddressLine;
            viewModel.IsVerified = driver.IsVerified;

            return viewModel;
        }
    }
}

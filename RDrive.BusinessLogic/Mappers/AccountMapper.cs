using RDrive.BusinessLogic.Mappers.Interfaces;
using RDrive.Entities.Entities;
using RDrive.ViewModels.AccountViewModels;
using RDrive.ViewModels.AdminViewModels.DriverViewModel;

namespace RDrive.BusinessLogic.Mappers
{
    public class AccountMapper : IAccountMapper
    {
        public void MapFinishRegistrationAndConfirmAccountToApplicationUser(FinishRegistrationAndConfirmAccountAccountView viewModel, Client model)
        {
            model.FirstName = viewModel.FirstName;
            model.LastName = viewModel.LastName;
            model.MiddleName = viewModel.MiddleName;
            model.BirthDate = viewModel.BirthDate;
            model.PhoneNumber = viewModel.PhoneNumber;
            model.AddressLine = viewModel.AddressLine;
            
        }

        public void MapDriverViewModelToModel(CreateNewDriverAdminView viewModel, Driver model)
        {
            model.FirstName = viewModel.FirstName;
            model.LastName = viewModel.LastName;
            model.MiddleName = viewModel.MiddleName;
            model.PhoneNumber = viewModel.PhoneNumber;
            model.AddressLine = viewModel.AddressLine;
            model.IsVerified = viewModel.IsVerified;
        }
    }
}

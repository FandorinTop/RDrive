using RDrive.Entities.Entities;
using RDrive.ViewModels.AccountViewModels;
using RDrive.ViewModels.AdminViewModels.DriverViewModel;

namespace RDrive.BusinessLogic.Mappers.Interfaces
{
    public interface IAccountMapper
    {
        void MapFinishRegistrationAndConfirmAccountToApplicationUser(FinishRegistrationAndConfirmAccountAccountView mapFrom, Client mapTo);
        void MapDriverViewModelToModel(CreateNewDriverAdminView viewModel, Driver model);
    }
}

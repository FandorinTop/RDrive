using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using RDrive.ViewModels.AdminViewModels;
using RDrive.ViewModels.AdminViewModels.DriverViewModel;


namespace RDrive.BusinessLogic.Services.Interfaces
{
    public interface IAdminService
    {
        #region Drivers
        Task<ShowDriversAdminView> ShowDrivers();
        Task CreateDriver(CreateNewDriverAdminView viewModel);
        Task<EditDriverAdminViewModel> LoadDataForEditDriverAccount(string userName);
        Task EditDriverInformation(EditDriverAdminViewModel viewModel);
        Task<CreateNewDriverAdminView> LoadDataForRegisterDriverPage();
        #endregion
    }
}

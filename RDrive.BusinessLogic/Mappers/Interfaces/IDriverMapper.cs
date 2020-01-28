using System.Collections.Generic;
using RDrive.Entities.Entities;
using RDrive.ViewModels.AdminViewModels.DriverViewModel;

namespace RDrive.BusinessLogic.Mappers.Interfaces
{
    public interface IDriverMapper
    {
        ShowDriversAdminView MapDriverModelsToViewModels(List<Driver> drivers);
        EditDriverAdminViewModel MapEditDriverModelsToEditViewModels(Driver driver);
    }
}

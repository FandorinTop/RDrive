
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using RDrive.BusinessLogic.Fabrics.Interface;
using RDrive.Shared.Constants;
using RDrive.ViewModels.MenuViewModels;

namespace RDrive.BusinessLogic.Fabrics
{
    public class MenuItemsFabric : IMenuItemsFabric
    {
        #region Properties & variables
        private IHttpContextAccessor _httpContextAccessor;
        protected List<string> UserRoles => _httpContextAccessor.HttpContext.User.Claims
            .Where(item => item.Type == ClaimTypes.Role)?
            .Select(item => item.Value).ToList();
        #endregion

        #region Constructors
        public MenuItemsFabric(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Public Methods
        public MenuViewModel BuildMenu()
        {
            var result = new MenuViewModel();

            foreach (string userRole in UserRoles)
            {
                if (userRole == AppConstants.ADMIN_ROLE)
                {
                    AddAdminMenuViewModelItems(result.Items);
                }
                if (userRole == AppConstants.DRIVER_ROLE)
                {
                    AddDriverMenuViewModelItems(result.Items);
                }
                if (userRole == AppConstants.CLIENT_ROLE)
                {
                    AddClientrMenuViewModelItems(result.Items);
                }
            }

            return result;
        }
        #endregion

        #region Private Methods
        private void TryAddMenuViewModelItem(List<MenuViewModelItem> items, MenuViewModelItem itemToAdd)
        {
            if (items.Any(item => item.Title == itemToAdd.Title
            || (item.ControllerName == itemToAdd.ControllerName
            && item.ActionName == itemToAdd.ActionName)))
            {
                return;
            }

            items.Add(itemToAdd);
        }

        private void AddAdminMenuViewModelItems(List<MenuViewModelItem> items)
        {
            MenuViewModelItem item = null;

            item = new MenuViewModelItem()
            {
                Title = "Головна",
                ControllerName = "Admin",
                ActionName = "Index"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Водії",
                ControllerName = "Admin",
                ActionName = "ShowDriver"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Клиенти",
                ControllerName = "Admin",
                ActionName = "ShowClients"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "Транспортні засоби",
                ControllerName = "Admin",
                ActionName = "ShowCars"
            };
            TryAddMenuViewModelItem(items, item);
        }

        private void AddDriverMenuViewModelItems(List<MenuViewModelItem> items)
        {
            MenuViewModelItem item = null;

            item = new MenuViewModelItem()
            {
                Title = "Home",
                ControllerName = "Base",
                ActionName = "Index"
            };
            TryAddMenuViewModelItem(items, item);

            item = new MenuViewModelItem()
            {
                Title = "DriveControl",
                ControllerName = "ControlDrive",
                ActionName = "TakeControl"
            };
            TryAddMenuViewModelItem(items, item);
            item = new MenuViewModelItem()
            {
                Title = "Cabinet",
                ControllerName = "Account",
                ActionName = ""/////////???????????????
            };
            TryAddMenuViewModelItem(items, item);
        }

        private void AddClientrMenuViewModelItems(List<MenuViewModelItem> items)
        {
            MenuViewModelItem item = null;

            item = new MenuViewModelItem()
            {
                Title = "Home",
                ControllerName = "Base",
                ActionName = "Index"
            };
            TryAddMenuViewModelItem(items, item);
            item = new MenuViewModelItem()
            {
                Title = "New Item Form",
                ControllerName = "ItemForm",
                ActionName = "Create"
            };
            TryAddMenuViewModelItem(items, item);
            item = new MenuViewModelItem()
            {
                Title = "Cabinet",
                ControllerName = "Account",
                ActionName = ""/////////???????????????
            };
            TryAddMenuViewModelItem(items, item);
        }
        #endregion
    }
}

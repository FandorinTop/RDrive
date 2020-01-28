using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using RDrive.ViewModels.AccountViewModels;


namespace RDrive.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task RegisterNewUser(RegisterNewUserAccountView viewModel);

        Task<IdentityResult> FinishRegistrationAndConfirmAccount(FinishRegistrationAndConfirmAccountAccountView viewModel);
        Task SignIn(LoginAccountAccountView loginAccountAccountView);
        Task SignOut();
        Task ForgetPassword(ForgetPasswordAccountView viewModel);
        Task ResetPassword(ResetPasswordAccountView viewModel);
    }
}

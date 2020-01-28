using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RDrive.BusinessLogic.Extention;
using RDrive.BusinessLogic.Mappers.Interfaces;
using RDrive.BusinessLogic.Providers.Interfaces;
using RDrive.BusinessLogic.Services.Interfaces;
using RDrive.DataAccess.Interfaces;
using RDrive.Entities.Entities;
using RDrive.Shared.Constants;
using RDrive.Shared.Exceptions.BusinessLogicExceptions;
using RDrive.ViewModels.AccountViewModels;

namespace RDrive.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        #region Properties

        private IAccountMapper _accountMapper;

        private IEmailProvider _emailProvider;

        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        #endregion

        #region Constructors
        public AccountService(
            IAccountMapper accountMapper,
            IEmailProvider emailProvider,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _accountMapper = accountMapper;

            _emailProvider = emailProvider;

            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Public Methods
        public async Task RegisterNewUser(RegisterNewUserAccountView viewModel)
        {
            var user = new AppUser();

            user.Email = viewModel.Email;
            user.UserName = viewModel.Username;

            if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
            {
                throw new AccountException("Passwords are different");
            }

            if (!(await _userManager.FindByEmailAsync(viewModel.Email) is null) || !(await _userManager.FindByNameAsync(viewModel.Username) is null))
            {
                throw new AccountException("Account with such Email or UserID already exists");
            }

            IdentityResult result = await _userManager.CreateAsync(user, viewModel.Password);

            if (!result.Succeeded)
            {
                string responseError = result.GetFirstError();

                throw new AccountException(responseError);
            }

          

            AppUser userRegistered = await _userManager.FindByEmailAsync(viewModel.Email);
            if (viewModel.Type.ToString() == AppConstants.CLIENT_ROLE)
                await _userManager.AddToRoleAsync(userRegistered, AppConstants.CLIENT_ROLE);
            else if (viewModel.Type.ToString() == AppConstants.DRIVER_ROLE)
                await _userManager.AddToRoleAsync(userRegistered, AppConstants.DRIVER_ROLE);
            else throw new AccountException("Cant register this type");
            //TO DO
            //await EmailConfirmation(userRegistered, viewModel.CurrentUrl);

            

        }
        public async Task<IdentityResult> FinishRegistrationAndConfirmAccount(FinishRegistrationAndConfirmAccountAccountView viewModel)
        {
            var result = new IdentityResult();

            if (viewModel.UserId is null || viewModel.Token is null)
            {
                throw new AccountException("Error finishing registration.");
            }

            AppUser user = await _userManager.FindByIdAsync(viewModel.UserId);

            if (user is null)
            {
                throw new AccountException("User not found.");
            }

            if (user.EmailConfirmed)
            {
                result = IdentityResult.Success;

                return result;
            }

            _accountMapper.MapFinishRegistrationAndConfirmAccountToApplicationUser(viewModel, user as Client);

            IdentityResult updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                throw new AccountException("Error updating user.");
            }

            result = await _userManager.ConfirmEmailAsync(user, viewModel.Token);

            return result;
        }
        public async Task ResetPassword(ResetPasswordAccountView viewModel)
        {
            AppUser user = await _userManager.FindByIdAsync(viewModel.UserId);

            if (user is null)
            {
                throw new AccountException("User not found.");
            }

            if (!viewModel.Password.Equals(viewModel.ConfirmPassword))
            {
                throw new AccountException("Passwords are different.");
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(user, viewModel.Token, viewModel.Password);
        }
        public async Task ForgetPassword(ForgetPasswordAccountView viewModel)
        {
            AppUser user = await _userManager.FindByNameAsync(viewModel.Username);

            if (user is null)
            {
                throw new AccountException("User is not found.");
            }

            if (!user.Email.Equals(viewModel.Email))
            {
                throw new AccountException("Emails are different.");
            }

            await CreateForgetPasswordEmail(user, viewModel.CurrentUrl);
        }
        public async Task SignIn(LoginAccountAccountView loginAccountAccountView)
        {
            var user = await _userManager.FindByEmailAsync(loginAccountAccountView.Email);

            if (user is null)
            {
                throw new AccountException("Couldn't sign in. UserName or password is incorrect.");
            }

            if (!user.EmailConfirmed)
            {
                throw new AccountException("Couldn't sign in. Please, confirm your email address.");
            }

            SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, loginAccountAccountView.Password, false, false);

            if (!result.Succeeded)
            {
                throw new AccountException("Couldn't sign in. UserName or password is incorrect.");
            }
        }
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
        #endregion
        #region Private methods
        private async Task EmailConfirmation(AppUser user, Uri uri)
        {
            string email = user.Email;
            string subject = AppConstants.CONFIRMATION_EMAIL_SUBJECT;

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string tokenHtmlVersion = HttpUtility.UrlEncode(token);

            string linkAddress = $"{uri}Account/FinishRegistration?userId={user.Id}&token={tokenHtmlVersion}&username={user.UserName}";

            string solutionDir = Directory.GetCurrentDirectory();
            string path = $"{solutionDir}{AppConstants.PATH_TO_CONFIRMATION_EMAIL_TEMPLATE}";

            var body = string.Empty;
            using (var reader = new StreamReader(path))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{UserName}", user.UserName);
            body = body.Replace("{Name}", user.FirstName);
            body = body.Replace("{Action_url}", linkAddress);

            await _emailProvider.SendMessage(email, subject, body);
        }
        private async Task CreateForgetPasswordEmail(AppUser user, Uri uri)
        {
            string email = user.Email;
            string subject = AppConstants.FORGET_PASSWORD_EMAIL_SUBJECT;

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string tokenHtmlVersion = HttpUtility.UrlEncode(token);

            string linkAddress = $"{uri}Account/ResetPassword?userId={user.Id}&token={tokenHtmlVersion}";

            string solutionDir = Directory.GetCurrentDirectory();
            string path = $"{solutionDir}{AppConstants.PATH_TO_FORGET_PASSWORD_EMAIL_TEMPLATE}";

            var body = string.Empty;
            using (var reader = new StreamReader(path))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{Name}", user.FirstName);
            body = body.Replace("{Action_url}", linkAddress);

            await _emailProvider.SendMessage(email, subject, body);
        }
        #endregion
    }
}

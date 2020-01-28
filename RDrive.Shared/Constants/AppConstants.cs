using System;
using System.Collections.Generic;
using System.Text;

namespace RDrive.Shared.Constants
{
    public class AppConstants
    {

        public const string LOCALHOST_CONNECTION_STRING_NAME = "Localhost";

        public const string APPLICATION_COOKIE_NAME = "RDriveProjectCookie";

        public const string SUPER_ADMIN_ROLE = "SuperAdmin";
        public const string CLIENT_ROLE = "Client";
        public const string DRIVER_ROLE = "Driver";
        public const string ADMIN_ROLE = "Admin";

        public const string CONFIRMATION_EMAIL_SUBJECT = "confirm email address";
        public const string PATH_TO_CONFIRMATION_EMAIL_TEMPLATE = "\\wwwroot\\emailTemplates\\ConfirmationEmailTemplate.html";
        public const string FORGET_PASSWORD_EMAIL_SUBJECT = "forget password";
        public const string PATH_TO_FORGET_PASSWORD_EMAIL_TEMPLATE = "\\wwwroot\\emailTemplates\\ForgetPasswordEmailTemplate.html";

        // TODO: change.
        public static int startId = 1;
    }
}

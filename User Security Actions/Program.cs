using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure.Identity;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Groups.Item.Sites.Item.ContentModels;


namespace User_Security_Actions
{
    enum PhoneOption
    {
        Mobile,
        AlternateMobile,
        Office
    }

    enum MethodType
    {
        Email,
        Phone,
    }

     class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        // static variables needed by the app
        // - scopes and clientID for connecting to Entra/Graph
        public static string[] scopes = new string[] { "user.readwrite.all  User.EnableDisableAccount.All " +
                "UserAuthenticationMethod.ReadWrite.All User.RevokeSessions.All Auditlog.Read.All Policy.Read.All" };
        public static string ClientId = "492bc3cf-c421-4332-9e96-f56547f3ed56";

        // - values for MFA odata.type to check for various methods and call the specific API
        public const string platformCredMethod = "#microsoft.graph.platformCredentialAuthenticationMethod";
        public const string wHFBAuthMethod = "#microsoft.graph.windowsHelloForBusinessAuthenticationMethod";
        public const string tAPAuthMethod = "#microsoft.graph.temporaryAccessPassAuthenticationMethod";
        public const string softOathAuthMethod = "#microsoft.graph.softwareOathAuthenticationMethod";
        public const string phoneAuthMethod = "#microsoft.graph.phoneAuthenticationMethod";
        public const string passwordAuthMethod = "#microsoft.graph.passwordAuthenticationMethod";
        public const string mSAuthenticatorAuthMethod = "#microsoft.graph.microsoftAuthenticatorAuthenticationMethod";
        public const string hardOathAuthMethod = "#microsoft.graph.hardwareOathAuthenticationMethod";
        public const string fido2AuthMethod = "#microsoft.graph.fido2AuthenticationMethod";
        public const string emailAuthMethod = "#microsoft.graph.emailAuthenticationMethod";

        // - - These should not be used anymore and have been deprecated, but have been left in for backwards compatibility?
        public const string appPasswordAuthMethod = "#microsoft.graph.appPasswordAuthenticationMethod";
        public const string phoneAppOTPAuthMethod = "#microsoft.graph.phoneAppOTPAuthenticationMethod";
        public const string phoneAppNotificationAuthMethhod = "#microsoft.graph.phoneAppNotificationAuthenticationMethod";
        public const string passwordlessMSAuthenticatorMethod = "#microsoft.graph.passwordlessMicrosoftAuthenticatorAuthenticationMethod";

        // - variables used to store data for later lookup/use
        //public static string upn;

        // - - token and graph client 
        public static InteractiveBrowserCredential token;
        public static GraphServiceClient graphClient; 
        // - - string to read input from users
        public static string input;

        // - - bools to track the state of the app
        public static bool signedIn = false;
        public static bool validUser = false;
        public static bool cancelled = false;
        // - - - might be needed to cleaner password reset alternative in the future
        public static bool existPhoneMethods = false;
        // - - users to store the user and admin details
        public static Microsoft.Graph.Beta.Models.User user;
        public static Microsoft.Graph.Beta.Models.User admin;
        // enumerators for phone method storage when we create them.  
        public static PhoneOption phoneOptions;
        public static MethodType methodType;
        // - - - TAP method details
        public static DateTime tapStart;
        public static int tapDurationInMinutes;
        public static bool tapReusable;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}

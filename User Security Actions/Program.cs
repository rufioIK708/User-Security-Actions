using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure.Core;
using Azure.Identity;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Groups.Item.Sites.Item.ContentModels;
using Microsoft.Graph.Beta.Models;
using User_Security_Actions;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Identity.Client;


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
                "UserAuthenticationMethod.ReadWrite.All User.RevokeSessions.All Auditlog.Read.All Policy.Read.All " +
                "user.read GroupMember.Read.All"};

        public static string ClientId = "492bc3cf-c421-4332-9e96-f56547f3ed56";

        public static string TenantId = "common";

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
        public const string qrCodeAuthMethod = "#microsoft.graph.qrCodePinAuthenticationMethod";
        

        // - - These should not be used anymore and have been deprecated, but have been left in for backwards compatibility?
        public const string appPasswordAuthMethod = "#microsoft.graph.appPasswordAuthenticationMethod";
        public const string phoneAppOTPAuthMethod = "#microsoft.graph.phoneAppOTPAuthenticationMethod";
        public const string phoneAppNotificationAuthMethhod = "#microsoft.graph.phoneAppNotificationAuthenticationMethod";
        public const string passwordlessMSAuthenticatorMethod = "#microsoft.graph.passwordlessMicrosoftAuthenticatorAuthenticationMethod";

        // - variables used to store data for later lookup/use
        //public static string upn;
#nullable enable
        // - - token and graph client 
        public static InteractiveBrowserCredential? token = null;
        public static AccessToken? accessToken = null;
        public static GraphServiceClient? graphClient = null;
        public static HttpClient? httpClient = null;
        public static AuthenticationResult? authResult = null;
        public static QrCodePinAuthenticationMethodConfiguration? qrPolicy = null;
        // - - string to read input from users
        public static string? input = null;
#nullable disable
        // - - bools to track the state of the app
        public static bool signedIn = false;
        public static bool validUser = false;
       
        // - - users to store the user and admin details
        public static Microsoft.Graph.Beta.Models.User user;
        public static Microsoft.Graph.Beta.Models.User admin;
        // enumerators for phone method storage for adding new security methods.  
        public static PhoneOption phoneOptions;
        public static MethodType methodType;
       


        // - - main form for the app, this is used to show the UI and interact with the user
        public static Form1 main_form;

        [STAThread]
        static void Main()
        {

            //System.Net.WebRequest.DefaultWebProxy = new System.Net.WebProxy("127.0.0.1", 8888);

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Initialize the main form
            main_form = new Form1();
            System.Windows.Forms.Application.Run(main_form);

        }
    }
}

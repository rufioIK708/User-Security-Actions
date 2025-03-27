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
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public static string[] scopes = new string[] { "user.readwrite.all  User.EnableDisableAccount.All " +
                "UserAuthenticationMethod.ReadWrite.All User.RevokeSessions.All" };
        public static string ClientId = "492bc3cf-c421-4332-9e96-f56547f3ed56";
        //public static string upn;
        public static string input;
        public static bool signedIn = false;
        public static bool validUser = false;
        public static InteractiveBrowserCredential token;
        public static GraphServiceClient graphClient;
        public static Microsoft.Graph.Beta.Models.User user;
        public static Microsoft.Graph.Beta.Models.User admin;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}

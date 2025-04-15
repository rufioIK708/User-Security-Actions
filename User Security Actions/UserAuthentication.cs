using System;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Azure.Identity;
using System.Threading.Tasks;
using Microsoft.Graph.Beta.Models.ODataErrors;
using System.Net.Http;
using System.Windows.Forms;

namespace User_Security_Actions
{
    internal class UserAuthentication
    {
        public UserAuthentication()
        {

        }

        public static InteractiveBrowserCredential SignInUserAndGetToken (string[] scopes, string ClientId)
        {

            InteractiveBrowserCredentialOptions interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions()
            {
                ClientId = ClientId
            };
            InteractiveBrowserCredential interactiveBrowserCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);

            return interactiveBrowserCredential;
        }



        public static async Task<bool> getAndPrintUser(GraphServiceClient graphClient, string upn)
        {
            User admin = await graphClient.Me.GetAsync();
            User user = new User();
            //string? upn;
            bool result = false;

            //try to get the user


            try
            {
                user = await getUser(graphClient, upn);
                result = true;
            }
            catch (ODataError e)
            {
                Console.WriteLine("Error getting user: try again");
                Console.WriteLine(e.Error);
                result = false;

            }

            if (admin.Id == user.Id)
            {
                Console.WriteLine("This app is intended to make administrator changes." +
                    "\nYou cannot make admnistrator changes on your own account." +
                    "\nPlease select a different user");
                result = false;
            }

            if (result)
            {

                //printUserStatus(user);
                //getAndPrintMFA(app, upn);
            }
            else
                Console.WriteLine("Error!");

            return result;

        }

        //function to get the user and return the user object
        private static async Task<User> getUser(GraphServiceClient graphClient, string upn)
        {
            User user = new User();

            try
            {
                user = await graphClient.Users[upn].GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Select = new[] { "displayName", "onPremisesImmutableId", "userPrincipalName",
                                        "MemberOf", "AccountEnabled", "PasswordPolicies", "RefreshTokensValidFromDateTime" };
                });
            }
            catch (ODataError e)
            {
                Console.WriteLine("Error: getting user. Please make sure username is correct.");
                Console.WriteLine(e.Error);
                Console.WriteLine(e.Message);

                throw e;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error communicating with Graph.");
                Console.WriteLine("Error: " + e.Message);
            }

            return user;
        }


    }
}

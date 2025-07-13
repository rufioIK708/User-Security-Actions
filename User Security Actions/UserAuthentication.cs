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


    }
}

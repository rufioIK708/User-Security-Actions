using System;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Azure.Identity;
using System.Threading.Tasks;
using Microsoft.Graph.Beta.Models.ODataErrors;
using System.Net.Http;
using System.Windows.Forms;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;

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

            
            //initialize the Graph client
            Program.graphClient = new GraphServiceClient(interactiveBrowserCredential, scopes);

            return interactiveBrowserCredential;
        }

        public static async Task<AccessToken?> GetAccessToken()
        {
            TokenRequestContext tokenRequestContext;
            AccessToken? accessToken = null;

            if (null == Program.token)
                Program.token = SignInUserAndGetToken(Program.scopes, Program.ClientId);
            if (null == Program.accessToken || DateTimeOffset.Now >= Program.accessToken.Value.ExpiresOn
                || DateTimeOffset.Now >= Program.accessToken.Value.RefreshOn)
            {
                tokenRequestContext = new TokenRequestContext(Program.scopes, null);

                accessToken = await Program.token.GetTokenAsync(tokenRequestContext, CancellationToken.None);
            }

            return accessToken;
        }
    }
}

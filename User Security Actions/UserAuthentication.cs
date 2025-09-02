using Azure.Core;
using Azure.Identity;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Microsoft.Graph.Beta.Models.ManagedTenants;
using Microsoft.Graph.Beta.Models.ODataErrors;
using Microsoft.Identity.Client;
using System;
using System.IdentityModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace User_Security_Actions
{
    internal class UserAuthentication
    {
        
        public UserAuthentication()
        {

        }

        public static InteractiveBrowserCredential GetCredential(string[] scopes, string ClientId)
        {
            //options - provide the client ID
            var opts = new InteractiveBrowserCredentialOptions()
            {
                ClientId = ClientId
            };
            //create the credential using the opttions.
            InteractiveBrowserCredential cred = new InteractiveBrowserCredential(opts);

            //return the credential
            return cred;

        }

        public static HttpClient GetHttpClient (string accessToken, IHttpClientFactory httpClientFactory)
        {
            //create the httpclient
            var httpClient = httpClientFactory.CreateClient("LoggedClient");
            //specify the authorization header form the accessToken string
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            //return the client
            return httpClient;
        }

        public static GraphServiceClient GetGraphClient (HttpClient client)
        {
            //create and return the client
            GraphServiceClient graphClient = new GraphServiceClient(client);
            return graphClient;
        }

        //old configuration, needs to be removed and replaced in the app.
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

        public static async Task GetAccessToken()
        {
            TokenRequestContext tokenRequestContext;
            

            if (null == Program.token)
                Program.token = SignInUserAndGetToken(Program.scopes, Program.ClientId);
            if (null == Program.accessToken || DateTimeOffset.Now >= Program.accessToken.Value.ExpiresOn
                || DateTimeOffset.Now >= Program.accessToken.Value.RefreshOn)
            {
                tokenRequestContext = new TokenRequestContext(Program.scopes, null);

                Program.accessToken = await Program.token.GetTokenAsync(tokenRequestContext, CancellationToken.None);
            }
        }

    }
}

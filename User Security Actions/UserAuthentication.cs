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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Security_Actions
{
    internal class UserAuthentication
    {
        
        public UserAuthentication()
        {

        }

        /*public static async Task SignInAndCreateClients(string[] scopes, string ClientId)
        {
            var publicClientApp = PublicClientApplicationBuilder
            .Create(ClientId)
            .WithTenantId(Program.TenantId)
            .WithRedirectUri("http://localhost") // Required for interactive flow
            .Build();

            AuthenticationResult authResult = null;

            try
            {
                 authResult = await publicClientApp
                .AcquireTokenInteractive(scopes)
                .ExecuteAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            if (null != authResult)
            {
                var httpClient = new HttpClient(new HttpClientHandler
                {
                    AllowAutoRedirect = true,
                    UseCookies = true,
                    AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                    MaxConnectionsPerServer = int.MaxValue,
                    UseProxy = true,
                    Proxy = null,
                });

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);


                var garaphClient = new GraphServiceClient(httpClient);

                Program.graphClient = garaphClient;
                Program.httpClient = httpClient;
                Program.authResult = authResult;
            }
            
        }*/

        public static InteractiveBrowserCredential GetCredential(string[] scopes, string ClientId)
        {
            var opts = new InteractiveBrowserCredentialOptions()
            {
                ClientId = ClientId
            };
            InteractiveBrowserCredential cred = new InteractiveBrowserCredential(opts);

            return cred;

        }

        public static HttpClient GetHttpClient (string accessToken)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            return new HttpClient();
        }

        public static GraphServiceClient GetGraphClient (HttpClient client)
        {
            return new GraphServiceClient(client);
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

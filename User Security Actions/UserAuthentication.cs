using Azure.Core;
using Azure.Identity;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Microsoft.Graph.Beta.Models.ManagedTenants;
using Microsoft.Graph.Beta.Models.ODataErrors;
using Microsoft.Identity.Client;
using System;
using System.IdentityModel;
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

        public static async void SignInAndCreateClients(string[] scopes, string ClientId)
        {
            var publicClientApp = PublicClientApplicationBuilder
            .Create(ClientId)
            .WithTenantId(Program.TenantId)
            .WithRedirectUri("http://localhost") // Required for interactive flow
            .Build();

            var authResult = await publicClientApp
                .AcquireTokenInteractive(scopes)
                .ExecuteAsync();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);


            var garaphClient = new GraphServiceClient(httpClient);

            Program.graphClient = garaphClient;
            Program.httpClient = httpClient;
            Program.authResult = authResult;
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

        public static async Task MaintainToken()
        {
            if (null == Program.authResult || Program.authResult.ExpiresOn > DateTimeOffset.Now)
            {
                var publicClientApp = PublicClientApplicationBuilder
                    .Create(Program.ClientId)
                    .WithTenantId(Program.TenantId)
                    .WithRedirectUri("http://localhost") // Required for interactive flow
                    .Build();

                Program.authResult = await publicClientApp
                    .AcquireTokenInteractive(Program.scopes)
                    .ExecuteAsync();
            }
        }

    }
}

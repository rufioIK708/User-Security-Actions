using System;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Azure.Identity;
using System.Threading.Tasks;

namespace User_Security_Actions
{
    internal class UserAuthentication
    {
        public UserAuthentication()
        {

        }

        public static async Task<InteractiveBrowserCredential> SignInUserAndGetToken(string[] scopes, string ClientId)
        {

            InteractiveBrowserCredentialOptions interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions()
            {
                ClientId = ClientId
            };
            InteractiveBrowserCredential interactiveBrowserCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);

            return interactiveBrowserCredential;
        }

        public record class MFAData(
        [property: JsonPropertyName("CreatedDateTime")] DateTime? CreatedDateTime,
        [property: JsonPropertyName("AdditionalData")] Dictionary<string, object>? AdditionalData,
        [property: JsonPropertyName("BackingStore")] Dictionary<string, object>? BackingStore,
        [property: JsonPropertyName("Id")] string? Id,
        [property: JsonPropertyName("OdataType")] string? typeOfMethod)
        {
            //public DateTime CreatedDateTime => CreatedDateTime.ToLocalTime();


        }

        public class MFAFunctions()
        {
            public static async Task<bool> getAndPrintUser(GraphServiceClient graphClient, string upn)
            {
                User admin = await graphClient.Me.GetAsync();
                User user = new();
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

                    printUserStatus(user);
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
                    user = await graphClient.Users[upn].GetAsync(static (requestConfiguration) =>
                    {
                        requestConfiguration.QueryParameters.Select = [ "displayName", "onPremisesImmutableId", "userPrincipalName",
                                    "MemberOf", "AccountEnabled", "PasswordPolicies", "RefreshTokensValidFromDateTime" ];
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

            public static async Task<List<MFAData>> getAndPrintMFA(GraphServiceClient graphClient, string upn, bool print)
            {
                var response = new AuthenticationMethodCollectionResponse();

                response = await getUserMfaMethods(graphClient, upn);


                //Console.WriteLine(jsonString);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(response.Value, options);
                var methods = new List<MFAData>();

                try
                {
                    methods = JsonSerializer.Deserialize<List<MFAData>>(jsonString);
                }
                catch (JsonException e)
                {
                    Console.WriteLine("Error converting JSON");
                    Console.WriteLine("error: " + e.Message);
                    Console.WriteLine("additional info : " + e.Data);
                }


                Console.WriteLine("Number of AuthMehtods:  " + response.Value.Count);

                //onsole.WriteLine(jsonString);

                Console.WriteLine(Environment.NewLine);

                if (null != methods && true == print)
                    printMFAData(methods);

                return methods;

            }

            private static async Task<AuthenticationMethodCollectionResponse> getUserMfaMethods(GraphServiceClient graphClient, string upn)
            {
                var response = new AuthenticationMethodCollectionResponse();

                try
                {
                    response = await graphClient.Users[upn].Authentication.Methods.GetAsync();
                    return response;
                }
                catch (ODataError e)
                {
                    Console.WriteLine("Error! getting MFA methods: " + e);
                }

                return response;


            }
            private static void printMFAData(List<MFAData> list)
            {
                foreach (var item in list)
                {
                    if (null != item.typeOfMethod)
                    {
                        switch (item.typeOfMethod)
                        {
                            case "#microsoft.graph.platformCredentialAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Platform Credential");
                                break;

                            case "#microsoft.graph.windowsHelloForBusinessAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Windows Hello for Business");
                                break;

                            case "#microsoft.graph.temporaryAccessPassAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Temporary Access Pass");
                                break;

                            case "#microsoft.graph.softwareOathAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Software Oath Token");
                                break;

                            case "#microsoft.graph.phoneAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Phone Authentication");
                                break;

                            case "#microsoft.graph.passwordAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Password");
                                break;

                            case "#microsoft.graph.microsoftAuthenticatorAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Microsoft Authenticator");
                                break;

                            case "#microsoft.graph.hardwareOathAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Hardware Oath Token");
                                break;

                            case "#microsoft.graph.fido2AuthenticationMethod":
                                Console.WriteLine($"Type of Method : Fido2 Passkey");
                                break;

                            case "#microsoft.graph.emailAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Alternate E-Mail");
                                break;



                            case "#microsoft.graph.phoneAppNotificationAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Phone App Notification");
                                break;


                            //has been deprecated and shouldn't be needed 

                            case "#microsoft.graph.appPasswordAuthenticationMethod":
                                Console.WriteLine($"Type of Method : App Password");
                                break;

                            case "#microsoft.graph.phoneAppOTPAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Phone App OTP");
                                break;

                            case "#microsoft.graph.passwordlessMicrosoftAuthenticatorAuthenticationMethod":
                                Console.WriteLine($"Type of Method : Passwordless Microsoft Authenticator");
                                break;

                            default:
                                Console.WriteLine($"Type of Method : {item.typeOfMethod}");
                                break;
                        }



                    }
                    if (null != item.Id)
                        Console.WriteLine($"ID             : {item.Id}");
                    if (null != item.CreatedDateTime)
                        Console.WriteLine($"CreatedDateTime: {item.CreatedDateTime}");
                    if (null != item.AdditionalData)
                    {
                        //Console.WriteLine(value: $"Additional Data: Key = {item.AdditionalData.Keys}, Value = {item.AdditionalData.Values}");

                        foreach (var entry in item.AdditionalData)
                        {
                            Console.WriteLine($"Additional Data: {entry.Key}: {entry.Value}");
                        }
                    }
                    //if(null != item.BackingStore)
                    //    Console.WriteLine($"Backing Store  : {item.BackingStore}");
                    Console.WriteLine(Environment.NewLine);
                }

            }
        }
    }
}

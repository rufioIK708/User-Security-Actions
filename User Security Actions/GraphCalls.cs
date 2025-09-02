using Azure;
using Microsoft.Graph.Beta.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace User_Security_Actions
{
    //Custom class to make direct HTTP calls to MS Graph
    // this is for missing or functionality that is not working as expected.
    public class GraphCalls
    {
#nullable enable
        const string baseAddress = "https://graph.microsoft.com/beta";
        const string QR_CODE_METHOD_ADDRESS_TEMPLATE = "/users/{0}/authentication/qrCodePinMethod";
        const string QR_CODE_STANDARD_ADDRESS_TEMPLATE = "/users/{0}/authentication/qrCodePinMethod/standardQrCode";
        const string QR_CODE_TEMPORARY_ADDRESS_TEMPLATE = "/users/{0}/authentication/qrCodePinMethod/temporaryQrCode";
        const string QR_CODE_PIN_ADDRESS_TEMPLATE = "/users/{0}/authentication/qrCodePinMethod/pin";
        const string TAP_METHOD_ADDRESS_TEMPLATE = "/users/{0}/authentication/temporaryAccessPassMethods";
        const string GRAPH_FIDO2_CREATEOPTS_TEMPLATE = "/users/{0}/authentication/fido2methods/creationOptions(challengeTimeoutInMinutes={1}";

        public enum ErrorCorrectionLevel
        {
            l,
            m,
            q,
            h,
            unknownFutureValue
        }

        public class QrCodeImageDetails
        {
            public byte[]? BinaryValue { get; set; }
            public int? Version { get; set; }
            public byte[]? RawContent { get; set; }
            [JsonIgnore]
            public ErrorCorrectionLevel? ErrorCorrectionLevel { get; set; }
        }

        public class QrCode
        {
            public string? id { get; set; }
            public DateTimeOffset? ExpireDateTime { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? LastUsedDateTime { get; set; }
            public QrCodeImageDetails? image { get; set; }
        }

        public class QrPin
        {
            public string? Id { get; set; }
            public string? Code { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public Boolean? ForceChangePinNextSignIn { get; set; }
            public DateTimeOffset? UpdatedDateTime { get; set; }
        }

        public class QrCodePinAuthenticationMethod
        {
            public Boolean? IsUsable { get; set; }
            public string? MethodUsabilityReason { get; set; }
            public DateTimeOffset? LastUsedDateTime { get; set; }
            public QrCode? StandardQRCode { get; set; }
            public QrCode? TemporaryQRCode { get; set; }
            public QrPin? Pin { get; set; }
        }
#nullable disable

        public static async Task<QrCodePinAuthenticationMethod> GetQrCodeMethodOne(HttpClient httpClient, string userId)
        {
            QrCodePinAuthenticationMethod qrCodeMethod = null;
            
            string endpoint = string.Format(QR_CODE_METHOD_ADDRESS_TEMPLATE, userId);

            // Call the endpoint for the current user
            var response = await httpClient.GetAsync(baseAddress + endpoint);

            //check the response and throw an exception if we are not successful
            if (!response.IsSuccessStatusCode && System.Net.HttpStatusCode.NotFound != response.StatusCode)
            {
                // You may want to handle errors more gracefully
                throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }

            //deserialize the JSON into objects.
            try
            {
                qrCodeMethod = DeserializeObject<QrCodePinAuthenticationMethod>
                            (await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                throw;
            }


            // Return the deserialized object.
            return qrCodeMethod;
            
        }

        public static async Task DeleteStandardQrCode(HttpClient httpClient, string userId)
        {
            string endpoint = string.Format(QR_CODE_STANDARD_ADDRESS_TEMPLATE, userId);

            // Call the endpoint for the current user
            var response = await httpClient.DeleteAsync(baseAddress + endpoint);

            //check the response and throw an exception if we are not successful
            if (!response.IsSuccessStatusCode)
            {
                // You may want to handle errors more gracefully
                throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }
            
        }

        public static async Task DeleteTemporaryQrCode(HttpClient httpClient, string userId)
        {
            string endpoint = string.Format(QR_CODE_TEMPORARY_ADDRESS_TEMPLATE, userId);

            // Call the endpoint for the current user
            var response = await httpClient.DeleteAsync(baseAddress + endpoint);

            //check the response and throw an exception if we are not successful
            if (!response.IsSuccessStatusCode)
            {
                // You may want to handle errors more gracefully
                throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }
        }

        public static async Task<QrPin> ResetQrCodePin(HttpClient httpClient, string userId)
        {
            //object to return
            QrPin returnedPin = null;
            
            //configure the endpoint
            string endpoint = string.Format(QR_CODE_PIN_ADDRESS_TEMPLATE, userId);

            //configure the payload
            String patchPin = $"{{\r\n  \"@odata.type\": \"#microsoft.graph.qrPin\",\r\n  \"code\": \"\",\r\n}}";

            //create the request
            var content = new StringContent(patchPin, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), baseAddress + endpoint)
            {
                Content = content
            };

            // Call the endpoint for the current user
            var response = await httpClient.SendAsync(request);

            //check the response and throw an exception if we are not successful
            if (!response.IsSuccessStatusCode)
            {
                // You may want to handle errors more gracefully
                throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }
            else
            {
                try
                {
                    var deserialize = DeserializeObject<QrPin>
                        (await response.Content.ReadAsStringAsync());

                    returnedPin = deserialize;
                }
                catch (Exception) { throw; }
            }

            return returnedPin;
        }

        public static async Task<QrCode> CreateStandardQrCode(QrCode newQrCode, HttpClient httpClient, string userId)
        {
            //object to return
            QrCode returnedCode = null;

            string endpoint = string.Format(QR_CODE_STANDARD_ADDRESS_TEMPLATE, userId);

            //configure payload
            String patchCode = $"{{\"@odata.type\": \"#microsoft.graph.qrCode\", \"expireDateTime\": \"{newQrCode.ExpireDateTime.Value.ToUniversalTime()}\", \"startDateTime\": \"{newQrCode.StartDateTime.Value.ToUniversalTime()}\",}}";

            //configure request
            var content = new StringContent(patchCode, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), baseAddress + endpoint)
            {
                Content = content
            };

            // Call the endpoint for the current user
            var response = await httpClient.SendAsync(request);

            //check the response and throw an exception if we are not successful
            if (!response.IsSuccessStatusCode)
            {
                // You may want to handle errors more gracefully
                throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }
            else
            {
                try
                {
                    var deserialize = DeserializeObject<QrCode>
                        (await response.Content.ReadAsStringAsync());

                    returnedCode = deserialize;
                }
                catch (Exception) { throw; }
            }
            

            return returnedCode;

        }

        public static async Task<QrCode> CreateTemporaryQrCode(QrCode newQrCode, HttpClient httpClient, string userId)
        {
            //create the object to return
            QrCode newCode = null;

            string endpoint = string.Format(QR_CODE_TEMPORARY_ADDRESS_TEMPLATE, userId);

            //create the payload
            String patchCode = $"{{\"@odata.type\": \"#microsoft.graph.qrCode\", \"expireDateTime\": \"{newQrCode.ExpireDateTime.Value.ToUniversalTime()}\", \"startDateTime\": \"{newQrCode.StartDateTime.Value.ToUniversalTime()}\",}}";

            //create the request
            var content = new StringContent(patchCode, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), baseAddress + endpoint)
            {
                Content = content
            };

            // Call the endpoint for the current user
            var response = await httpClient.SendAsync(request);

            //check the response and throw an exception if we are not successful
            if (!response.IsSuccessStatusCode)
            {
                // You may want to handle errors more gracefully
                throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }
            else
            {
                try
                {
                    var deserialize = DeserializeObject<QrCode>
                        (await response.Content.ReadAsStringAsync());

                    newCode = deserialize;
                }
                catch (Exception) { throw; }

            }

            return newCode;
        }

        public static async Task<QrCodePinAuthenticationMethod>
            CreateQrCodeMethod(QrCodePinAuthenticationMethod newQrCode, HttpClient httpClient, string userId)
        {
            QrCodePinAuthenticationMethod newCodeMethod = null;

            //configure the endpoint
            string endpoint = string.Format(QR_CODE_METHOD_ADDRESS_TEMPLATE, userId);

            //configure the payload
            string patchCode = $"{{\"@odata.type\": \"#microsoft.graph.qrCodePinAuthenticationMethod\",  \"standardQRCode\": {{\"expireDateTime\": \"{newQrCode.StandardQRCode.ExpireDateTime.Value.ToUniversalTime()}\",\"startDateTime\": \"{newQrCode.StandardQRCode.StartDateTime.Value.ToUniversalTime()}\"}}, \"pin\": {{\"code\": \"{newQrCode.Pin.Code}\"}}}}";
            //configure the request
            var content = new StringContent(patchCode, Encoding.UTF8, "application/json");

            // Call the endpoint for the current user
            var response = await httpClient.PutAsync(baseAddress + endpoint, content);

            //check the response and throw an exception if we are not successful
            if (!response.IsSuccessStatusCode)
            {
                // You may want to handle errors more gracefully
                throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }
            else
            {
                try
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    var deserialize = DeserializeObject<QrCodePinAuthenticationMethod>
                        (jsonString);

                    newCodeMethod = deserialize;
                }
                catch (Exception) { throw; }

            }

            return newCodeMethod;
        }

        public static T DeserializeObject<T>(string json)
        {
            var options = new JsonSerializerOptions
            {
                AllowOutOfOrderMetadataProperties = true,
                PropertyNameCaseInsensitive = true
            };

            try
            {
                var deserialize = JsonSerializer.Deserialize<T>(json, options);
                return deserialize;
            }
            catch (Exception) { throw; }
        }

        public static async Task<TemporaryAccessPassAuthenticationMethod> CreateTapMethod
            (TemporaryAccessPassAuthenticationMethod tapMethod, HttpClient httpClient, string userId)
        {
            TemporaryAccessPassAuthenticationMethod newTapMethod = null;
            
            //configure the endpoint
            string endpoint = string.Format(TAP_METHOD_ADDRESS_TEMPLATE, userId);

            ////configure the needed variables
            string startDateTime = tapMethod.StartDateTime.Value.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            string usable = tapMethod.IsUsableOnce.ToString().ToLower();
            int lifetime = (int)tapMethod.LifetimeInMinutes;

            //configrue the payload
            string patchCode = $"{{ \"startDateTime\": \"{startDateTime}\"," +
                $"\"lifetimeInMinutes\": {lifetime}," +
                $"\"isUsableOnce\": {usable} }}";

            var content = new StringContent(patchCode, Encoding.UTF8, "application/json");

            // Call the endpoint for the current user
            var response = await httpClient.PostAsync(baseAddress + endpoint, content);

            //check the response and throw an exception if we are not successful
            if (!response.IsSuccessStatusCode)
            {
                // You may want to handle errors more gracefully
                throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }

            //deserialize the JSON into objects.
            try
            {
                newTapMethod = DeserializeObject<TemporaryAccessPassAuthenticationMethod>
                    (await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                throw;
            }


            // Return the deserialized object.
            return newTapMethod;
        }
        

        public static async Task<WebauthnCredentialCreationOptions> getFido2CreationOptions(int timeout, HttpClient httpClient, string userId)
        {
            WebauthnCredentialCreationOptions options = null;

            string endpoint = String.Format(GRAPH_FIDO2_CREATEOPTS_TEMPLATE, Program.user.Id, timeout);

            //update the token
            await UserAuthentication.GetAccessToken();

             // Call the endpoint for the current user
             var response = await httpClient.GetAsync(baseAddress + endpoint);

            //check the response and throw an exception if we are not successful
            if (!response.IsSuccessStatusCode)
            {
                // You may want to handle errors more gracefully
                throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }

            //deserialize the JSON into objects.
            try
            {
                options = DeserializeObject<WebauthnCredentialCreationOptions>
                    (await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                throw;
            }

            return options;
        }
    }
}



using Azure;
using Microsoft.Graph.Beta.Models.ManagedTenants;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace User_Security_Actions
{
    public class GraphCalls
    {
#nullable enable
        static string baseAddress = "https://graph.microsoft.com/beta";
        static string QR_CODE_METHOD_TEMPLATE = "/users/{0}/authentication/qrCodePinMethod";
        static string QR_CODE_STANDARD_TEMPLATE = "/users/{0}/authentication/qrCodePinMethod/standardQrCode";
        static string QR_CODE_TEMPORARY_TEMPLATE = "/users/{0}/authentication/qrCodePinMethod/temporaryQrCode";
        static string QR_CODE_PIN_TEMPLATE = "/users/{0}/authentication/qrCodePinMethod/pin";

        public enum errorCorrectionLevel
        {
            l,
            m,
            q,
            h
        }

        public class QrCodeImageDetails
        {
            public byte[]? BinaryValue { get; set; }
            public errorCorrectionLevel? ErrorCorrectionLevel { get; set; }
            public byte[]? RawContent { get; set; }
            public int? Version { get; set; }
        }

        public class QrCode
        {
            public string? id { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? ExpireDateTime { get; set; }
            public QrCodeImageDetails? image { get; set; }
            public DateTimeOffset? LastUsedDateTime { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
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

        public static async Task<QrCodePinAuthenticationMethod> GetQrCodeMethodOne()
        {
            QrCodePinAuthenticationMethod qrCodeMethod = null;
            string userId = Program.user.Id;
            string endpoint = string.Format(QR_CODE_METHOD_TEMPLATE, userId);

            //if Program.accessToken is null, get a new one.
            if (null == Program.accessToken)
                Program.accessToken = await UserAuthentication.GetAccessToken();


            using (var httpClient = new HttpClient())
            {
                string accessToken = Program.accessToken.Value.Token.ToString();
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                // Call the endpoint for the current user
                var response = await httpClient.GetAsync(baseAddress + endpoint);

                //check the response and throw an exception if we are not successful
                if (!response.IsSuccessStatusCode && "404" != response.StatusCode.ToString())
                {
                    // You may want to handle errors more gracefully
                    throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }

                //deserialize the JSON into objects.
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    qrCodeMethod = JsonSerializer.Deserialize<QrCodePinAuthenticationMethod>
                        (await response.Content.ReadAsStringAsync(),options);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                
                // Return the deserialized object.
                return qrCodeMethod;
            }
        }

        public static async void DeleteStandardQrCode()
        {
            string userId = Program.user.Id;
            string endpoint = string.Format(QR_CODE_STANDARD_TEMPLATE, userId);

            //if Program.accessToken is null, get a new one.
            if (null == Program.accessToken)
                Program.accessToken = await UserAuthentication.GetAccessToken();


            using (var httpClient = new HttpClient())
            {
                string accessToken = Program.accessToken.Value.Token.ToString();
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                // Call the endpoint for the current user
                var response = await httpClient.DeleteAsync(baseAddress + endpoint);
                
                //check the response and throw an exception if we are not successful
                if (!response.IsSuccessStatusCode)
                {
                    // You may want to handle errors more gracefully
                    throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
        }

        public static async void DeleteTemporaryQrCode()
        {
            string userId = Program.user.Id;
            string endpoint = string.Format(QR_CODE_TEMPORARY_TEMPLATE, userId);

            //if Program.accessToken is null, get a new one.
            if (null == Program.accessToken)
                Program.accessToken = await UserAuthentication.GetAccessToken();


            using (var httpClient = new HttpClient())
            {
                string accessToken = Program.accessToken.Value.Token.ToString();
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                // Call the endpoint for the current user
                var response = await httpClient.DeleteAsync(baseAddress + endpoint);

                //check the response and throw an exception if we are not successful
                if (!response.IsSuccessStatusCode)
                {
                    // You may want to handle errors more gracefully
                    throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
        }

        public static async Task<bool> ResetQrCodePin(String newPin)
        {
            bool successful = false;
            string userId = Program.user.Id;
            string endpoint = string.Format(QR_CODE_PIN_TEMPLATE, userId);

            //if Program.accessToken is null, get a new one.
            if (null == Program.accessToken)
                Program.accessToken = await UserAuthentication.GetAccessToken();


            using (var httpClient = new HttpClient())
            {
                string accessToken = Program.accessToken.Value.Token.ToString();
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                QrPin pin = new QrPin();

                if (null != newPin)
                    pin.Code = newPin;

                String patchPin = JsonSerializer.Serialize(pin);

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
                    successful = true;
            }

            return successful;
        }

        public static async Task<QrCodePinAuthenticationMethod> CreateStandardQrCode(QrCode newQrCode)
        {
            QrCodePinAuthenticationMethod newCodeMethod = null;

            //bool successful = false;
            string userId = Program.user.Id;
            string endpoint = string.Format(QR_CODE_STANDARD_TEMPLATE, userId);

            //if Program.accessToken is null, get a new one.
            if (null == Program.accessToken)
                Program.accessToken = await UserAuthentication.GetAccessToken();


            using (var httpClient = new HttpClient())
            {
                string accessToken = Program.accessToken.Value.Token.ToString();
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                String patchCode = JsonSerializer.Serialize(newQrCode);

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
                    var deserialize = JsonSerializer.Deserialize<QrCodePinAuthenticationMethod>
                        (await response.Content.ReadAsStringAsync());

                    newCodeMethod = deserialize;
                }
            }

            return newCodeMethod;

        }

        public static async Task<QrCodePinAuthenticationMethod> CreateTemporaryQrCode(QrCode newQrCode)
        {
            QrCodePinAuthenticationMethod newCodeMethod = null;

            //bool successful = false;
            string userId = Program.user.Id;
            string endpoint = string.Format(QR_CODE_TEMPORARY_TEMPLATE, userId);

            //if Program.accessToken is null, get a new one.
            if (null == Program.accessToken)
                Program.accessToken = await UserAuthentication.GetAccessToken();


            using (var httpClient = new HttpClient())
            {
                string accessToken = Program.accessToken.Value.Token.ToString();
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                String patchCode = JsonSerializer.Serialize(newQrCode);

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
                    var deserialize = JsonSerializer.Deserialize<QrCodePinAuthenticationMethod>
                        (await response.Content.ReadAsStringAsync());

                    newCodeMethod = deserialize;
                }
            }

            return newCodeMethod;
        }

        public static async Task<QrCodePinAuthenticationMethod> 
            CreateTemporaryQrCodeMethod(QrCodePinAuthenticationMethod newQrCode)
        {
            QrCodePinAuthenticationMethod newCodeMethod = null;

            //bool successful = false;
            string userId = Program.user.Id;
            string endpoint = string.Format(QR_CODE_METHOD_TEMPLATE, userId);

            //if Program.accessToken is null, get a new one.
            if (null == Program.accessToken)
                Program.accessToken = await UserAuthentication.GetAccessToken();


            using (var httpClient = new HttpClient())
            {
                string accessToken = Program.accessToken.Value.Token.ToString();
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

                String patchCode = JsonSerializer.Serialize(newQrCode);

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
                    var deserialize = JsonSerializer.Deserialize<QrCodePinAuthenticationMethod>
                        (await response.Content.ReadAsStringAsync());

                    newCodeMethod = deserialize;
                }
            }

            return newCodeMethod;
        }
    }
}



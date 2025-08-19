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
    internal class GraphCalls
    {
#nullable enable
        static string baseAddress = "https://graph.microsoft.com/beta";
        static string QR_CODE_METHOD_TEMPLATE = "/users/{0}/authentication/qrCodePinMethod";
        static string QR_CODE_STANDARD_TEMPLATE = "/users/{0}/authentication/qrcodePinMethod/standardQrCode";
        static string QR_CODE_TEMPORARY_TEMPLATE = "/users/{0}/authentication/qrcodePinMethod/temporaryQrCode";
        static string QR_CODE_PIN_TEMPLATE = "/users/{0}/authentication/qrcodePinMethod/pin";

        public enum errorCorrectionLevel
        {
            l,
            m,
            q,
            h
        }

        public class QrCodeImageDetails
        {
            public byte[]? binaryValue { get; set; }
            public errorCorrectionLevel? errorCorrectionLevel { get; set; }
            public byte[]? rawContent { get; set; }
            public int? version { get; set; }
        }

        public class QrCode
        {
            public string? id { get; set; }
            public DateTimeOffset? createdDateTime { get; set; }
            public DateTimeOffset? expireDateTime { get; set; }
            public QrCodeImageDetails? image { get; set; }
            public DateTimeOffset? lastUsedDateTime { get; set; }
            public DateTimeOffset? startDateTime { get; set; }
        }

        public class QrPin
        {
            public string? code { get; set; }
            public DateTimeOffset? createdDateTime { get; set; }
            public Boolean? forceChangePinNextSignIn { get; set; }
            public DateTimeOffset? updatedDateTime { get; set; }
        }

        public class QrCodePinAuthenticationMethod
        {
            public Boolean? isUsable { get; set; }
            public string? methodUsabilityReason { get; set; }
            public DateTimeOffset? lastUsedDateTime { get; set; }
            public QrCode? standardQRCode { get; set; }
            public QrCode? temporaryQRCode { get; set; }
            public QrPin? pin { get; set; }
        }
#nullable disable

        public static async Task<QrCodePinAuthenticationMethod> GetQrCodeMethodOne()
        {
            QrCodePinAuthenticationMethod qrCodeMethod = null;
            string userId = Program.user.Id;
            string endpoint = string.Format(QR_CODE_METHOD_TEMPLATE, userId);

            if (null == Program.accessToken)
                Program.accessToken = await UserAuthentication.GetAccessToken();


            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseAddress);
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Program.accessToken.Value.Token.ToString());

                // Call the endpoint for the current user
                var response = await httpClient.GetAsync(baseAddress + endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    // You may want to handle errors more gracefully
                    throw new Exception($"Graph API call failed: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }

                MessageBox.Show(await response.Content.ReadAsStringAsync());

                try
                {
                    qrCodeMethod =
                    JsonSerializer.Deserialize<QrCodePinAuthenticationMethod>(await response.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                
                // Return the raw JSON response
                return qrCodeMethod;
            }


        }
    }
}


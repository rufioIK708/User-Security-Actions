using Azure.Identity;

using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Microsoft.Graph.Beta.Models.ODataErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace User_Security_Actions
{
    public record class MFAData()
    {
        public DateTime? CreatedDateTime {get; set;}
        public Dictionary<string, object>? AdditionalData { get; set; }
        public Dictionary<string, object>? BackingStore { get; set; }
        public string Id { get; set; }
        public string? OdataType { get; set; }
    }

    public class MFAExtras()
    {
        //to be able to call form1 properties
        //private static Form1 formInstance;
        

        


        //get MFA methods for a user
        public static async Task<AuthenticationMethodCollectionResponse> getUserMfaMethods()
        {
            var response = new AuthenticationMethodCollectionResponse();

            try
            {
                response = await Program.graphClient.Users[Program.user.Id].Authentication.Methods.GetAsync();
                return response;
            }
            catch (ODataError e)
            {
                MessageBox.Show("Error! getting MFA methods: " + e);
            }

            return response;
        }
    }
}

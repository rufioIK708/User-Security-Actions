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
#nullable enable
    public record class MFAData()
    {
        public DateTime? CreatedDateTime {get; set;}
        public Dictionary<string, object>? AdditionalData { get; set; }
        public Dictionary<string, object>? BackingStore { get; set; }
        public string? Id { get; set; }
        public string? OdataType { get; set; }
    }

    public record class RegData()
    {
        public string? id { get; set; }
        public string? userPrincipalName { get; set; }
        public string? userDisplayName { get; set; }
        public string? isAdmin { get; set; }
        public string? isSsprEnabled { get; set; }
        public string? isSsprCapable { get; set; }
        public string? isPasswordlessCapable { get; set; }
        public DateTime? lastUpdatedDateTime { get; set; }
        public string[]? methodsRegistered { get; set; }
        public string? defaultMfaMethod { get; set; }
        public bool isSystemPreferredAuthenticationMethodEnabled { get; set; }
        public string? systemPreferredAuthenticationMethod { get; set; }
        public string? userPreferrredMethodForSecondaryAuthentication { get; set; }
        public string? userType { get; set; }

    }

    public record class UserRegDetails()
    {
        public string? id { get; set; }
        public string? userPrincipalName { get; set; }
        public string? userDisplayName { get; set; }
        public string? isAdmin { get; set; }
        public string? isSsprEnabled { get; set; }
        public string? isSsprCapable { get; set; }
        public string? isPasswordlessCapable { get; set; }
        public DateTime? lastUpdatedDateTime { get; set; }
        public string[]? methodsRegistered { get; set; }
        public string? defaultMfaMethod { get; set; }
        public bool isSystemPreferredAuthenticationMethodEnabled { get; set; }
        public string? systemPreferredAuthenticationMethod { get; set; }
        public string? userPreferrredMethodForSecondaryAuthentication { get; set; }
        public string? userType { get; set; }
    }

    public record class AssignedPlans()
    {
        public string[]? additionalData { get; set; }
        public DateTime? assignedDateTime { get; set; }
        public Dictionary <string, object>? backingStore { get; set; }
        public string? capabilityStatus { get; set; }
        public string? odataType { get; set; }
        public string? service { get; set; }
        public string? servicePlanId { get; set; }
    }

    public record class VerifiedDomains()
    {
        public string[]? additionalData { get; set; }
        public Dictionary<string, object>? backingStore { get; set; }
        public string[]? capabilities { get; set; }
        public bool? isDefualt { get; set; }
        public bool? isInitial { get; set; }
        public string? name { get; set; }
        public string? odataType { get; set; }
        public string? type { get; set; }
    }

    public record class DirectorySizeQuota()
    {
        public string? additionalData { get; set; }
        public Dictionary<string, object>? backingStore { get; set; }
        public string? odataType { get; set; }
        public int? total { get; set; }
        public int? used { get; set; }
    }

    public record class PrivacyProfile()
    {
        public string? additionalData { get; set; }
        public Dictionary<string, object>? backingStore { get; set; }
        public string? contactEmail { get; set; }
        public string? odataType { get; set; }
        public string? statementUrl { get; set; }
    }

    public record class ProvisionedPlans()
    {
        public string? additionalData { get; set; }
        public Dictionary<string, object>? backingStore { get; set; }
        public string? capabilityStatus { get; set; }
        public string? odataType { get; set; }
        public string? provisioningStatus { get; set; }
        public string? service { get; set; }
    }

    public record class OrganizationInfo()
    {
        public AssignedPlans[]? assignedPlans { get; set; }
        public string? branding { get; set; }
        public string[]? businessPhones { get; set; }
        public string? certificateBasedAuthConfiguration { get; set; }
        public string? certificateConnectorString { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? countryLetterCode { get; set; }
        public DateTime? createdDateTime { get; set; }
        public string? defaultUsageLocation { get; set; }
        public DirectorySizeQuota? directorySizeQuota { get; set; }
        public string? displayName { get; set; }
        public string? extensions { get; set; }
        public bool? isMultipleDtataLocationsForServicesEnabled { get; set; }
        public string[]? marketingNotificationEmails { get; set; }
        public string? mobileDeviceManagementAuthority { get; set; }
        public DateTime? onPremisesLastPasswordSyncDateTime { get; set; }
        public DateTime? onPremisesLastSyncDateTime { get; set; }
        public bool? onPremisesSyncEnabled { get; set; }
        public string? partnerInformation { get; set; }
        public string? partnerTenantType { get; set; }
        public string? postalCode { get; set; }
        public string? preferredLanguage { get; set; }  
        public PrivacyProfile? privacyProfile { get; set; }
        public ProvisionedPlans[]? provisionedPlans { get; set; }
        public string[]? securityComplianceNotificationMails { get; set; }
        public string[]? securityComplianceNotificationPhones { get; set; }
        public string? settings { get; set; }
        public string? state { get; set; }
        public string? street { get; set; }
        public string[]? technicalNotificationMails { get; set; }
        public string? tenantType { get; set; }
        public VerifiedDomains[]? verifiedDomains { get; set; }
    }

    public record class TapAuthConfig()
    {
        public string? odataType { get; set; }
        public string? id { get; set; }
        public string? state { get; set; }
        public int? defaultLifetimeInMinutes { get; set; }
        public int? defaultLength { get; set; }
        public int? minimumLifetimeInMinutes { get; set; }
        public int? maximumLifetimeInMinutes { get; set; }
        public bool? isUsableOnce { get; set; }
        public Dictionary<string, object>? includeTargets { get; set; }
    }

#nullable disable
    public class MFAExtras()
    {
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

        //get MFA/SSPR registration details as well as others
        public static async Task<string> getRegistrationAuthData()
        {

            var result = new UserRegistrationDetails();

            //serialize options
            var options = new JsonSerializerOptions { WriteIndented = true };
            //string jsonString;
            string advDetails = "";

            //check if the tenant has a premium license.
            bool premium = await isTenantPremium();

            //confirm the licnese requirement is fulfilled
            if (premium)
            {
                try
                {
                    result = await Program.graphClient.Reports.AuthenticationMethods.UserRegistrationDetails[Program.user.Id].GetAsync();
                    //jsonString = JsonSerializer.Serialize(result, options);
                    //advDetails = jsonString;
                }
                catch (ODataError e)
                {
                    MessageBox.Show("Error! getting MFA data: " + e);
                }

                advDetails += $"\n"
                    + $"\nUser is an admin in Entra ID:            {result.IsAdmin}"
                    + $"\nUser is MFA registered:                  {result.IsMfaRegistered}"
                    + $"\nUser is MFA capable:                     {result.IsMfaCapable}"
                    + $"\nUser is SSPR registered:                 {result.IsSsprRegistered}"
                    + $"\nUser is SSPR enabled:                    {result.IsSsprEnabled}"
                    + $"\nUser is SSPR capable:                    {result.IsSsprCapable}"
                    + $"\nUser is passwordless capable:            {result.IsPasswordlessCapable}"
                    + $"\nEntra preferred method enabled:          {result.IsSystemPreferredAuthenticationMethodEnabled}";

                //add the next line (system preferred method) only if the tenant has a system preferred method
                if (true == result.IsSystemPreferredAuthenticationMethodEnabled)
                    advDetails += $"\nEntra preferred method:                  {result.SystemPreferredAuthenticationMethods.FirstOrDefault()}";

                advDetails += 
                      $"\nUser preferred method of Secondary Auth: {result.UserPreferredMethodForSecondaryAuthentication}"
                    + "\n"
                    + "\n";
                return advDetails;
            }
            else
                return "empty";
        }

        public static async Task<bool> isTenantPremium()
        {
            bool successful = false;
            var options = new JsonSerializerOptions { WriteIndented = true };

            try
            {
                var response = await Program.graphClient.Organization.GetAsync();
                var orgDetails = JsonSerializer.Serialize(response, options);
                
                if (orgDetails.Contains("AADPremium"))
                {
                    successful = true;
                }
                else
                {
                    successful = false;
                }
            }
            catch (ODataError e)
            {
                MessageBox.Show("Error! getting organization details: " + e);
            }

            return successful;
        }
    }
}

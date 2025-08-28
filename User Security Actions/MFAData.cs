using Azure.Identity;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Microsoft.Graph.Beta.Models.ODataErrors;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        public string? PhoneNumber { get; set; }
        public string? PhoneType { get; set; }
        public string? SmsSignInState { get; set; }
        public bool? isDefault { get; set; }
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

    public static class MyExtensions
    {
        //adding is default property to the AuthenticationMethod class
        public static bool isDefault(this AuthenticationMethod method, string defaultMethod)
        {
            bool isDefault = false;
            //check if the method is null
            if (method != null)
            { 
                switch (defaultMethod)
                {
                    case "Sms":
                        if (method.OdataType == Program.phoneAuthMethod)
                        {
                            //cast the method to PhoneAuthenticationMethod to access PhoneType
                            var phoneMethod = (PhoneAuthenticationMethod)method;
                            // check if the PhoneType is compatible with the default method
                            if (phoneMethod.PhoneType.ToString() == "Mobile")
                                isDefault = true;
                        }
                        break;
                    case "VoiceOffice":
                        if (method.OdataType == Program.phoneAuthMethod)
                        {
                            //cast the method to PhoneAuthenticationMethod to access PhoneType
                            var phoneMethod = (PhoneAuthenticationMethod)method;
                            // check if the PhoneType is compatible with the default method
                            if (phoneMethod.PhoneType.ToString() == "Office")
                                isDefault = true;
                        }
                        break;
                    case "VoiceMobile":
                        if (method.OdataType == Program.phoneAuthMethod)
                        {
                            //cast the method to PhoneAuthenticationMethod to access PhoneType
                            var phoneMethod = (PhoneAuthenticationMethod)method;
                            // check if the PhoneType is compatible with the default method
                            if (phoneMethod.PhoneType.ToString() == "Mobile")
                                isDefault = true;
                        }
                        break;
                    case "VoiceAlternateMobile":
                        if (method.OdataType == Program.phoneAuthMethod)
                        {
                            //cast the method to PhoneAuthenticationMethod to access PhoneType
                            var phoneMethod = (PhoneAuthenticationMethod)method;
                            // check if the PhoneType is compatible with the default method
                            if (phoneMethod.PhoneType.ToString() == "AlternateMobile")
                                isDefault = true;
                        }
                        break;
                    case "Push":
                        // check if the method type is compatible with the default method
                        if (method.OdataType == Program.mSAuthenticatorAuthMethod)
                        {
                            isDefault = true;
                        }
                        break;
                    case "Fido2":
                        //not an option for default method, leaving for future use.
                        break;
                    case "Oath":
                        //not an option for default method, leaving for future use.
                        break;
                    default:
                        break;
                }
            }

            return isDefault;
        }
    }


    public class MFAExtras()
    {
        //get MFA methods for a user
        public static async Task<List<AuthenticationMethod>> getUserMfaMethods()
        {
            var result = new List<AuthenticationMethod>();

            try
            {
                var response = await Program.graphClient.Users[Program.user.Id].Authentication.Methods.GetAsync();
                result = response.Value;
            }
            catch (ODataError e)
            {
                MessageBox.Show("Error! getting MFA methods: " + e);
            }

            return result;
        }

        public static void printMFAData(List<AuthenticationMethod> list, string defaultMethod)
        {
            string output = "";

            output += Environment.NewLine;

            //display the number of methods
            output += $"\nNumber of AuthMehtods:  {list.Count}";

            //loop through the list of MFA methods
            for (int i = 0; i < list.Count; i++)
            {
                if (null != list[i].OdataType)
                {
                    //Replace the OdataType with a more readable string - find out which method we have and then
                    //  determine if it matches with the method found in userPreferredMethodForSecondaryAuthentication.
                    //  Not all methods will have a lavel. Options are Push, Oath, VoiceMobile, VoiceAlternametMobile,
                    //  VoiceOffice, Sms, unknownFutureValure. Oath will not have a default value as any of multiple Oath
                    //  methods can be used, just the Oath screen will be presented to the user.
                    switch (list[i])
                    {
                        case PlatformCredentialAuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.
                            var platformMethod = (PlatformCredentialAuthenticationMethod)list[i];

                            //not an option as a default secondary method

                            output += $"\nType of Method   : Platform Credential";

                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";

                            output += $"\nDisplay Name     : {platformMethod.DisplayName}";
                            output += $"\nPlatform Type    : {platformMethod.Platform}";
                            output += $"\nKey Strength     : {platformMethod.KeyStrength}";
                            break;

                        case WindowsHelloForBusinessAuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.
                            var wfbMethod = (WindowsHelloForBusinessAuthenticationMethod)list[i];

                            //not an option as a default secondary method

                            output += $"\nType of Method   : Windows Hello for Business";

                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";

                            output += $"\nDisplay Name     : {wfbMethod.DisplayName}";
                            output += $"\nPlatform Type    : {wfbMethod.Device}";
                            output += $"\nKey Strength     : {wfbMethod.KeyStrength}";
                            break;

                        case TemporaryAccessPassAuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.
                            var tapMethod = (TemporaryAccessPassAuthenticationMethod)list[i];

                            //not an option as a default secondary method

                            output += $"\nType of Method   : Temporary Access Pass";

                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";

                            output += $"\nStart Date       : {tapMethod.StartDateTime}";
                            output += $"\nLifetime         : {tapMethod.LifetimeInMinutes}";
                            output += $"\nReusable         : {tapMethod.IsUsableOnce}";
                            output += $"\nTemp Access Pass : {tapMethod.TemporaryAccessPass}";
                            break;

                        case SoftwareOathAuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.

                            //check for default method type. Able to be used for Oath
                            if ("Oath" == defaultMethod)
                                output += "\n\n **Usable as Default Method** ";

                            var softOathMethod = (SoftwareOathAuthenticationMethod)list[i];
                            output += $"\nType of Method  : Software Oath Token";

                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";

                            output += $"\nDisplay Name    : {softOathMethod.SecretKey}";
                            break;

                        case PhoneAuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.
                            var phoneMethod = (PhoneAuthenticationMethod)list[i];

                            //check for default method type
                            //  for phone method, Sms and VoiceMobile are for the primary mobile method.
                            //  Office and AltMobile phones have their own voice categories, and cannot be used for SMS
                            if (defaultMethod == "Sms" && phoneMethod.PhoneType.ToString() == "Mobile")
                                output += "\n\n **Default Method** ";
                            else if (defaultMethod == "VoiceOffice" && phoneMethod.PhoneType.ToString() == "Office")
                                output += "\n\n **Default Method** ";
                            else if (defaultMethod == "VoiceMobile" && phoneMethod.PhoneType.ToString() == "Mobile")
                                output += "\n\n **Default Method** ";
                            else if (defaultMethod == "VoiceAlternateMobile" && phoneMethod.PhoneType.ToString() == "AlternateMobile")
                                output += "\n\n **Default Method** ";
                             
                            output += $"\nType of Method  : Phone Authentication";

                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";
                            
                            output += $"\nPhone number    : {phoneMethod.PhoneNumber}";
                            output += $"\nPhone type      : {phoneMethod.PhoneType}";
                            output += $"\nSMS SignInState : {phoneMethod.SmsSignInState}";
                            break;

                        case PasswordAuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.
                            var passwordAuthMethod = (PasswordAuthenticationMethod)list[i];

                            //not an option for secondary authentication

                            output += $"\nType of Method  : Password";

                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";

                            output += $"\nDisplay Name    : {passwordAuthMethod.Password}";
                            break;

                        case MicrosoftAuthenticatorAuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.
                            var mSAuthenticatorMethod = (MicrosoftAuthenticatorAuthenticationMethod)list[i];

                            //check for default method type.
                            if ("Push" == defaultMethod)
                                output += "\n\n **Useable as Default Method** ";

                            output += $"\nType of Method  : Microsoft Authenticator";

                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";

                            output += $"\nDisplay Name    : {mSAuthenticatorMethod.DisplayName}";
                            output += $"\nDevice Tag      : {mSAuthenticatorMethod.DeviceTag}";
                            output += $"\nDevice          : {mSAuthenticatorMethod.Device}";
                            output += $"\nApp Version     : {mSAuthenticatorMethod.PhoneAppVersion}";
                            break;

                        case HardwareOathAuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.
                            var hardOathAuthMethod = (HardwareOathAuthenticationMethod)list[i];

                            //check for default method type. This one changes the authentication experience
                            //  to use the Oath token screen. At that point, any Oath method can be used.
                            if ("Oath" == defaultMethod)
                                output += "\n\n **Usable ass Default Method** ";
                            output += $"\nType of Method : Hardware Oath Token";

                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";

                            output += $"\nDevice Name    : {hardOathAuthMethod.Device}";
                            break;

                        case Fido2AuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.
                            var fido2Method = (Fido2AuthenticationMethod)list[i];

                            //not an option for default method, leaving for future use.
                            //if ("Fido2" == defaultMethod)
                            //    output += "\n\n **Default Method** ";

                            output +=$"\nType of Method  : Fido2 Passkey";

                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";

                            output +=$"\nDisplay Name    : {fido2Method.DisplayName}";
                            output +=$"\nAAGuid          : {fido2Method.AaGuid}";
                            output +=$"\nDevice          : {fido2Method.Model}";
                            break;

                        case EmailAuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.
                            var emailAuthMethod = (EmailAuthenticationMethod)list[i];
                            
                            //not useable for secondary authentication
                            output += $"\nType of Method  : Alternate E-Mail";

                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";

                            output += $"\nEmail address   : {emailAuthMethod.EmailAddress}";
                            break;

                        case QrCodePinAuthenticationMethod:
                            //cast the array item into the actual object so that we have all the data available.
                            var qrCodePinAuthMethod = (QrCodePinAuthenticationMethod)list[i];
                            output += $"\nType of Method  : QR Code and PIN";
                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";
                            if (null != qrCodePinAuthMethod.StandardQRCode)
                            {
                                output += $"\n Standard QR Code : ";
                                output += $"\n  ID               : " + qrCodePinAuthMethod.StandardQRCode.Id;
                                output += $"\n  Created DateTime : " + qrCodePinAuthMethod.StandardQRCode.CreatedDateTime.Value.ToLocalTime();
                                output += $"\n  Start DateTime   : " + qrCodePinAuthMethod.StandardQRCode.StartDateTime.Value.ToLocalTime();
                                output += $"\n  Expiry DateTime  : " + qrCodePinAuthMethod.StandardQRCode.ExpireDateTime.Value.ToLocalTime();
                                output += $"\n  LasUsed DateTime : ";
                                if (null != qrCodePinAuthMethod.StandardQRCode.LastUsedDateTime)
                                    output += qrCodePinAuthMethod.StandardQRCode.LastUsedDateTime.Value.ToLocalTime();
                                else
                                    output += "NULL";
                            }
                            else
                                output += $"\n Standard QR Code : NULL";

                            if (null != qrCodePinAuthMethod.TemporaryQRCode)
                            {
                                output += $"\n Temporary QR Code : ";
                                output += $"\n  ID               : " + qrCodePinAuthMethod.TemporaryQRCode.Id;
                                output += $"\n  Created DateTime : " + qrCodePinAuthMethod.TemporaryQRCode.CreatedDateTime.Value.ToLocalTime();
                                output += $"\n  Start DateTime   : " + qrCodePinAuthMethod.TemporaryQRCode.StartDateTime.Value.ToLocalTime();
                                output += $"\n  Expiry DateTime  : " + qrCodePinAuthMethod.TemporaryQRCode.ExpireDateTime.Value.ToLocalTime();
                                output += $"\n  LasUsed DateTime : ";
                                if (null != qrCodePinAuthMethod.TemporaryQRCode.LastUsedDateTime)
                                    output += qrCodePinAuthMethod.TemporaryQRCode.LastUsedDateTime.Value.ToLocalTime();
                                else
                                    output += "NULL";
                            }
                            else
                                output += $"\n Temporary QR Code : NULL";

                            if (null != qrCodePinAuthMethod.Pin)
                            {
                                output += "\n QR Code PIN : ";
                                output += "\n  ID                : " + qrCodePinAuthMethod.Pin.Id;
                                output += "\n  Created DateTime  : " + qrCodePinAuthMethod.Pin.CreatedDateTime.Value.ToLocalTime();
                                output += "\n  Updated DateTime  : " + qrCodePinAuthMethod.Pin.UpdatedDateTime.Value.ToLocalTime();
                                output += "\n  Req Force Change  : " + qrCodePinAuthMethod.Pin.ForceChangePinNextSignIn.ToString();
                            }
                            break;
                        
                        //incase we get a new method type
                        default:
                            output +=$"\nType of Method : {list[i].OdataType}";
                            if (null != list[i].Id)
                                output += $"\nID              : {list[i].Id}";
                            if (null != list[i].CreatedDateTime)
                                output += $"\nCreatedDateTime : {list[i].CreatedDateTime.Value.ToLocalTime()}";
                            break;
                    }
                }

                /******************************************* ommitting for now, leaving for reference and possible future use
                if (null != item.AdditionalData)
                {
                    foreach (var entry in item.AdditionalData)
                    {
                        output +=$"Additional Data: {entry.Key}: {entry.Value}\n");
                    }
                }
                if (null != item.BackingStore)
                {
                    foreach (var entry in item.BackingStore)
                    {
                        output +=$"Backing Store: {entry.Key}: {entry.Value}\n");
                    }
                }
                */
                output +=Environment.NewLine;

               
            }

            Program.main_form.modifyRichTextBox(output);
        }
        //get MFA/SSPR registration details as well as others
        public static async Task<string> getRegistrationAuthData(bool print)
        { 
            //needed strings;
            string advDetails = "";
            string defaultMethod = "None";

            //check if the tenant has a premium license.
            bool premium = await isTenantPremium();

            //confirm the licnese requirement is fulfilled

            if (premium)
            {
                try
                {
                    var result = await Program.graphClient.Reports.AuthenticationMethods.UserRegistrationDetails[Program.user.Id].GetAsync();

                    //prepare the string to return
                    advDetails += $"\n*****************User Registration Data*****************\n"
                    + $"\nUser is an admin in Entra ID:            {result.IsAdmin}"
                    + $"\nUser is MFA registered:                  {result.IsMfaRegistered}"
                    + $"\nUser is MFA capable:                     {result.IsMfaCapable}"
                    + $"\nUser is SSPR registered:                 {result.IsSsprRegistered}"
                    + $"\nUser is SSPR enabled:                    {result.IsSsprEnabled}"
                    + $"\nUser is SSPR capable:                    {result.IsSsprCapable}"
                    + $"\nUser is passwordless capable:            {result.IsPasswordlessCapable}"
                    + $"\nEntra preferred method enabled:          {result.IsSystemPreferredAuthenticationMethodEnabled.ToString()}";

                    //add the next line (system preferred method) only if the tenant has a system preferred method
                    if (true == result.IsSystemPreferredAuthenticationMethodEnabled)
                        advDetails += $"\nEntra preferred method:                  {result.SystemPreferredAuthenticationMethods.FirstOrDefault()}";

                    advDetails +=
                          $"\nUser preferred method of Secondary Auth: {result.UserPreferredMethodForSecondaryAuthentication}"
                        + "\n"
                        + "\n";
                    
                    defaultMethod = result.UserPreferredMethodForSecondaryAuthentication.ToString() ?? "None";
                }
                catch (ODataError e)
                {
                    MessageBox.Show("Error! getting MFA data: " + e);
                }
            }
            else
            {
                //Message about additional features not available due to licensing
                advDetails = "\n\nThis tenant does not have a Premium Entra ID license." +
                    "\nSome advanced MFA features are not available.\n";

                try
                {
                    object value;
                    var result = await Program.graphClient.Users[Program.user.Id].Authentication.SignInPreferences.GetAsync();

                    //attempting to clean up the response and disply it
                    //display isSystemPreferredAuthenticationMethodEnabled state
                    advDetails += "\nEntra preferred method nabled          : " +
                        result.IsSystemPreferredAuthenticationMethodEnabled.ToString();

                    //display systemPreferredAuthenticationMethod value
                    advDetails += "\nEntra preferred method                 : ";
                    //systemPreferredAuthenticationMethod is always the last key in AdditionalData.
                    //  so we can use last, but needs a better way to do this.

                    //Need to check if the value is null and disply accordingly
                    if (result.AdditionalData.TryGetValue("systemPreferredAuthenticationMethod",out value))
                    { 
                        if (null == value)
                            advDetails += "NULL";
                        else
                            advDetails += value.ToString();
                    }
                    else
                        advDetails += "NULL";

                    //display userPreferredAuthenticationMethod value
                    advDetails += "\nUser preferred method of Secondary Auth: ";
                    //check if null and display accordingly
                    if (null != result.UserPreferredMethodForSecondaryAuthentication)
                        advDetails += result.UserPreferredMethodForSecondaryAuthentication.ToString();
                    else
                        advDetails += "NULL";

                    //set the default method for the user preferred method
                    defaultMethod = result.UserPreferredMethodForSecondaryAuthentication.ToString() ?? "None";
                }
                catch (ODataError err)
                {
                    MessageBox.Show(err.Message + "\nError getting SignInPreferences");
                }

                
            }

            if (print)
                Program.main_form.modifyRichTextBox(advDetails);

            //Form1.ActiveForm.Cursor = Cursors.Default;

            return defaultMethod;
        }

        public static async Task<bool> isTenantPremium()
        {
            bool successful = false;
            //var options = new JsonSerializerOptions { WriteIndented = true };

            try
            {
                var response = await Program.graphClient.Organization.GetAsync();
                //var orgDetails = JsonSerializer.Serialize(response, options);

                if (response.Value.ToString().Contains("AADPremium"))
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
                MessageBox.Show("Error! getting organization details: " + e.Message);
            }

            return successful;
        }

        public static async Task<bool> isMemberOfGroup(string groupId)
        {
            //default to false
            bool isMember = false;

            try
            {
                //get the transitive group membership of the user
                var response = await Program.graphClient.Users[Program.user.Id].TransitiveMemberOf.GetAsync();

                //check if the user is a member of the group in question
                foreach (var item in response.Value)
                {
                    
                    if (item.Id == groupId)
                    {
                        isMember = true;
                        break;
                    }
                }
            }
            catch (ODataError e)
            {
                MessageBox.Show("Error! checking group membership: " + e);
            }
            
            return isMember;
        }

        public static async Task<string> getMethodName(string Id)
        {
            string result = null;

            var list = await getUserMfaMethods();

            foreach (var item in list)
            {
                switch (item)
                {
                    case PlatformCredentialAuthenticationMethod:
                        result = "Platform Credential";
                        break;

                    case WindowsHelloForBusinessAuthenticationMethod:
                        result = "Windows Hello for Business";
                        break;

                    case TemporaryAccessPassAuthenticationMethod:
                        result = "Temporary Access Pass";
                        break;

                    case SoftwareOathAuthenticationMethod:
                        result = "Sofware Oath";
                        break;

                    case PhoneAuthenticationMethod:
                        var phoneMethod = item as PhoneAuthenticationMethod;
                        if (AuthenticationPhoneType.Mobile == phoneMethod.PhoneType)
                            result = "Mobile Phone";
                        else if (AuthenticationPhoneType.AlternateMobile == phoneMethod.PhoneType)
                            result = "Alternate Mobile Phone";
                        else if (AuthenticationPhoneType.Office == phoneMethod.PhoneType)
                            result = "Office Phone";
                        break;

                    case PasswordAuthenticationMethod:
                        result = "Password";
                        break;

                    case MicrosoftAuthenticatorAuthenticationMethod:
                        result = "Microsoft Authenticator";
                        break;

                    case HardwareOathAuthenticationMethod:
                        result = "Hardware Oath";
                        break;

                    case Fido2AuthenticationMethod:
                        result = "Fido2";
                        break;

                    case EmailAuthenticationMethod:
                        result = "E-mail";
                        break;

                    case QrCodePinAuthenticationMethod:
                        result = "QR Code/Pin";
                        break;

                    //incase we get a new method type
                    default:
                        result = item.OdataType;
                        break;
                }
            }
            return result;
        }
    }
}

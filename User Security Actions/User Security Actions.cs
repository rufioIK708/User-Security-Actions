using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Models;
using Microsoft.Graph.Beta.Models.ODataErrors;
using Microsoft.Graph.Beta.Users.Item.Authentication.Fido2Methods.CreationOptionsWithChallengeTimeoutInMinutes;
using User_Security_Actions;
using Microsoft.Graph.Beta.Communications.CallRecords.MicrosoftGraphCallRecordsGetPstnOnlineMeetingDialoutReportWithFromDateTimeWithToDateTime;


namespace User_Security_Actions
{


    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
            /* attempting to change the form based on the sign-in state, not working as expected*/
            if (Program.signedIn)
            {
                //admin is signed in and we can hide the sign-in button and show the rest of the form
                label1.Hide();
                signin.Hide();
                label1.Enabled = false;
                signin.Enabled = false;
                splitContainer1.Show();
                splitContainer1.Enabled = true;


                if (Program.validUser)
                {
                    //valid user has been selected, show user-based buttons

                    labelSelectedUser.Show();
                    labelSelectedUser.Text = "The selected user is: " + Program.user.DisplayName;
                    getUserMFA.Show();
                    getUserMFA.Enabled = true;
                    updateImmutableId.Show();
                    updateImmutableId.Enabled = true;
                    buttonToggleAccount.Show();
                    buttonToggleAccount.Enabled = true;
                    buttonResetPassword.Show();
                    buttonResetPassword.Enabled = true;
                    buttonAddMethod.Show();
                    buttonAddMethod.Enabled = true;
                    buttonResetMFA.Show();
                    buttonResetMFA.Enabled = true;
                    buttonRemoveMethod.Show();
                    buttonRemoveMethod.Enabled = true;
                    buttonRevokeSessions.Show();
                    buttonRevokeSessions.Enabled = true;

                    //specific button text based on account status
                    bool? enabled = Program.user.AccountEnabled;

                    if (true == enabled)
                        buttonToggleAccount.Text = "Disable Account";
                    else
                        buttonToggleAccount.Text = "Enable Account";
                }
                else
                {
                    //valid user has not been selected, do not show user-based buttons
                    labelSelectedUser.Hide();
                    labelSelectedUser.Text = "";
                    getAUser.Show();
                    getAUser.Enabled = true;
                    getUserMFA.Hide();
                    getUserMFA.Enabled = false;
                    updateImmutableId.Hide();
                    updateImmutableId.Enabled = false;
                    buttonToggleAccount.Hide();
                    buttonToggleAccount.Enabled = false;
                    buttonResetPassword.Hide();
                    buttonResetPassword.Enabled = false;
                    buttonAddMethod.Hide();
                    buttonAddMethod.Enabled = false;
                    buttonResetMFA.Hide();
                    buttonResetMFA.Enabled = false;
                    buttonRemoveMethod.Hide();
                    buttonRemoveMethod.Enabled = false;
                    buttonRevokeSessions.Hide();
                    buttonRevokeSessions.Enabled = false;
                }
            }
            else
            {
                //admin is not signed in and we need to show the sign-in button and hide the rest of the form
                label1.Show();
                signin.Show();
                label1.Enabled = true;
                signin.Enabled = true;
                splitContainer1.Hide();
                splitContainer1.Enabled = false;
            }

        }

        //function to print user details cleanly
        private void printUserStatus(User user)
        {
            //make some space
            modifyRichTextBox("\n");

            //confirm values queried are not null
            if (null != user.DisplayName)
                modifyRichTextBox("\nDisplayName:            " + user.DisplayName);
            if (null != user.UserPrincipalName)
                modifyRichTextBox("\nUserPrincipalName:      " + user.UserPrincipalName);
            if (null != user.Id)
                modifyRichTextBox("\nObjectId:               " + user.Id);
            if (null != user.AccountEnabled)
                modifyRichTextBox("\nAccount enabled:        " + user.AccountEnabled);
            if (null != user.OnPremisesImmutableId)
                modifyRichTextBox("\nOnPremisesImmutableId:  " + user.OnPremisesImmutableId);
            if (null != user.PasswordPolicies)
                modifyRichTextBox("\nPasswordPolicies:       " + user.PasswordPolicies);
            if (null != user.RefreshTokensValidFromDateTime)
                modifyRichTextBox("\nRefreshTokensValidFrom: " + user.RefreshTokensValidFromDateTime);

        }

        //function to get the user and return the user object
        private static async Task<User> getUser(string upn)
        {
            Form1.ActiveForm.Cursor = Cursors.WaitCursor;
            User user = new User();

            try
            {
                user = await Program.graphClient.Users[upn].GetAsync((requestConfiguration) =>
                {
                    requestConfiguration.QueryParameters.Select = new[] { "displayName", "onPremisesImmutableId", "userPrincipalName",
                                        "MemberOf", "AccountEnabled", "PasswordPolicies", "RefreshTokensValidFromDateTime" };
                });
            }
            catch (ODataError e)
            {
                MessageBox.Show($"Error: {e.Error}\n\nMessage: {e.Message}");
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("Error communicating with Graph."
                 + "\nError: " + e.Message);
            }

            Form1.ActiveForm.Cursor = Cursors.Default;
            return user;
        }

        public void modifyRichTextBox(string message)
        {
            displayBox.AppendText(message);
        }

        public async void printMFAData(List<MFAData> list)
        {
            modifyRichTextBox("\n");

            //display the number of methods
            modifyRichTextBox($"\nNumber of AuthMehtods:  {list.Count}\n");

            //loop through the list of MFA methods
            foreach (var item in list)
            {
                if (null != item.OdataType)
                {
                    //Replace the OdataType with a more readable string
                    switch (item.OdataType)
                    {
                        case Program.platformCredMethod:
                            modifyRichTextBox($"Type of Method : Platform Credential\n");
                            break;

                        case Program.wHFBAuthMethod:
                            modifyRichTextBox($"Type of Method : Windows Hello for Business\n");
                            break;

                        case Program.tAPAuthMethod:
                            modifyRichTextBox($"Type of Method : Temporary Access Pass\n");
                            break;

                        case Program.softOathAuthMethod:
                            modifyRichTextBox($"Type of Method : Software Oath Token\n");
                            break;

                        case Program.phoneAuthMethod:
                            modifyRichTextBox($"Type of Method : Phone Authentication\n");
                            try
                            {
                                var result = await Program.graphClient.Users[Program.user.Id].Authentication.
                                    PhoneMethods[item.Id].GetAsync();
                                modifyRichTextBox($"Phone number   : {result.PhoneNumber}\n");
                                modifyRichTextBox($"Phone type     : {result.PhoneType}\n");
                                modifyRichTextBox($"SMS SignInState: {result.SmsSignInState}\n");
                            }
                            catch (Exception err)
                            {
                                modifyRichTextBox("\nError getting phone method. Please try again.\n"
                                    + "\n" + err.Message);
                            }break;

                        case Program.passwordAuthMethod:
                            modifyRichTextBox($"Type of Method : Password\n");
                            break;

                        case Program.mSAuthenticatorAuthMethod:
                            modifyRichTextBox($"Type of Method : Microsoft Authenticator\n");
                            break;

                        case Program.hardOathAuthMethod:
                            modifyRichTextBox($"Type of Method : Hardware Oath Token\n");
                            break;

                        case Program.fido2AuthMethod:
                            modifyRichTextBox($"Type of Method : Fido2 Passkey\n");
                            break;

                        case Program.emailAuthMethod:
                            modifyRichTextBox($"Type of Method : Alternate E-Mail\n");
                            break;

                        //these are no longer listed but are still included just in case
                        case Program.phoneAppNotificationAuthMethhod:
                            modifyRichTextBox($"Type of Method : Phone App Notification\n");
                            break;

                        case Program.appPasswordAuthMethod:
                            modifyRichTextBox($"Type of Method : App Password\n");
                            break;

                        case Program.phoneAppOTPAuthMethod:
                            modifyRichTextBox($"Type of Method : Phone App OTP\n");
                            break;

                        case Program.passwordlessMSAuthenticatorMethod:
                            modifyRichTextBox($"Type of Method : Passwordless Microsoft Authenticator\n");
                            break;


                        //incase we get a new method type
                        default:
                            modifyRichTextBox($"Type of Method : {item.OdataType}\n");
                            break;
                    }
                }

                //check if the rest of the properties are null before attempting to display
                if (null != item.Id)
                    modifyRichTextBox($"ID             : {item.Id}\n");
                if (null != item.CreatedDateTime)
                    modifyRichTextBox($"CreatedDateTime: {item.CreatedDateTime}\n");
                if (null != item.AdditionalData)
                {
                    foreach (var entry in item.AdditionalData)
                    {
                        modifyRichTextBox($"Additional Data: {entry.Key}: {entry.Value}\n");
                    }
                }
                if (null != item.BackingStore)
                {
                    foreach (var entry in item.BackingStore)
                    {
                        modifyRichTextBox($"Backing Store: {entry.Key}: {entry.Value}\n");
                    }
                }

                modifyRichTextBox(Environment.NewLine);
            }
        }

        //method to get and print the authetication methods for a user
        public async Task<List<MFAData>> getAndPrintMFA(bool print)
        {
            

            if (await MFAExtras.isTenantPremium())
            {
                try
                {
               
                    //to verify the raw output
                    modifyRichTextBox("\n" + await MFAExtras.getRegistrationAuthData());
                }
                catch (ODataError err)
                {
                    MessageBox.Show(err.Message + "\nError getting advancded MFA details: confirm P1 license");
                }
            }

            

            //get the MFA methods for the user
            var response = await MFAExtras.getUserMfaMethods();

            //serialize the response
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(response.Value, options);

            //to verify the raw output
            //modifyRichTextBox("\n" + jsonString);

            //initialize a list of MFAData
            var methods = new List<MFAData>();

            //deserialize the JSON
            try
            {
                methods = JsonSerializer.Deserialize<List<MFAData>>(jsonString);
            }
            catch (JsonException e)
            {
                MessageBox.Show("Error converting JSON\n" +
                "error: " + e.Message + "\nadditional info : " + e.Data);
            }


            if (null != methods && print)
                printMFAData(methods);

            return methods;
        }

        //method to delete an MFA method
        public async Task deleteMethod(string id)
        {
            bool successful = false;
            var MFAList = await getAndPrintMFA(false);

            var method = MFAList.Find(x => x.Id == id);
            //verify the input & act: remove the method or no action
            foreach (var item in MFAList)
            {
                //find the Id provided in the ID of authentication methods
                if (item.Id == id)
                {
                    modifyRichTextBox($"\n \nRemoving method: {item.OdataType} with ID: {item.Id}\n");

                    switch (item.OdataType)
                    {
                        //WHFB method
                        case Program.wHFBAuthMethod:
                            try
                            {
                                await Program.graphClient.Users[Program.user.Id].Authentication.
                                    WindowsHelloForBusinessMethods[item.Id].DeleteAsync();
                                successful = true;
                            }
                            catch (ODataError err)
                            {
                                MessageBox.Show(err.Message + "\nError removing method: try again");
                            }
                            break;
                        //TAP method
                        case Program.tAPAuthMethod:
                            try
                            {
                                await Program.graphClient.Users[Program.user.Id].Authentication.
                                    TemporaryAccessPassMethods[item.Id].DeleteAsync();
                                successful = true;
                            }
                            catch (ODataError err)
                            {
                                MessageBox.Show(err.Message + "\nError removing method: try again");
                            }
                            break;
                        //software Oath method
                        case Program.softOathAuthMethod:
                            try
                            {
                                await Program.graphClient.Users[Program.user.Id].Authentication.
                                    SoftwareOathMethods[item.Id].DeleteAsync();
                                successful = true;
                            }
                            catch (ODataError err)
                            {
                                MessageBox.Show(err.Message + "\nError removing method: try again");
                            }
                            break;
                        //platform credential
                        case Program.platformCredMethod:
                            try
                            {
                                await Program.graphClient.Users[Program.user.Id].Authentication.
                                    PlatformCredentialMethods[item.Id].DeleteAsync();
                                successful = true;
                            }
                            catch (ODataError err)
                            {
                                MessageBox.Show(err.Message + "\nError removing method: try again");
                            }
                            break;
                        //Phone number-based methods ( mobile, alternamteMobile, & office)
                        case Program.phoneAuthMethod:
                            try
                            {
                                await Program.graphClient.Users[Program.user.Id].Authentication.
                                    PhoneMethods[item.Id].DeleteAsync();
                            }
                            catch (ODataError err)
                            {
                                MessageBox.Show(err.Message + "\nError removing method: try again");
                            }
                            break;
                        //Password method - can't be done, let them know
                        case Program.passwordAuthMethod:
                            MessageBox.Show("You cannot delete passwords at this time.");
                            break;
                        //MS Authenticator app method
                        case "#microsoft.graph.microsoftAuthenticatorAuthenticationMethod":
                            try
                            {
                                await Program.graphClient.Users[Program.user.Id].Authentication.
                                    MicrosoftAuthenticatorMethods[item.Id].DeleteAsync();
                                successful = true;
                            }
                            catch (ODataError err)
                            {
                                MessageBox.Show(err.Message + "\nError removing method: try again");
                            }
                            break;
                        //Hardware Oath token method
                        case Program.hardOathAuthMethod:
                            try
                            {
                                await Program.graphClient.Users[Program.user.Id].Authentication.
                                    HardwareOathMethods[item.Id].DeleteAsync();
                                successful = true;
                            }
                            catch (ODataError err)
                            {
                                MessageBox.Show(err.Message + "\nError removing method: try again");
                            }
                            break;
                        //Fido 2 Method
                        case Program.fido2AuthMethod:
                            try
                            {
                                await Program.graphClient.Users[Program.user.Id].Authentication.
                                    Fido2Methods[item.Id].DeleteAsync();
                                successful = true;
                            }
                            catch (ODataError err)
                            {
                                MessageBox.Show(err.Message + "\nError removing method: try again");
                            }
                            break;
                        //Alternate email method
                        case Program.emailAuthMethod:
                            try
                            {
                                await Program.graphClient.Users[Program.user.Id].Authentication.
                                    EmailMethods[item.Id].DeleteAsync();
                                successful = true;
                            }
                            catch (ODataError err)
                            {
                                MessageBox.Show(err.Message + "\nError removing method: try again");
                            }
                            break;
                        //this is old and shouldn't be used but it's here for completeness
                        case Program.phoneAppNotificationAuthMethhod:
                            try
                            {
                                await Program.graphClient.Users[Program.user.Id].Authentication.
                                    MicrosoftAuthenticatorMethods[item.Id].DeleteAsync();
                                successful = true;
                            }
                            catch (ODataError err)
                            {
                                MessageBox.Show(err.Message + "\nError removing method: try again");
                            }
                            break;

                        case Program.appPasswordAuthMethod:
                            MessageBox.Show("Cannot remove App Passwords from here. My apologies.\n"
                                + "Please do so from the Entra portal");
                            break;

                        default:
                            //we shouldn't get here, the list is all inclusive... not sure what to do here...
                            //throw an exception? error message?
                            break;
                    }


                }
                    

                if (successful)
                {
                    // if we leave the loop, no match was found
                    MessageBox.Show("Method " + Program.input + " deleted.");
                }
            }
        }
        private async void getUserMFA_Click(object sender, EventArgs e)
        {
            modifyRichTextBox("\n\nGetting MFA methods for user: " + Program.user.DisplayName + "\n\n");
            await getAndPrintMFA(true);

            //get registration info for the user
            //string regData = await MFAExtras.getRegistrationAuthData();
            //modifyRichTextBox("\n\n================REGISTRATION DATA=======================\n\n" + regData);

        }

        private async void signin_Click(object sender, EventArgs e)
        {
            bool successful = false;

            Program.token = UserAuthentication.SignInUserAndGetToken(Program.scopes, Program.ClientId);
            Program.graphClient = new GraphServiceClient(Program.token, Program.scopes);

            try
            {

                User signedInUser = await Program.graphClient.Me.GetAsync();
                successful = true;
                modifyRichTextBox(", you signed in as: ");
                printUserStatus(signedInUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.HelpLink + "\nSign-in failed.");
            }

            if (successful)
            {
                Program.signedIn = true;
                //MessageBox.Show("Sign-in successful. State is: " + Program.signedIn);
            }
            else
            {
                //MessageBox.Show("Sign-in failed.");
                Program.signedIn = false;
            }

            //refresh the form
            Form1_Load(sender, e);

        }

        //get and hold a user
        private async void getAUser_Click(object sender, EventArgs e)
        {
            //if we decide to clear the box
            //richTextBox1.Clear();

            Program.admin = await Program.graphClient.Me.GetAsync();
            Program.user = null;
            bool result = false;
            new textInput("Please enter the ObjectID/UPN of a user", "Select a User", false).ShowDialog();

            //try to get the user
            try
            {
                Program.user = await getUser(Program.input);

            }
            catch (ODataError err)
            {
                MessageBox.Show(err.Error + "\nError getting user: try again"
                    + "\nResult is: " + result.ToString());
                result = false;
                //throw err;

            }

            if (null != Program.user.UserPrincipalName)
                result = true;

            if (Program.admin.Id == Program.user.Id)
            {
                MessageBox.Show("This app is intended to make administrator changes." +
                    "\nYou cannot make admnistrator changes on your own account." +
                    "\nPlease select a different user");
                result = false;
            }

            if (result)
            {
                modifyRichTextBox("\n\nUser found: ");
                printUserStatus(Program.user);
                //getAndPrintMFA(app, upn);
                labelSelectedUser.Text = "The selected user is: " + Program.user.DisplayName;
            }
            else
                modifyRichTextBox("\n\nUser not found!");

            //update environment var with user status
            Program.validUser = result;

            //refresh the form
            Form1_Load(sender, e);
        }

        private async void updateImmutableId_Click(object sender, EventArgs e)
        {
            //the active user is stored in Program.user and is accessible here

            //label to show the immutableID
            string labelMessage = "The current ImmutableID for " + Program.user.DisplayName + " is:\n" + Program.user.OnPremisesImmutableId;
            labelMessage += "\n\nPlease enter the new ImmutableID for " + Program.user.DisplayName;
            labelMessage += "\nbelow or \"Clear\" to set it to null, or \"Cancel\" to stop.";

            //show a dialog box to get the new immutableID
            new textInput(labelMessage, "Modify ImmutableId", false).ShowDialog();

            //verify the input & act: update the immutableID, clear it, or no action
            switch (Program.input.ToUpper())
            {
                case ("CLEAR"):
                    Program.user.OnPremisesImmutableId = null;
                    break;
                case ("CANCEL"):
                    break;
                default:
                    Program.user.OnPremisesImmutableId = Program.input;
                    break;
            }

            try
            {
                await Program.graphClient.Users[Program.user.Id].PatchAsync(Program.user);
            }
            catch (ODataError err)
            {
                MessageBox.Show(err.Error + "\nError updating user: try again");
            }

            //Get the updated user
            Program.user = await getUser(Program.user.UserPrincipalName);
            printUserStatus(Program.user);
        }

        private async void buttonResetPassword_Click(object sender, EventArgs e)
        {
            //the active user is stored in Program.user and is accessible here

            //need to get the authentication methods and isolate the password method & its ID
            var response = await MFAExtras.getUserMfaMethods();

            //serialize the response
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(response.Value, options);

            //to verify the raw output
            //modifyRichTextBox("\n" + jsonString);

            //initialize a list of MFAData
            var methods = new List<MFAData>();

            //deserialize the JSON
            try
            {
                methods = JsonSerializer.Deserialize<List<MFAData>>(jsonString);
            }
            catch (JsonException err)
            {
                MessageBox.Show("Error converting JSON\n" +
                "error: " + err.Message + "\nadditional info : " + err.Data);
            }

            //isolate the password method
            MFAData passwordMethod = new MFAData();

            foreach (MFAData authenticationMethod in methods) {
                if (authenticationMethod.OdataType == "#microsoft.graph.passwordAuthenticationMethod")
                {
                    passwordMethod = authenticationMethod;
                    break;
                }
            }
            //label to show the message
            string labelMessage = "Reset the password for: " + Program.user.DisplayName;
            labelMessage += "\n\nPlease enter the new password, " +
                "\nor \"System\" to let Entra generate one for you, " +
                "\nor\"Cancel\" to stop.";
            string resetMessage = "\nThe user will have to use this \npassword to reset their password on \nnext login.";
            new textInput(labelMessage, "Reset Password", false).ShowDialog();

            //verify the input & act: reset the password or no action
            switch (Program.input.ToUpper())
            {
                case ("CANCEL"):
                    break;
                case ("SYSTEM"):
                    //reset the password - let the system generate a password and display it
                    try
                    {
                        //reset the password
                        var requestBody = new Microsoft.Graph.Beta.Users.Item.Authentication.Methods.Item.ResetPassword.ResetPasswordPostRequestBody
                        {
                        };
                        var result = await Program.graphClient.Users[Program.user.Id].Authentication.Methods[passwordMethod.Id].
                            ResetPassword.PostAsync(requestBody);
                        //display the new password
                        new textInput(resetMessage, "Password Reset Complete", result.NewPassword).ShowDialog();
                    }
                    catch (ODataError err)
                    {
                        MessageBox.Show(err.Error + "\nError resetting password: try again");
                    }
                   
                    break;
                case (""):
                    MessageBox.Show("No password entered. Please try again.");
                    break;
                default:
                    //reset the password
                    try
                    {
                        await Program.graphClient.Users[Program.user.Id].Authentication.Methods[passwordMethod.Id].
                            ResetPassword.PostAsync(new
                                Microsoft.Graph.Beta.Users.Item.Authentication.Methods.
                                Item.ResetPassword.ResetPasswordPostRequestBody
                            {
                                NewPassword = Program.input
                            });
                    }
                    catch (ODataError err)
                    {
                        MessageBox.Show(err.Error + "\nError resetting password: try again");
                    }

                    MessageBox.Show("Password reset for: " + Program.user.DisplayName + " is complete!");
                    break;
            }
        }

        private async void buttonToggleAccount_Click(object sender, EventArgs e)
        {
            Program.user.AccountEnabled = !Program.user.AccountEnabled;

            try
            {
                await Program.graphClient.Users[Program.user.Id].PatchAsync(Program.user);
            }
            catch (ODataError err)
            {
                MessageBox.Show(err.Error + "\nError updating user: try again");
            }

            //Get the updated user and re-print the status
            Program.user = await getUser(Program.user.UserPrincipalName);
            printUserStatus(Program.user);
            MessageBox.Show("Account status updated for: " + Program.user.DisplayName
                + "\nAccount enabled: " + Program.user.AccountEnabled);
            //reload the form so buttons update if necessary
            Form1_Load(sender, e);
        }

        private async void buttonAddMethod_Click(object sender, EventArgs e)
        {
            //the active user is stored in Program.user and is accessible here

            //label to show the message in the text box
            string labelMessage = "Please select Phone or Email.";
            new textInput(labelMessage, "Add Authentication Method", true).ShowDialog();

            //trim the input
            string input = Program.input.Trim();

            //check if email method and add.
            if (Program.methodType == MethodType.Email)
            {
                var requestBody = new EmailAuthenticationMethod
                {
                    EmailAddress = input,
                };
                try
                {
                    var result = await Program.graphClient.Users[Program.user.Id].
                        Authentication.EmailMethods.PostAsync(requestBody);
                    MessageBox.Show("Email method saved.\nMethod ID: " + result.Id);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error adding phone method. Please try again."
                        + "\nError Message: " + err.Message);
                }
            }
            else
            {
                switch (Program.phoneOptions)
                {
                    case PhoneOption.Mobile:
                        //add the phone method
                        var requestBody = new PhoneAuthenticationMethod
                        {
                            PhoneNumber = input,
                            PhoneType = AuthenticationPhoneType.Mobile,
                        };

                        //submit add request
                        try
                        {
                            var result = await Program.graphClient.Users[Program.user.Id].
                                Authentication.PhoneMethods.PostAsync(requestBody);
                            MessageBox.Show(result.Id + "\n" + result.PhoneNumber + "\n" + result.CreatedDateTime);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Error adding phone method. Please try again."
                                + "\n" + err.Message);
                        }
                        break;

                    case PhoneOption.AlternateMobile:
                        //add the alternate mobile method
                        var altRequestBody = new PhoneAuthenticationMethod
                        {
                            PhoneNumber = input,
                            PhoneType = AuthenticationPhoneType.AlternateMobile,
                        };
                        //submit add request
                        try
                        {
                            var result = await Program.graphClient.Users[Program.user.Id].
                                Authentication.PhoneMethods.PostAsync(altRequestBody);
                            MessageBox.Show(result.Id + "\n" + result.PhoneNumber + "\n" + result.CreatedDateTime);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Error adding alternate mobile method. Please try again."
                                + "\n" + err.Message);
                        }
                        break;

                    case PhoneOption.Office:
                        //add the office method
                        var officeRequestBody = new PhoneAuthenticationMethod
                        {
                            PhoneNumber = input,
                            PhoneType = AuthenticationPhoneType.Office,
                        };
                        //submit add request
                        try
                        {

                            var result = await Program.graphClient.Users[Program.user.Id].
                                Authentication.PhoneMethods.PostAsync(officeRequestBody);
                            MessageBox.Show(result.Id + "\n" + result.PhoneNumber + "\n" + result.CreatedDateTime);
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("Error adding office method. Please try again."
                                + "\n" + err.Message);
                        }
                        break;
                }
            }
        }

        private async void buttonResetMFA_Click(object sender, EventArgs e)
        {
            //the active user is stored in Program.user and is accessible here

            //there are two methods to reset MFA, either by removing all methods or callin
            //the reset traditional authentication methods endpoint

            ///////////////////////////////////////////////////
            //// resetting via traditional authenticaiton endpoint
            ///////////////////////////////////////////////////
            
            /****** its not working
            try
            {
                var response = Program.graphClient.
                "https://graph.microsoft.com/beta/users/" + Program.user.Id +
                "/authentication/methods/resetTraditionalAuthenticationMethods").
                ToPostRequestInformation(new AuthenticationMethod { });

                
                modifyRichTextBox(response.Content.ToString());
            }
            catch (ODataError err)
            {
                MessageBox.Show(err.Error + "\nError resetting MFA: try again");
            }
            **************/

            ///////////////////////////////////////////////////
            //// resetting via removing all methods
            ///////////////////////////////////////////////////

            //gather all methods, then remove only the MFA ones (exclude password, email, and security questions.)
            
            //get all the methods and store
            var response = await getAndPrintMFA(true);
            string defaultMethod = "";
            string[] phoneMethods = { };
            int count = 0;

            //make sure the output isnt null (it should never be as everyone should always have
            //at least a password)
            if (response == null)
            {
                //throw an exception if the response is null
                MessageBox.Show("Error! No methods found. Please try again.");
            }
            else
            {
                //////////////////
                //// the simpler method - remove all methods 3 times.
                //////////////////

                //loop through the methods and remove all but the password, email, and security questions
                for (int x = 0; x < 3; x++)
                {
                    for (int i = 0; i < response.Count; i++)
                    //if the method is not a password, email, or security question, remove it.
                    if (response[i].OdataType != Program.passwordAuthMethod &&
                        response[i].OdataType != Program.emailAuthMethod &&
                        response[i].OdataType != Program.appPasswordAuthMethod)
                    {
                        try
                        {
                            await deleteMethod(response[i].Id);
                        }
                        catch (ODataError err)
                        {
                                //do nothing as exceptions are expected.
                        }
                            
                    }
                }
                /******
                ///// the more complicated method
                ///
                //loop through the methods and remove all but the password, email, and security questions
                for (int i = 0; i < response.Count; i++)
                {
                    //if the method is not a password, email, or security question, remove it.
                    if (response[i].OdataType != Program.passwordAuthMethod &&
                        response[i].OdataType != Program.emailAuthMethod &&
                        response[i].OdataType != Program.appPasswordAuthMethod)
                    {
                        if (response[i].OdataType == Program.phoneAuthMethod)
                        {
                            phoneMethods[count] = response[i].Id;
                            count++;
                        }
                        else
                            await deleteMethod(response[i].Id);
                    }
                }
                //reset the default method
                await deleteMethod(defaultMethod);
                ******************************************************************/
            }



            MessageBox.Show("methods deleted");


        }

        private async void buttonRemoveMethod_Click(object sender, EventArgs e)
        {
            string labelMessage = "Please enter the ID of the method to remove.";
            labelMessage += "\nGet the methods first so you can see the IDs.";
            bool successful = false;
            new textInput(labelMessage, "Remove Authentication Method", false).ShowDialog();
            string input = Program.input;

            try
            {
                await deleteMethod(input);
                successful = true;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error removing method. Please try again."
                    + "\n" + err.Message);
            }

            if (successful)
            {                 
                //get the updated user
                Program.user = await getUser(Program.user.UserPrincipalName);
                printUserStatus(Program.user);
                MessageBox.Show("Method removed for: " + Program.user.DisplayName);
            }
            else
            {
                MessageBox.Show("Error removing method. Please try again.");
            }
        }

        private async void buttonRegisterFido2Passkey_Click(object sender, EventArgs e)
        {
            WebauthnCredentialCreationOptions response = new();
            try
            {
                response = await Program.graphClient.Users[Program.user.Id].
                    Authentication.Fido2Methods.CreationOptionsWithChallengeTimeoutInMinutes.
                    GetAsync(static (requestConfiguration) =>
                    {
                        requestConfiguration.QueryParameters.ChallengeTimeoutInMinutes = 10;
                    });
            }
            catch (Exception err)
            {
                MessageBox.Show("Error registering Fido2 Passkey. Please try again."
                    + "\n" + err.Message);
            }
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            //Program.graphClient.
        }

        private async void buttonFunctions_Click(object sender, EventArgs e)
        {
            var response = await Program.graphClient.Users[Program.user.Id].Authentication.SignInPreferences.GetAsync();
            modifyRichTextBox("\n" + response.IsSystemPreferredAuthenticationMethodEnabled.Value.ToString());
            modifyRichTextBox("\n" + response.UserPreferredMethodForSecondaryAuthentication.ToString());
            if(null != response.OdataType)
                modifyRichTextBox("\nOdata: " + response.OdataType.ToString());

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(response, options);

            modifyRichTextBox("\n" + jsonString);

            //var result = await Program.graphClient.Users[Program.user.Id].Authentication.

        }

        private async void buttonRevokeSessions_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await Program.graphClient.Users[Program.user.Id].RevokeSignInSessions.PostAsRevokeSignInSessionsPostResponseAsync();
                modifyRichTextBox("\n" + result.ToString());
            }
            catch (Exception err)
            {
                MessageBox.Show("Error revoking sessions. Please try again."
                    + "\n" + err.Message);
            }
        }

        private async void buttonAddTapMethod_Click(object sender, EventArgs e)
        {
            //1. Get and parse the TAP method policy
            try
            {
                //var response = await Program.graphClient.Policies.
                //    AuthenticationMethodsPolicy.GetAsync();


                var result = await Program.graphClient.Policies.
                    AuthenticationMethodsPolicy.AuthenticationMethodConfigurations["TemporaryAccessPass"].GetAsync();

                //serialize the response
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(result, options);
                MessageBox.Show("able to serialize first string");

                var test = Program.graphClient.Policies.AuthenticationMethodsPolicy.GetAsync();
                //string jsonStringAuthPolicy = JsonSerializer.Serialize(test.Result.AuthenticationMethodConfigurations, options);
                MessageBox.Show("able to serialize second string");

                if (0 == result.State)
                {
                    modifyRichTextBox("\nTAP method is enabled.");
                    modifyRichTextBox("\n" + jsonString);
                    foreach ( var item in test.Result.AuthenticationMethodConfigurations)
                    {
                        var jsonOut = JsonSerializer.Serialize(item.AdditionalData, options);
                        modifyRichTextBox($"\n{jsonOut}");
                    }
                    modifyRichTextBox("\n" + test.Result.AuthenticationMethodConfigurations[0]);
                }
                else
                {
                    MessageBox.Show("You do not have this method configured for your tenant. " +
                        "\nPlease configure it in the Entra Portal.");
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Error getting TAP method policy. Please try again."
                    + "\n" + err.Message);
            }
            //2. Modify the form to show the options
            //3. Get the input from the user
            //4. Generate the request from the input
            //5. Submit the request
            //6. Display the result
        
        }
    }
}


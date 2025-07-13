using Azure;
using Azure.Identity;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Communications.CallRecords.MicrosoftGraphCallRecordsGetPstnOnlineMeetingDialoutReportWithFromDateTimeWithToDateTime;
using Microsoft.Graph.Beta.Models;
//using Microsoft.Graph.Beta.Models.Networkaccess;
using Microsoft.Graph.Beta.Models.ODataErrors;
using Microsoft.Graph.Beta.Users.Item.Authentication.Fido2Methods.CreationOptionsWithChallengeTimeoutInMinutes;
using Microsoft.Kiota.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IdentityModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using User_Security_Actions;


namespace User_Security_Actions
{

    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
                getAUser.Show();
                getAUser.Enabled = true;


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

            //confirm values queried are not null before printing, print NULL if they are
            //DisplayName
            modifyRichTextBox("\nDisplayName:            ");
            if (null != user.DisplayName)
                modifyRichTextBox(user.DisplayName);
            else
                modifyRichTextBox("NULL");
            //UserPrincipalName
            modifyRichTextBox("\nUserPrincipalName:      ");
            if (null != user.UserPrincipalName)
                modifyRichTextBox(user.UserPrincipalName);
            else
                modifyRichTextBox("NULL");
            //UserID
            modifyRichTextBox("\nUserID:                 ");
            if (null != user.Id)
                modifyRichTextBox(user.Id);
            else
                modifyRichTextBox("NULL");
            //Account Enabled
            modifyRichTextBox("\nAccountEnabled:         ");
            if (null != user.AccountEnabled)
                modifyRichTextBox(user.AccountEnabled.ToString());
            else
                modifyRichTextBox("NULL");
            //OnPremises Immutable ID
            modifyRichTextBox("\nOnPremisesImmutableId:  ");
            if (null != user.OnPremisesImmutableId)
                modifyRichTextBox(user.OnPremisesImmutableId);
            else
                modifyRichTextBox("NULL");
            //Password Policies
            modifyRichTextBox("\nPasswordPolicies:       ");
            if (null != user.PasswordPolicies)
                modifyRichTextBox(  user.PasswordPolicies);
            else
                modifyRichTextBox("NULL");
            //Refresh Tokens Valid From Date Time
            modifyRichTextBox("\nRefreshTokensValidFrom: ");
            if (null != user.RefreshTokensValidFromDateTime)
                modifyRichTextBox(user.RefreshTokensValidFromDateTime.ToString());
            else
                modifyRichTextBox("NULL");



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
            displayBox.ScrollToCaret();
        }

        

        //method to get and print the authetication methods for a user
        public async Task<List<AuthenticationMethod>> getAndPrintMFA(bool print)
        {
            string defaultMethod;

            Form1.ActiveForm.Cursor = Cursors.WaitCursor;

            var methods = await MFAExtras.getUserMfaMethods();
            defaultMethod = await MFAExtras.getRegistrationAuthData(print);
            
            if (null != methods && print)
                MFAExtras.printMFAData(methods, defaultMethod);

            Form1.ActiveForm.Cursor = Cursors.Default;

            //return the list of methods
            return methods;
        }

        //method to delete an MFA method
        public async Task deleteMethod(string id)
        {
            bool successful = false;
            bool print = false;

            var MFAList = await getAndPrintMFA(print);

            var method = MFAList.Find(x => x.Id == id);
            //verify the input & act: remove the method or no action
        
            //find the Id provided in the ID of authentication methods
            if (method.Id == id)
            {
                modifyRichTextBox($"\n \nRemoving method: {method.OdataType} with ID: {method.Id}\n");

                switch (method.OdataType)
                {
                    //WHFB method
                    case Program.wHFBAuthMethod:
                        try
                        {
                            await Program.graphClient.Users[Program.user.Id].Authentication.
                                WindowsHelloForBusinessMethods[method.Id].DeleteAsync();
                            successful = true;
                        }
                        catch (ODataError err)
                        {
                            MessageBox.Show(err.Message + "\nError removing method: try again");
                            successful = false;
                        }
                        break;
                    //TAP method
                    case Program.tAPAuthMethod:
                        try
                        {
                            await Program.graphClient.Users[Program.user.Id].Authentication.
                                TemporaryAccessPassMethods[method.Id].DeleteAsync();
                            successful = true;
                        }
                        catch (ODataError err)
                        {
                            MessageBox.Show(err.Message + "\nError removing method: try again");
                            successful = false;
                        }
                        break;
                    //software Oath method
                    case Program.softOathAuthMethod:
                        try
                        {
                            await Program.graphClient.Users[Program.user.Id].Authentication.
                                SoftwareOathMethods[method.Id].DeleteAsync();
                            successful = true;
                        }
                        catch (ODataError err)
                        {
                            MessageBox.Show(err.Message + "\nError removing method: try again");
                            successful = false;
                        }
                        break;
                    //platform credential
                    case Program.platformCredMethod:
                        try
                        {
                            await Program.graphClient.Users[Program.user.Id].Authentication.
                                PlatformCredentialMethods[method.Id].DeleteAsync();
                            successful = true;
                        }
                        catch (ODataError err)
                        {
                            MessageBox.Show(err.Message + "\nError removing method: try again");
                            successful = false;
                        }
                        break;
                    //Phone number-based methods ( mobile, alternamteMobile, & office)
                    case Program.phoneAuthMethod:
                        try
                        {
                            await Program.graphClient.Users[Program.user.Id].Authentication.
                                PhoneMethods[method.Id].DeleteAsync();
                        }
                        catch (ODataError err)
                        {
                            MessageBox.Show(err.Message + "\nError removing method: try again");
                            successful = false;
                        }
                        break;
                    //Password method - can't be done, let them know
                    case Program.passwordAuthMethod:
                        MessageBox.Show("You cannot delete passwords at this time.");
                        break;
                    //MS Authenticator app method
                    case Program.mSAuthenticatorAuthMethod:
                        try
                        {
                            await Program.graphClient.Users[Program.user.Id].Authentication.
                                MicrosoftAuthenticatorMethods[method.Id].DeleteAsync();
                            successful = true;
                        }
                        catch (ODataError err)
                        {
                            MessageBox.Show(err.Message + "\nError removing method: try again");
                            successful = false;
                        }
                        break;
                    //Hardware Oath token method
                    case Program.hardOathAuthMethod:
                        try
                        {
                            await Program.graphClient.Users[Program.user.Id].Authentication.
                                HardwareOathMethods[method.Id].DeleteAsync();
                            successful = true;
                        }
                        catch (ODataError err)
                        {
                            MessageBox.Show(err.Message + "\nError removing method: try again");
                            successful = false;
                        }
                        break;
                    //Fido 2 Method
                    case Program.fido2AuthMethod:
                        try
                        {
                            await Program.graphClient.Users[Program.user.Id].Authentication.
                                Fido2Methods[method.Id].DeleteAsync();
                            successful = true;
                        }
                        catch (ODataError err)
                        {
                            MessageBox.Show(err.Message + "\nError removing method: try again");
                            successful = false;
                        }
                        break;
                    //Alternate email method
                    case Program.emailAuthMethod:
                        try
                        {
                            await Program.graphClient.Users[Program.user.Id].Authentication.
                                EmailMethods[method.Id].DeleteAsync();
                            successful = true;
                        }
                        catch (ODataError err)
                        {
                            MessageBox.Show(err.Message + "\nError removing method: try again");
                            successful = false;
                        }
                        break;
                    //this is old and shouldn't be used but it's here for completeness
                    case Program.phoneAppNotificationAuthMethhod:
                        try
                        {
                            await Program.graphClient.Users[Program.user.Id].Authentication.
                                MicrosoftAuthenticatorMethods[method.Id].DeleteAsync();
                            successful = true;
                        }
                        catch (ODataError err)
                        {
                            MessageBox.Show(err.Message + "\nError removing method: try again");
                            successful = false;
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
        private async void getUserMFA_Click(object sender, EventArgs e)
        {
            bool print = true;
            modifyRichTextBox("\n\nGetting MFA methods for user: " + Program.user.DisplayName + "\n\n");
            await getAndPrintMFA(print);

        }

        private async void signin_Click(object sender, EventArgs e)
        {
            //variable to check if the sign-in was successful
            bool successful = false;

            //initialize the token
            Program.token = UserAuthentication.SignInUserAndGetToken(Program.scopes, Program.ClientId);
            //initialize the Graph client
            Program.graphClient = new GraphServiceClient(Program.token, Program.scopes);

            //verify the user is signed in
            try
            {
                //get the signed in user
                User signedInUser = await Program.graphClient.Me.GetAsync();
                //set the tracking var to true
                successful = true;
                //add to the display box
                modifyRichTextBox(", you signed in as: ");
                //print the user status
                printUserStatus(signedInUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.HelpLink + "\nSign-in failed.");
            }

            //update the state of the application
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

            //copy input to new var
            var input = Program.input;
            Program.input = null;

            if (!Program.cancelled)
            {
                //try to get the user
                try
                {
                    Program.user = await getUser(input);

                }
                catch (ODataError err)
                {
                    MessageBox.Show(err.Error + "\nError getting user: try again"
                        + "\nResult is: " + result.ToString());
                    result = false;
                    //throw err;

                }

                //if UPN is not null, we successfully got a user
                if (null != Program.user.UserPrincipalName)
                    result = true;

                /**********************
                 * In Entra ID Web UI, you are unable to complete most of these actions on your own account.
                 * However, when calling Graph API, you are able to perform these actions on yourself.
                 * This check is not neccessary, we'll let the API let us know when we are doing something we
                 * shouldn't be, for now.

                if (Program.admin.Id == Program.user.Id)
                {
                    MessageBox.Show("This app is intended to make administrator changes." +
                        "\nYou cannot make admnistrator changes on your own account." +
                        "\nPlease select a different user");
                    result = false;
                }
                *******************************/

                //if user was found successfully
                if (result)
                {
                    modifyRichTextBox("\n\nUser found: ");
                    printUserStatus(Program.user);
                    //getAndPrintMFA(app, upn);
                    labelSelectedUser.Text = "The selected user is: " + Program.user.DisplayName;
                }
                //user was not found successfully
                else
                    modifyRichTextBox("\n\nUser not found!");

                //update environment var with user status
                Program.validUser = result;

                //refresh the form
                Form1_Load(sender, e);
            }
            else
            {
                //reset cancelled state
                Program.cancelled = false;
            }
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
            //var response = await MFAExtras.getUserMfaMethods();
            var methods = await MFAExtras.getUserMfaMethods();

            var passwordMethod = methods.Find(x => x.OdataType == Program.passwordAuthMethod);
            /*****
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

            foreach (var authenticationMethod in methods)
            {
                if (authenticationMethod.OdataType == "#microsoft.graph.passwordAuthenticationMethod")
                {
                    passwordMethod = authenticationMethod;
                    break;
                }
            }
            *****/

            //label to show the message
            string labelMessage = "Reset the password for: " + Program.user.DisplayName;
            labelMessage += "\n\nPlease enter the new password, " +
                "\nor \"System\" to let Entra generate one for you, " +
                "\nor\"Cancel\" to stop.";
            string resetMessage = "\nThe user will have to use this \npassword to reset their password on \nnext login.";
            new textInput(labelMessage, "Reset Password", false).ShowDialog();

            string input = Program.input.Trim();
            Program.input = null;
            
            //verify the input & act: reset the password or no action
            switch (input.ToUpper())
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

            //check if the user cancelled
            if (!Program.cancelled)
            {
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
            else
            {
                //don't do anything and reset cancelled state
                Program.cancelled = false;
            }
        }
       

        private async void buttonResetMFA_Click(object sender, EventArgs e)
        {
            bool print = false;
            //the active user is stored in Program.user and is accessible here

            //there are two methods to reset MFA, either by removing all methods or callin
            //the reset traditional authentication methods endpoint

            ///////////////////////////////////////////////////
            //// resetting via traditional authenticaiton endpoint
            ///////////////////////////////////////////////////

            /****** its not working
            try
            {++++++++++++++++++++++++
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
            var response = await getAndPrintMFA(print);
            string defaultMethod;
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
                                //MessageBox.Show(err.Error + $"\nError removing method: {err.Message}\n {err.Data}");
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
                        if (response[i].isDefault(await MFAExtras.getRegistrationAuthData(false)))
                        {
                            defaultMethod = response[i].Id;
                            count++;
                        }
                        else
                            await deleteMethod(response[i].Id);
                    }
                }
                //reset the default method
                await deleteMethod(defaultMethod);
                //**************************************/
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
                        requestConfiguration.QueryParameters.ChallengeTimeoutInMinutes = 5;
                    });
            }
            catch (Exception err)
            {
                MessageBox.Show("Error registering Fido2 Passkey. Please try again."
                    + "\n" + err.InnerException);
            }
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {

            /* - the list of static variables to use as reference for what needs to be cleared.
             *         public static InteractiveBrowserCredential token;
             *         public static GraphServiceClient graphClient; 
             *         // - - string to read input from users
             *         public static string input;

             *         // - - bools to track the state of the app
             *         public static bool signedIn = false;
             *         public static bool validUser = false;
             *         // - - - might be needed to cleaner password reset alternative in the future
             *         public static bool existPhoneMethods = false;
                        // - - users to store the user and admin details
                        public static Microsoft.Graph.Beta.Models.User user;
                        public static Microsoft.Graph.Beta.Models.User admin;
                        // enumerators for phone method storage when we create them.  
                        public static PhoneOption phoneOptions;
                        public static MethodType methodType;
                        // - - - TAP method details
                        public static DateTime tapStart;
                        public static int tapDurationInMinutes;
                        public static bool tapReusable;
            */
            //Program.graphClient.
            Program.token = null;
            Program.graphClient = null;
            Program.input = null;
            Program.signedIn = false;
            Program.validUser = false;
            Program.existPhoneMethods = false;
            Program.user = null;
            Program.admin = null;

            Form1_Load(sender, e);
        }

        private async void buttonFunctions_Click(object sender, EventArgs e)
        {
            var response = await Program.graphClient.Users[Program.user.Id].Authentication.Methods.GetAsync();
            var methods = response.Value;

            for(int i = 0; i < methods.Count; i++)
            {
                if( Program.mSAuthenticatorAuthMethod == methods[i].OdataType)
                {
                    //get the method ID
                    MicrosoftAuthenticatorAuthenticationMethod item = (MicrosoftAuthenticatorAuthenticationMethod)methods[i];
                    
                }
                else if (Program.fido2AuthMethod == methods[i].OdataType)
                {
                    //get the method ID
                    Fido2AuthenticationMethod item = (Fido2AuthenticationMethod)methods[i];
                    //do something with the item
                }
                else if (Program.hardOathAuthMethod == methods[i].OdataType)
                {
                    //get the method ID
                    HardwareOathAuthenticationMethod item = (HardwareOathAuthenticationMethod)methods[i];
                    //do something with the item
                }
                else if (Program.softOathAuthMethod == methods[i].OdataType)
                {
                    //get the method ID
                    SoftwareOathAuthenticationMethod item = (SoftwareOathAuthenticationMethod)methods[i];
                    //do something with the item
                }
                else if (Program.phoneAuthMethod == methods[i].OdataType)
                {
                    //get the method ID
                    PhoneAuthenticationMethod item = (PhoneAuthenticationMethod)methods[i];
                    //do something with the item
                }
                else if (Program.passwordAuthMethod == methods[i].OdataType)
                {
                    //get the method ID
                    PasswordAuthenticationMethod item = (PasswordAuthenticationMethod)methods[i];
                    //do something with the item
                }
                else if (Program.tAPAuthMethod == methods[i].OdataType)
                {
                    //get the method ID
                    TemporaryAccessPassAuthenticationMethod item = (TemporaryAccessPassAuthenticationMethod)methods[i];
                    //do something with the item
                }
                else if (Program.platformCredMethod == methods[i].OdataType)
                {
                    //get the method ID
                    PlatformCredentialAuthenticationMethod item = (PlatformCredentialAuthenticationMethod)methods[i];
                    //do something with the item
                }
                else if (Program.wHFBAuthMethod == methods[i].OdataType)
                {
                    //get the method ID
                    WindowsHelloForBusinessAuthenticationMethod item = (WindowsHelloForBusinessAuthenticationMethod)methods[i];
                    //do something with the item
                }
                else if (Program.emailAuthMethod == methods[i].OdataType)
                {
                    //get the method ID
                    EmailAuthenticationMethod item = (EmailAuthenticationMethod)methods[i];
                    //do something with the item
                }
                else
                {
                    //unknown method type, do nothing or log it
                }
            }


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

                //get the TAP method policy
                //unable to get the values for defaultlifetimeinminutes, defaultlength, maximumlifetimeinminutes, etc 
                //makes it impossible to generate a UI that the required restraints.
                //trying to select 'AdditionalProperties' but it doesn't work
                //var result = await Program.graphClient.Policies.
                //    AuthenticationMethodsPolicy.AuthenticationMethodConfigurations["TemporaryAccessPass"].
                //       GetAsync((requestConfiguration) =>
                //        {
                //           requestConfiguration.QueryParameters.Select = new[] { "AdditionalProperties" };
                //        });

                //get the TAP method policy
                var result = await Program.graphClient.Policies.
                    AuthenticationMethodsPolicy.AuthenticationMethodConfigurations["TemporaryAccessPass"].
                       GetAsync();

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
                    foreach (var item in test.Result.AuthenticationMethodConfigurations)
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


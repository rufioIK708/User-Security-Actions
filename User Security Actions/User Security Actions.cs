using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Azure.Identity;
using Microsoft.Graph.Beta;
using Microsoft.Graph.Beta.Me.Authentication.Methods.Item.ResetPassword;
using Microsoft.Graph.Beta.Models;
using Microsoft.Graph.Beta.Models.ODataErrors;
using User_Security_Actions;


namespace User_Security_Actions
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
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
                    labelSelectedUser.Show();
                    //labelSelectedUser.Text = "The selected user is: " + Program.upn;
                    getUserMFA.Show();
                    getUserMFA.Enabled = true;
                    updateImmutableId.Show();
                    updateImmutableId.Enabled = true;
                    buttonToggleAccount.Show();
                    buttonToggleAccount.Enabled = true;
                    buttonResetPassword.Show();
                    buttonResetPassword.Enabled = true;

                    //specific button text based on account status
                    bool? enabled = Program.user.AccountEnabled;

                    if (true == enabled)
                        buttonToggleAccount.Text = "Disable Account";
                    else
                        buttonToggleAccount.Text = "Enable Account";
                }
                else
                {
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
                MessageBox.Show(e.Error + "\n" + e.Message +
                    "\nError: getting user. Please make sure username is correct.");
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("Error communicating with Graph."
                 + "\nError: " + e.Message);
            }

            return user;
        }

        public void modifyRichTextBox(string message)
        {
            displayBox.AppendText(message);
        }

        public void printMFAData(List<MFAData> list)
        {
            modifyRichTextBox("\n");

            //loop through the list of MFA methods
            foreach (var item in list)
            {
                if (null != item.OdataType)
                {
                    //Replace the OdataType with a more readable string
                    switch (item.OdataType)
                    {
                        case "#microsoft.graph.platformCredentialAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Platform Credential\n");
                            break;

                        case "#microsoft.graph.windowsHelloForBusinessAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Windows Hello for Business\n");
                            break;

                        case "#microsoft.graph.temporaryAccessPassAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Temporary Access Pass\n");
                            break;

                        case "#microsoft.graph.softwareOathAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Software Oath Token\n");
                            break;

                        case "#microsoft.graph.phoneAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Phone Authenticatio\n");
                            break;

                        case "#microsoft.graph.passwordAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Password\n");
                            break;

                        case "#microsoft.graph.microsoftAuthenticatorAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Microsoft Authenticator\n");
                            break;

                        case "#microsoft.graph.hardwareOathAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Hardware Oath Token\n");
                            break;

                        case "#microsoft.graph.fido2AuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Fido2 Passkey\n");
                            break;

                        case "#microsoft.graph.emailAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Alternate E-Mail\n");
                            break;

                        case "#microsoft.graph.phoneAppNotificationAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Phone App Notification\n");
                            break;

                        case "#microsoft.graph.appPasswordAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : App Password\n");
                            break;

                        case "#microsoft.graph.phoneAppOTPAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Phone App OTP\n");
                            break;

                        case "#microsoft.graph.passwordlessMicrosoftAuthenticatorAuthenticationMethod":
                            modifyRichTextBox($"Type of Method : Passwordless Microsoft Authenticator\n");
                            break;

                        default:
                            modifyRichTextBox($"Type of Method : {item.OdataType}\n");
                            break;
                    }
                }
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

                modifyRichTextBox(Environment.NewLine);
            }
        }

        //method to get and print the authetication methods for a user
        public async Task<List<MFAData>> getAndPrintMFA(bool print)
        {
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

            //display the number of methods
            modifyRichTextBox("\nNumber of AuthMehtods:  " + response.Value.Count);

            if (null != methods && print)
                printMFAData(methods);

            return methods;
        }
        private async void getUserMFA_Click(object sender, EventArgs e)
        {
            modifyRichTextBox("\n\nGetting MFA methods for user: " + Program.user.DisplayName + "\n\n");
            await getAndPrintMFA(true);
        }

        private async void signin_Click(object sender, EventArgs e)
        {
            bool successful = false;

            Program.token = await UserAuthentication.SignInUserAndGetToken(Program.scopes, Program.ClientId);
            Program.graphClient = new GraphServiceClient(Program.token, Program.scopes);

            try
            {

                User signedInUser = await Program.graphClient.Me.GetAsync();
                successful = true;
                modifyRichTextBox("You signed in as: ");
                printUserStatus(signedInUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nSign-in failed.");
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
            new textInput("Please enter the ObjectID/UPN of a user","Select a User").ShowDialog();

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
                labelSelectedUser.Text = "The selected user is: " + Program.user.DisplayName ;
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
            new textInput(labelMessage, "Modify ImmutableId").ShowDialog();

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
            labelMessage += "\n\nPlease enter the new password, \nor \"Cancel\" to stop.";
            string resetMessage = "\nThe user will have to reset the password on next login.";
            new textInput(labelMessage, "Reset Password").ShowDialog();

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
                        MessageBox.Show("Password reset for: " + Program.user.DisplayName + " is complete!\n" +
                            "Password has been set to: " + result.NewPassword + resetMessage);
                    }
                    catch (ODataError err)
                    {
                        MessageBox.Show(err.Error + "\nError resetting password: try again");
                    }
                    MessageBox.Show("Password reset for: " + Program.user.DisplayName + " is complete!" + resetMessage);
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
    }
}


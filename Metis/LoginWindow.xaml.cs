using Firebase.Auth;
using Firebase.Database;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Metis
{
    public partial class LoginWindow : Window
    {
        private string firstName;
        public string FirstName { get => firstName; set { firstName = value;  } }


        private string lastName;
        public string LastName { get => lastName; set { lastName = value; } }

        private string email;
        public string Email { get => email; set { email = value; } }

        private string password;
        public string Password { get => password; set { password = value; } }

        private string passwordConfirm;
        public string PasswordConfirm { get => passwordConfirm; set { passwordConfirm = value; } }


        public const string GoogleClientId = "1082903605826-i87muopbkhg7q60h16609t253pe4pm6c.apps.googleusercontent.com"; // https://console.developers.google.com/apis/credentials
        public const string FirebaseAppKey = "AIzaSyAVu6ozm6DFrBx6TRnNlzgHz0NIbtH0nds"; // https://console.firebase.google.com/
        public const string FirebaseAppUri = "https://metis-tiles-default-rtdb.firebaseio.com/";

        public LoginWindow()
        {
            InitializeComponent();
            // TODO: consider removing spaceform and just doing it in mainwindow
            // TODO: finish those button clicks by hooking them up to firebase
        }

        private async void GoogleClick(object sender, RoutedEventArgs e)
        {
            // TODO: fix this:
            // Error	{Error:"invalid_request", Description:"client_secret is missing.", Uri:""}	Google.Apis.Auth.OAuth2.Responses.TokenErrorResponse

            try
            {
                PromptCodeReceiver cr = new PromptCodeReceiver();

                UserCredential result = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets { ClientId = GoogleClientId },
                    new[] { "email", "profile" },
                    "user",
                    CancellationToken.None);

                if (result.Token.IsExpired(SystemClock.Default))
                {
                    await result.RefreshTokenAsync(CancellationToken.None);
                }

                this.FetchFirebaseData(result.Token.AccessToken, FirebaseAuthType.Google);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void EmailClick(object sender, RoutedEventArgs e)
        {
            //FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAVu6ozm6DFrBx6TRnNlzgHz0NIbtH0nds"));
            //FirebaseAuthLink result = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            Console.WriteLine("FN: " + FirstName);
            Console.WriteLine("LN: " + LastName);
            Console.WriteLine("EMAIL: " + Email);
            Console.WriteLine("Password: " + PasswordBox.Password);
            Console.WriteLine("Secure Password: " + PasswordBox.SecurePassword);
            //if (ValidFirstName && ValidLastName && ValidEmail && ValidPassword && ValidPasswordConfirm)
        }

        private async void AppleClick(object sender, RoutedEventArgs e)
        {
            
        }

        private async void FetchFirebaseData(string accessToken, FirebaseAuthType authType)
        {
            try
            {
                // Convert the access token to firebase token
                var auth = new FirebaseAuthProvider(new FirebaseConfig(FirebaseAppKey));
                var data = await auth.SignInWithOAuthAsync(authType, accessToken);

                // Setup FirebaseClient to use the firebase token for data requests
                var db = new FirebaseClient(
                       FirebaseAppUri,
                       new FirebaseOptions
                       {
                           AuthTokenAsyncFactory = () => Task.FromResult(data.FirebaseToken)
                       });
                Console.WriteLine("done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /* switches between register and login menu */
        private void SwapLoginRegister(object sender, MouseButtonEventArgs e)
        {
            // reset everything when swapping
            FirstName = "";
            LastName = "";
            Email = "";
            Password = "";
            PasswordConfirm = "";

            // adjust other fields accordingly
            FirstNameTextBox.Visibility = FirstNameTextBox.IsVisible ? Visibility.Collapsed : Visibility.Visible;
            LastNameTextBox.Visibility = LastNameTextBox.IsVisible ? Visibility.Collapsed : Visibility.Visible;
            PasswordConfirmBox.Visibility = PasswordConfirmBox.IsVisible ? Visibility.Collapsed : Visibility.Visible;
            AppleButton.Content = AppleButton.Content.ToString()[0] == 'R' ? "LOGIN WITH APPLE" : "REGISTER WITH APPLE";
            GoogleButtonText.Text = GoogleButtonText.Text.ToString()[0] == 'R' ? "LOGIN WITH GOOGLE" : "REGISTER WITH GOOGLE";
            LoginRegisterButton.Content = LoginRegisterButton.Content.ToString()[0] == 'R' ? "LOGIN WITH EMAIL" : "REGISTER WITH EMAIL";
        }

        /* Handle tooltip when password box changes */
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidPasswordRule validator = new ValidPasswordRule();
            ValidationResult result = validator.Validate(PasswordBox.Password, null);
            if (!result.IsValid)
            {
                Password = null;
                // make something popup
                ToolTip tt = (ToolTip)PWDBOXBorder.ToolTip;
                if (tt == null)
                {
                    tt = new ToolTip { Content = ((ValidationResult)result).ErrorContent };
                    PWDBOXBorder.ToolTip = tt;
                }

                else
                    tt.Content = ((ValidationResult)result).ErrorContent;

                tt.IsOpen = true;
            }
            else
            {
                Password = PasswordBox.Password;
                // get rid of the popup
                ToolTip tt = (ToolTip)PWDBOXBorder.ToolTip;
                tt.Content = null;
                tt.IsOpen = false;
            }
        }

        /* Handle tooltip when confirm password box changes */
        private void PasswordConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordConfirm = PasswordConfirmBox.Password;

            bool result = false; // invalid
            if (PasswordConfirm == Password)
                result = true; // if so, valid

            if (PasswordConfirm != null && !result)
            {
                // make something popup
                ToolTip tt = (ToolTip)PWDConfirmBOXBorder.ToolTip;
                if (tt == null)
                {
                    tt = new ToolTip { Content = "Passwords must match" };
                    PWDConfirmBOXBorder.ToolTip = tt;
                }

                tt.IsOpen = true;
            }
            else
            {
                // get rid of the popup
                ToolTip tt = (ToolTip)PWDConfirmBOXBorder.ToolTip;
                tt.Content = null;
                tt.IsOpen = false;
            }
        }
    }
}

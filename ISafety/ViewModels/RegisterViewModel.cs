using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using System.ComponentModel;


namespace ISafety.ViewModels
{
    internal class RegisterViewModel : INotifyPropertyChanged
    {
        public string webApiKey = "AIzaSyCaxehG5wIM-6a6TaQsNNTn6-N85mn1Rv4";

        private INavigation _navigation;
        private string email;
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        public string Password
        {
            get => password; set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public Command RegisterUser { get; }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public RegisterViewModel(INavigation navigation)
        {
            this._navigation = navigation;

            RegisterUser = new Command(RegisterUserTappedAsync);
        }

        private async void RegisterUserTappedAsync(object obj)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                User user = await authProvider.GetUserAsync(auth);  // Get user from authentication, this is to get it's uid (LocalId).
                string token = auth.FirebaseToken;
                if (token != null)
                    await App.Current.MainPage.DisplayAlert("Alert", $"User Registered successfully\nID: {user.LocalId}", "OK");
                await this._navigation.PopAsync();
            }
            catch (Exception ex)
            {
                string reason = ex.Message;

                // Get only the reason:
                int found = reason.IndexOf("Reason: ");
                if (found != -1)    // If Reason is in ex.Message.
                {
                    reason = reason.Substring(found);
                }
                await App.Current.MainPage.DisplayAlert("Alert", reason, "OK");
            }
        }
    }
}

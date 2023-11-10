using Newtonsoft.Json;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using ISafety.Models;
namespace ISafety.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
        FirebaseClient firebaseClient = new FirebaseClient(baseUrl: "https://auth-73419-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public MainPage()
		{
			InitializeComponent();
             
            
            BindingContext = this;
        }
        
        private async void OnButton_Clicked(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new Safetytips1());

		}

		private async void OnButton_Clicked1(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new Quickreport());

		}

		private async void OnButton_Clicked2(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new Chat());

		}
	}

}
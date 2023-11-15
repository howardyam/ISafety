using Firebase.Database;
using Newtonsoft.Json;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using ISafety.Models;
using ISafety.Services;
namespace ISafety.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
        FirebaseClient firebaseClient = new FirebaseClient(baseUrl: "https://auth-73419-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public MainPage()
		{
			InitializeComponent();
            LoadQuickReports();


            BindingContext = this;
        }

        public ObservableCollection<QuickReportWithSubCategory> QuickReports { get; set; } = new ObservableCollection<QuickReportWithSubCategory>();

        private async void LoadQuickReports()
        {
            var reportsWithSubCat = await new FirebaseHelper().GetQuickReportsWithSubCategory();
            var sortedReports = reportsWithSubCat.OrderByDescending(r => r.SubCategory.DangerLvl).ToList();

            foreach (var report in sortedReports)
            {
                QuickReports.Add(report);
            }
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
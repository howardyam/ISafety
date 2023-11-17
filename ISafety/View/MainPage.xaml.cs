using Firebase.Database;
using Newtonsoft.Json;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using ISafety.Models;
using ISafety.Services;
using System.Timers;

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

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            SwipeButton.GestureRecognizers.Add(panGesture);

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
        double startX;
        System.Timers.Timer holdTimer;

        [Obsolete]
        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            void SetupHoldTimer()
            {
                // Initialize the timer
                holdTimer = new System.Timers.Timer(1000) { AutoReset = true }; // Set to tick every second
                holdTimer.Elapsed += OnHoldTimerTicked;
            }

            void StartHoldTimer()
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    CountdownLabel.Text = "3"; // Start countdown from 3 seconds
                    CountdownLabel.IsVisible = true;
                });
                holdTimer.Start();
            }
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    startX = SwipeButton.TranslationX;
                    SetupHoldTimer();
                    break;
                case GestureStatus.Running:
                    SwipeButton.TranslationX = Math.Max(0, startX + e.TotalX);
                    // If the user has swiped enough to trigger the timer but it hasn't started yet
                    if (!holdTimer.Enabled && SwipeButton.TranslationX > SwipeArea.Width * 0.4)
                    {
                        StartHoldTimer();
                        // Show the overlay grid with the countdown
                        OverlayGrid.IsVisible = true;
                    }
                    break;
                case GestureStatus.Completed:
                case GestureStatus.Canceled:
                    ResetSwipe();
                    // Hide the overlay grid as the user has released the button
                    OverlayGrid.IsVisible = false;
                    break;
            }
        }

        [Obsolete]
        void OnHoldTimerTicked(object sender, ElapsedEventArgs e)
        {
            // Decrement the countdown by 1
            int secondsLeft = int.Parse(CountdownLabel.Text) - 1;

            Device.BeginInvokeOnMainThread(() =>
            {
                if (secondsLeft < 0)
                {
                    // Stop the timer as the action is about to be triggered
                    holdTimer?.Stop();
                    TriggerEmergencyCall();
                    ResetSwipe();
                }
                else
                {
                    // Update the countdown label
                    CountdownLabel.Text = secondsLeft.ToString();
                }
            });
        }

        [Obsolete]
        void ResetSwipe()
        {
            if (holdTimer != null)
            {
                holdTimer.Stop();
                holdTimer.Dispose();
                holdTimer = null; // Clear the timer
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                // Reset the UI elements
                SwipeButton.TranslationX = 0;
                CountdownLabel.IsVisible = false;
                OverlayGrid.IsVisible = false; // Ensure the overlay grid is hidden
            });
        }

        [Obsolete]
        void TriggerEmergencyCall()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                // Only trigger the call if the countdown has finished


                DisplayAlert("Emergency Call", "Calling emergency services!", "OK");
                OverlayGrid.IsVisible = false; // Hide overlay after triggering the call

            });
        }




    }

}


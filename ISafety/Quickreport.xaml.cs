
namespace ISafety;


public partial class Quickreport : ContentPage
{
    
	public Quickreport()
	{
		InitializeComponent();
	}
    private async void OnImageButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void OnUploadImageClicked(object sender, EventArgs e)
    {
        try
        {
            FileResult fileResult = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Please select an image",
                FileTypes = FilePickerFileType.Images,
            });

            if (fileResult != null)
            {
                Stream stream = await fileResult.OpenReadAsync();
                PreviewImage.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex)
        {
            // Handle exception here
            Console.WriteLine(ex.ToString());
        }
    }
    private async void SubmitButton(object sender, EventArgs e)
    {
       bool response = await DisplayAlert("Alert", "Are you cofirm to submit the report?", "Cancel", "OK");

       if (response == false)
       {
            await DisplayAlert("Thanks", "Report submitted","OK");
       }

    }

}
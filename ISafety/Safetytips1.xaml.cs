namespace ISafety;

public partial class Safetytips1 : ContentPage
{
	public Safetytips1()
	{
		InitializeComponent();
	}

    private async void OnButton_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new Safetytips2());

    }

    private async void GoToMap(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Map());
    }
}
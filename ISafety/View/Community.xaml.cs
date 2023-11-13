namespace ISafety.View;

public partial class Community : ContentPage
{
	public Community()
	{
		InitializeComponent();
	}

    private void Subcat_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SubCategoryPage());
    }

    private void cat_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CategoryPage());
    }

    private void QR_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new QuickReportPage());
    }
}
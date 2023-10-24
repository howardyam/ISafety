namespace ISafety;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		//MainPage = new Microsoft.Maui.Controls.NavigationPage(new MainPage());
	}
}

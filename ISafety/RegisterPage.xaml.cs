using ISafety.ViewModels;

namespace ISafety
{
public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        BindingContext = new RegisterViewModel(Navigation);
        }
}}
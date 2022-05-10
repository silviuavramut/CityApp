using CityApp.Services;
using System.Threading.Tasks;
namespace CityApp;

public partial class LoginPage : ContentPage
{
    Service Services = new Service();
	public LoginPage()
	{
		InitializeComponent();
	}


    private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ImgShowHide.Source = string.IsNullOrEmpty(PasswordEntry.Text) ? null : "eyeicon.png";
        ImgShowHide.HeightRequest = 30;

    }

    private void ShowPass(object sender, EventArgs e)
    {

    }

    private void btnRegistration_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        var response = await Services.LoginAsync(UsernameEntry.Text, PasswordEntry.Text);

    }
}
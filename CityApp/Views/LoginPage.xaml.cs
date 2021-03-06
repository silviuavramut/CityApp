using CityApp.Services;
using CityApp.Views;
using System.Threading.Tasks;
namespace CityApp;

public partial class LoginPage : ContentPage
{
    Service Services = new Service();
	public LoginPage()
	{
		InitializeComponent();
	}


    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        var response = await Services.LoginAsync(UsernameEntry.Text, PasswordEntry.Text);
        await Navigation.PushModalAsync(new NavigationPage(new TabMenu()));

    }

}
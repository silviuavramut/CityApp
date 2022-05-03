using System.Threading.Tasks;
namespace CityApp;

public partial class LoginPage : ContentPage
{
    Services.Service _service = new Services.Service();
	public LoginPage()
	{
		InitializeComponent();
	}


    private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        imgShowHide.Source = string.IsNullOrEmpty(PasswordEntry.Text) ? null : "eyeicon.png";
        imgShowHide.HeightRequest = 30;

    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {

    }

    private void btnRegistration_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        var response = await _service.LoginAsync(UsernameEntry.Text, PasswordEntry.Text);

    }
}
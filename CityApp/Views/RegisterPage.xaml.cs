using CityApp.Services;

namespace CityApp;

public partial class RegisterPage : ContentPage
{

    Service Services = new Service();
    public RegisterPage()
    {
        InitializeComponent();
    }


    private async void btnRegistration_Clicked(object sender, EventArgs e)
    {
        process_img.IsRunning = true;

        if(((string.IsNullOrWhiteSpace(EmailEntry.Text))||
            (string.IsNullOrWhiteSpace(PasswordEntry.Text)) ||
            (string.IsNullOrWhiteSpace(PhoneEntry.Text)) ||
            (string.IsNullOrEmpty(EmailEntry.Text)) ||
            (string.IsNullOrEmpty(PasswordEntry.Text)) ||
            (string.IsNullOrEmpty(PhoneEntry.Text))))
        {
            await DisplayAlert("Enter data", "Enter valid data", "OK");
            process_img.IsRunning=false;
        }
        else if (PhoneEntry.Text.Length < 10)
        {
            PhoneEntry.Text = string.Empty;
            lblErorrMsg.Text = "Enter 10 digit number";
            lblErorrMsg.TextColor = Colors.IndianRed;
            lblErorrMsg.IsVisible = true;
            process_img.IsRunning = false;
        }
        else
        {
            try
            {
                bool response = await Services.RegisterUserAsync(EmailEntry.Text, PasswordEntry.Text, PhoneEntry.Text, UsernameEntry.Text);
                if (response)
                {
                    lblErorrMsg.Text = string.Empty;
                    await DisplayAlert("Alert", "Signup sucessful", "OK");
                    await Navigation.PushModalAsync(new LoginPage());

                }
                else
                {
                    lblErorrMsg.Text = "Email already exists, try again";
                    lblErorrMsg.IsVisible = true;
                    process_img.IsRunning = false;
                }
            }
            catch(Exception ex)
            {

            }
        }
            
        
    }


}
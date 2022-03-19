using CityApp.Tables;
using SQLite;

namespace CityApp;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
        var db = new SQLiteConnection(dbpath);
        db.CreateTable<RegisterUserTable>();

        var item = new RegisterUserTable()
        {
            Firstname = EntryFirstname.Text,
            Lastname = EntryLastname.Text,
            Email = EntryEmail.Text,
            Password = EntryPassword.Text
        };
        db.Insert(item);
        App.Current.MainPage.DisplayAlert("Success", "User registration complete", "Ok", "Cancel");
    }
}
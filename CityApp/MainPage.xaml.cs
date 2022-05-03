using Microsoft.Data.SqlClient;

namespace CityApp;


public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			string serverDbName = "cityappdb";
			string serverName = "192.168.1.208";
			string serverUsername = "admin";
			string serverPassword = "admin";

			string sqlconn = $"Data Source={serverName};Initial Catalog={serverDbName};User Id={serverUsername};Password={serverPassword};Encrypt=False;Trusted_Connection=true";
			SqlConnection sqlConnection = new SqlConnection(sqlconn);
			sqlConnection.Open();
		}
        catch(Exception ex)
        {
			Console.WriteLine(ex.Message);
			throw;
        }
    }
}


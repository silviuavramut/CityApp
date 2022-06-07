

using CommunityToolkit.Maui.Views;

namespace CityApp;

public partial class MyPopup : Popup
{
	public MyPopup()
	{
		InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Close();
    }
}
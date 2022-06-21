using CityApp.Services;
using Microsoft.Data.SqlClient;
using System.Text;
using CommunityToolkit.Maui.Views;
using CityApp.Models;

namespace CityApp;
public partial class ViewIncidentsPage : ContentPage
{
    IncidentService incidentService = new IncidentService();
    public ViewIncidentsPage()
	{
		InitializeComponent();
        
        LoadData();

    }

    private async void LoadData()
    {
        try
        {

            var incidents = await incidentService.GetIncidentsAsync();
            IncidentsCollectionView.ItemsSource = incidents;
            
        }
        catch (Exception ex)
        {

        }
    }

    public async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {


        var popup = new MyPopup();
        this.ShowPopup(popup);


    }



}
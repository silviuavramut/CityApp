using CityApp.Services;
using Microsoft.Data.SqlClient;
using System.Text;
using CommunityToolkit.Maui.Views;
using CityApp.Models;

namespace CityApp.Views;

public partial class ViewRestaurantsPage : ContentPage
{
    RestaurantService restaurantService = new RestaurantService();
    public ViewRestaurantsPage()
	{
		InitializeComponent();
        LoadRestaurants();
	}
    private async void LoadRestaurants()
    {
        try
        {

            var restaurants = await restaurantService.GetRestaurantAsync();
            RestaurantsCollectionView.ItemsSource = restaurants;

        }
        catch (Exception ex)
        {

        }
    }
}
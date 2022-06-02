using CityApp.Services;
using Microsoft.Data.SqlClient;
using CityApp.Models;
using System.Collections.ObjectModel;

namespace CityApp;

public partial class ReportIncidentPage : ContentPage
{
    IncidentService incidentService = new IncidentService();
    public ObservableCollection<IncidentModel> IncidentInfos { get; }

	public ReportIncidentPage()
	{
		InitializeComponent();

	}

    private async void addIncident(object sender, EventArgs e)
    {
        try
        {
            IncidentModel incidentModel = new IncidentModel(IncidentType.Items[IncidentType.SelectedIndex],IncidentLocation.Text, IncidentImage.Text,IncidentMessage.Text);

            bool response = await incidentService.AddIncidentAsync(incidentModel);
            if (response)
            {
                lblErorrMsg.Text = string.Empty;
                await DisplayAlert("Alert", "Added an incident sucessfully", "OK");
                await Navigation.PushModalAsync(new HomePage());

            }
            else
            {
                lblErorrMsg.Text = "Try again";
                lblErorrMsg.IsVisible = true;

            }
        }
        catch (Exception ex)
        {

        }

    }

    //async private void PickAnImage(object sender, EventArgs e)
    //{
    //    var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
    //    {
    //        Title = "Pick a photo"
    //    });
    //    var stream = await result.OpenReadAsync();
    //    resultImage.Source = ImageSource.FromStream(() => stream);
    //}
}
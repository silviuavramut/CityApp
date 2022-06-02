using CityApp.Services;
using Microsoft.Data.SqlClient;
using CityApp.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System;
using System.IO;

namespace CityApp;

public partial class ReportIncidentPage : ContentPage
{
    IncidentService incidentService = new IncidentService();
    public ObservableCollection<IncidentModel> IncidentInfos { get; }
    string imageBase64 = null;


    public ReportIncidentPage()
	{
		InitializeComponent();

	}

    private async void addIncident(object sender, EventArgs e)
    {
        try
        {
            IncidentModel incidentModel = new IncidentModel(IncidentType.Items[IncidentType.SelectedIndex],IncidentLocation.Text,imageBase64.ToString(), IncidentMessage.Text);

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

    string PhotoPath = null;
    async Task LoadPhotoAsync(FileResult photo)
    {
        // canceled
        if (photo == null)
        {
            PhotoPath = null;
            return;
        }
        // save the file into local storage
        var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
        using (Stream stream = await photo.OpenReadAsync())
        using (var newStream = File.OpenWrite(newFile))
        {
            await stream.CopyToAsync(newStream);

        }
        PhotoPath = newFile;
    }

    async void PickAnImage(object sender, EventArgs e)
    {
       
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick a photo"
            });

        if (result != null)
        {
            await LoadPhotoAsync(result);
            var resultbytes = File.ReadAllBytes(PhotoPath);
            imageBase64 = Convert.ToBase64String(resultbytes);
            var stream = await result.OpenReadAsync();
            resultImage.Source = ImageSource.FromStream(() => stream);
        }
    
    }

     async void TakeImage(object sender, EventArgs e)
    {
        var result = await MediaPicker.CapturePhotoAsync();
        await LoadPhotoAsync(result);
        var resultbytes = File.ReadAllBytes(PhotoPath);
        imageBase64 = Convert.ToBase64String(resultbytes);
        var stream = await result.OpenReadAsync();
        resultImage.Source = ImageSource.FromStream(() => stream);
    }
    

    private async void GetLocation(object sender, EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                });
            }
            if (location == null)
            {
                IncidentLocation.Text = "no gps";
            }
            else
            {

                double lat;
                double lng;
                lat=Convert.ToDouble(location.Latitude);
                lng=Convert.ToDouble(location.Longitude);
                var result = await Geocoding.GetPlacemarksAsync(lat, lng);
                if (result.Any())
                {
                    IncidentLocation.Text = result.FirstOrDefault()?.Thoroughfare + "," + result.FirstOrDefault()?.SubThoroughfare;
                }
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"something is wrong:{ex.Message}");
        }
    }
}
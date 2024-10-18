using EScan.Model;
using UraniumUI.Material.Controls;

namespace EScan.Views;

public partial class AddEvent : ContentPage
{ Event _event = new Event();
	public AddEvent()
	{
		InitializeComponent();
        
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
		Application.Current!.MainPage = new ListEvent();
    }

    private async void btnadd_Clicked(object sender, EventArgs e)
    {
        var datss = $"{txtdate.Date.ToString("yyyy-MM-dd")}";
        var tmin = txtstart.Time.ToString(@"h\:mm");
        var tmen = txtend.Time.ToString(@"h\:mm");
        if (string.IsNullOrEmpty(txtid.Text))
        {
            await DisplayAlert("Data validation", "Please Enter First Name!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtname.Text))
        {
            await DisplayAlert("Data validation", "Please Enter Last Name!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtdate.Date.ToString()))
        {
            await DisplayAlert("Data validation", "Please Enter Last Name!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtstart.Time.ToString()))
        {
            await DisplayAlert("Data validation", "Please Enter Last Name!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtend.Time.ToString()))
        {
            await DisplayAlert("Data validation", "Please Enter Last Name!", "Got it");
            return;
        }

        var c = await _event.GetEvent(txtid.Text);
        if (!c)
        {
            await DisplayAlert("ID validation", "The User Name you've entered already exist or you have lost your internet connection! Please try again", "Got it");
        }
        else
        {
            
            await _event.AddEvent(txtid.Text, txtname.Text, datss.ToString(), tmin.ToString(), tmen.ToString());
            await DisplayAlert("Got it!", "Data has been successfully added.", "Okay");
        }
        txtid.Text = string.Empty;
        txtname.Text = string.Empty;
        txtdate.Date = txtdate.MinimumDate;
        txtstart.Time = new TimeSpan(0, 0, 0);
        txtend.Time = new TimeSpan(0, 0, 0);
        return;
    }
}
using static EScan.Includes.GlobalVariables;
using EScan.Model;
namespace EScan.Views;

public partial class LogIncs : ContentPage
{
    User _user = new();
	public LogIncs()
	{
		InitializeComponent();
	}

    private async void btnadd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtuname.Text))
        {
            await DisplayAlert("Alertttt!", "Please Enter Your Username!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtpword.Text))
        {
            await DisplayAlert("Alertttt!", "Please Enter Your Password!", "Got it");
            return;
        }

        var b = await _user.GetUser(txtuname.Text, txtpword.Text);
        if (b)
        {
            await DisplayAlert("Yeyy!", "Access Granted!", "Ok");

            userkey = await _user.GetStatus(txtuname.Text);
            Application.Current!.MainPage = new HomePage();



        }
        else
        {
            await DisplayAlert("User Not Found!", "Access Denied!", "Ok");
        }
        return;
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current!.MainPage = new Register();
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        

    }
}
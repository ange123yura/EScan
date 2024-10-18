using EScan.Model;
namespace EScan.Views;

public partial class Register : ContentPage
{
    User _user = new();
    public Register()
	{
		InitializeComponent();
	}

    private async void btnadd_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtfrname.Text))
        {
            await DisplayAlert("Data validation", "Please Enter First Name!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtlsname.Text))
        {
            await DisplayAlert("Data validation", "Please Enter Last Name!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtuname.Text))
        {
            await DisplayAlert("Data validation", "Please Enter User Name!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtpword.Text))
        {
            await DisplayAlert("Data validation", "Please Enter Password!", "Got it");
            return;
        }
        
        var c = await _user.GetUsername(txtuname.Text);
        if (!c)
        {
            await DisplayAlert("User Name validation", "The User Name you've entered already exist or you have lost your internet connection! Please try again", "Got it");
        }
        else
        {

            await _user.AddUser(txtfrname.Text, txtlsname.Text, txtuname.Text, txtpword.Text);
            await DisplayAlert("Got it!", "Data has been successfully added.", "Okay");
        }
        txtfrname.Text = string.Empty;
        txtlsname.Text = string.Empty;
        txtuname.Text = string.Empty;
        txtpword.Text = string.Empty;
        Application.Current!.MainPage = new LogIncs();
        return;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new LogIncs();
    }
}
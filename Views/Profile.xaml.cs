using EScan.Model;
using static EScan.Includes.GlobalVariables;
namespace EScan.Views;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
        txtun.Text = _username;
        txtfn.Text = _userfname;
        txtln.Text = _userlname;
    }
   
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		Application.Current!.MainPage = new LogIncs();
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Application.Current!.MainPage = new HomePage();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current!.MainPage = new Search();
    }
}
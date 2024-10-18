namespace EScan.Views;

public partial class Search : ContentPage
{
	public Search()
	{
		InitializeComponent();
	}

    private void Searchinput_SearchButtonPressed(object sender, EventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current!.MainPage =new HomePage();  
    }

    private void TapGestureRecognizer_Tapped_1s(object sender, TappedEventArgs e)
    {
        Application.Current!.MainPage = new Profile();
    }

    private void btnadd_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new ListEvent();
    }

    private void btnadd_Clickeds(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new ListStudent();
    }
}
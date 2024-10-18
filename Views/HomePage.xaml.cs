using EScan.Model;
using static EScan.Includes.GlobalVariables;
namespace EScan.Views;

public partial class HomePage : ContentPage
{
    Student _student = new Student();
    Event _event = new Event(); 
    public HomePage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        tusername.Text = _userfname + " " + _userlname;
        tsusername.Text = "@"+_username;
        await FillList();
    }
    private async Task FillList()
    {
        ListStudent.ItemsSource = await _student.GetStudents();
        ListEvent.ItemsSource = await _event.GetEvents();
    }
    private void TapGestureRecognizer_Tapped_B(object sender, TappedEventArgs e)
    {
        Application.Current!.MainPage = new ListEvent();
    }

    private void TapGestureRecognizer_Tapped_L(object sender, TappedEventArgs e)
    {
        Application.Current!.MainPage = new ListStudent();
    }

   

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Application.Current!.MainPage = new Search();
    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        Application.Current!.MainPage = new Profile();
    }

    private void Button_Clicked_m(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new ListStudent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new ListEvent();
    }

  
}
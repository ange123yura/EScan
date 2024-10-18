using EScan.Model;
using static EScan.Includes.GlobalVariables;
namespace EScan.Views;

public partial class ListEventStudent : ContentPage
{
    Event _event = new Event();
    public ListEventStudent()
	{
		InitializeComponent();
        labelings.Text = _en;

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await FillList();
    }
    private async Task FillList()
    {
        ListofEventStudent.ItemsSource = await _event.GetEventss();
    }
    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new ListEvent();
    }
}
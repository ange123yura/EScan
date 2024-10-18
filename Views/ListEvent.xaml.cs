using EScan.Model;
using static EScan.Includes.GlobalVariables;
namespace EScan.Views;

public partial class ListEvent : ContentPage
{ Event _event = new Event();
	public ListEvent()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await FillList();
    }
    private async Task FillList()
    {
        ListofEvent.ItemsSource = await _event.GetEvents();
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new AddEvent();
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new HomePage();
    }

   

    private async void itemdelete_Invoked(object sender, EventArgs e)
    {
        var item = sender as SwipeItemView;
        if (!(item?.BindingContext is Event getuser)) return;
        _ek = getuser.EventCode;
        if (!await DisplayAlert("Delete User",
                "You are about to delete this user. All associated data from your account with this student will be removed. You will have to enter the user again when they decide to register again. " +
                "Do you really want to delete?", "Yes", "No")) return;
        //progressLoading.IsVisible = true;
        var a = await _event.DeleteEvent(_ek);
        if (a)
        {

            await DisplayAlert("Deleted", "You have successfully deleted the student!.", "Okay");
            await FillList();
        }
        else
        {
            await DisplayAlert("Something went wrong", "Please try again!", "Okay");
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        //var item = sender as Border;
        //if (item == null) return;
        //if (item.BindingContext is Event details)
        //{
        //    _ek = await _event.GetStatus(details.EventCode);
        //    Application.Current!.MainPage = new ListEventStudent();

        //}
    }
}
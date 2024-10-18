
using EScan.Model;
using static
    EScan.Includes.GlobalVariables;

namespace EScan.Views;

public partial class ListStudent : ContentPage
{
    Student _student = new Student();
	public ListStudent()
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
        ListofStudent.ItemsSource = await _student.GetStudents();
    }
  
    private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {

    }

    private void SearchBar_TextChanged_1(object sender, TextChangedEventArgs e)
    {

    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new HomePage();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new AddStudent();
    }

    private async void itemdelete_Invoked(object sender, EventArgs e)
    {
        var item = sender as SwipeItemView;
        if (!(item?.BindingContext is Student getuser)) return;
        _id = getuser.ID;
        if (!await DisplayAlert("Delete User",
                "You are about to delete this user. All associated data from your account with this student will be removed. You will have to enter the user again when they decide to register again. " +
                "Do you really want to delete?", "Yes", "No")) return;
        //progressLoading.IsVisible = true;
        var a = await _student.DeleteStudent(_id);
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
}
using EScan.Model;
namespace EScan.Views;

public partial class AddStudent : ContentPage
{
    Student _student = new Student();
	public AddStudent()
	{
		InitializeComponent();
	}

    private async void btnadd_Clicked(object sender, EventArgs e)
    {
        string events = null;
        if (string.IsNullOrEmpty(txtfrname.Text))
        {
            await DisplayAlert("Data validation", "Please Enter First Name!", "Got it");
            return;
        }
        else if (string.IsNullOrEmpty(txtid.Text))
        {
            await DisplayAlert("Data validation", "Please Enter Last Name!", "Got it");
            return;
        }

        var c = await _student.GetStudent(txtid.Text);
        if (!c)
        {
            await DisplayAlert("ID validation", "The User Name you've entered already exist or you have lost your internet connection! Please try again", "Got it");
        }
        else
        {

            await _student.AddStudent(txtid.Text, txtfrname.Text, events);
            await DisplayAlert("Got it!", "Data has been successfully added.", "Okay");
        }
        txtfrname.Text = string.Empty;
        txtid.Text = string.Empty;
        return;
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        Application.Current!.MainPage = new ListStudent();
    }
}
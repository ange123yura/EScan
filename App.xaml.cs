using EScan.Views;
namespace EScan
   
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LogIncs();
        }
    }
}

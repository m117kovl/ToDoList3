using Xamarin.Forms;

namespace ToDoList3
{
    public partial class MainPage : ContentPage
    {
        public MainPage() 
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
     
    }
}

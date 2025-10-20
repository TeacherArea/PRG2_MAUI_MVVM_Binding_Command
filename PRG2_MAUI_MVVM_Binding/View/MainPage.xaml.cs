using PRG2_MAUI_MVVM_Binding.ViewModel;

namespace PRG2_MAUI_MVVM_Binding
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new StudentViewModel();
        }
    }
}

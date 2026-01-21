using PRG2_MAUI_MVVM_Binding.ViewModel;

namespace PRG2_MAUI_MVVM_Binding
{
    public partial class MainPage : ContentPage
    {
        /*  Eftersom vi inte längre har en tom konstruktor i StudentsViewModel kan vi inte längre använda detta i xaml
         *  
         *  <ContentPage.BindingContext>
         *      <vm:StudentsViewModel />
         *  </ContentPage.BindingContext>
         *  
         *  utan ersätter den med att använda ett objekt direkt i konstruktorn för MainPage()
         */
        public MainPage(StudentsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}

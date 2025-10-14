using PRG2_MAUI_MVVM_Binding.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PRG2_MAUI_MVVM_Binding.ViewModel
{
    internal class StudentsViewModel : INotifyPropertyChanged
    {
        public StudentsViewModel()
        {
            Students.Add(new StudentViewModel(new Student { FirstName = "Paratus", SecondName = "Decimius", Age = 24 }));
            Students.Add(new StudentViewModel(new Student { FirstName = "Uthgerd", SecondName="Unbroken", Age = 27 }));
        }

        public ObservableCollection<StudentViewModel> Students { get; } = new();

        private StudentViewModel _selectedStudent;
        public StudentViewModel SelectedStudent
        {
            get => _selectedStudent;
            set { _selectedStudent = value; OnPropertyChanged(nameof(SelectedStudent)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
using PRG2_MAUI_MVVM_Binding.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PRG2_MAUI_MVVM_Binding.ViewModel
{
    internal class StudentsViewModel : INotifyPropertyChanged
    {

        private StudentViewModel _selectedStudent; // behövs enbart för UI, alltså finns den inte i Model
        public ObservableCollection<StudentViewModel> StudentList { get; } = new(); // listor och dess logik görs i ViewModel

        /// <summary>
        /// Att som här lägga till studenter till en lista direkt i konstruktorn så 
        /// här är sällan smart. Detta görs här enbart för att ha något att visa i UI
        /// </summary>
        public StudentsViewModel()
        {
            StudentList.Add(new StudentViewModel(new Student { FirstName = "Paratus", SecondName = "Decimius", Age = 52 }));
            StudentList.Add(new StudentViewModel(new Student { FirstName = "Uthgerd", SecondName="Unbroken", Age = 27 }));
            StudentList.Add(new StudentViewModel(new Student { FirstName = "Alain", SecondName = "Dufont", Age = 32 }));
            StudentList.Add(new StudentViewModel(new Student { FirstName = "Ulric", SecondName = "Stormcloak", Age = 35 }));
        }       

        public StudentViewModel SelectedStudent
        {
            get => _selectedStudent;
            set { 
                _selectedStudent = value; 
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string AGoodNameForThisString) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(AGoodNameForThisString));
    }

}
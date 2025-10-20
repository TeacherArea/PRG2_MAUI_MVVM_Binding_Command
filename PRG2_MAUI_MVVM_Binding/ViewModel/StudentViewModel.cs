using PRG2_MAUI_MVVM_Binding.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PRG2_MAUI_MVVM_Binding.ViewModel
{
    internal class StudentViewModel : INotifyPropertyChanged
    {
        private readonly Student _student;
        public string FirstName { 
            get => _student.FirstName; 
            set
            { 
                _student.FirstName = value; 
                OnPropertyChanged(nameof(FirstName)); 
            } 
        }
        public string SecondName 
        { 
            get => _student.SecondName; 
            set 
            { 
                _student.SecondName = value; 
                OnPropertyChanged(nameof(SecondName)); 
            } 
        }
        public int Age { 
            get => _student.Age; 
            set 
            { 
                _student.Age = value; 
                OnPropertyChanged(nameof(Age)); 
            } 
        }

        public StudentViewModel(Student student) => _student = student;

        public StudentViewModel()
        {
            StudentList.Add(new Student { FirstName = "Paratus", SecondName = "Decimius", Age = 52 });
            StudentList.Add(new Student { FirstName = "Uthgerd", SecondName = "Unbroken", Age = 27 });
            StudentList.Add(new Student { FirstName = "Alain", SecondName = "Dufont", Age = 32 });
            StudentList.Add(new Student { FirstName = "Ulric", SecondName = "Stormcloak", Age = 35 });
        }
        public ObservableCollection<Student> StudentList { get; } = new();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
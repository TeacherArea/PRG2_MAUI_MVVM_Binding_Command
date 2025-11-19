using PRG2_MAUI_MVVM_Binding.Model;
using System.ComponentModel;

namespace PRG2_MAUI_MVVM_Binding.ViewModel
{
    internal class StudentViewModel : INotifyPropertyChanged
    {
        private readonly Student _student; // enbart en referens till Student i Model
        public StudentViewModel(Student student) => _student = student;

        public string FirstName 
        { 
            get => _student.FirstName; // här används referensen
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
        public int Age 
        { 
            get => _student.Age; 
            set 
            { 
                _student.Age = value;
                OnPropertyChanged(nameof(Age)); 
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
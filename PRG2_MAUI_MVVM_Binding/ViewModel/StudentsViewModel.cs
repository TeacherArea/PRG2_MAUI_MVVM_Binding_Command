using PRG2_MAUI_MVVM_Binding.Model;
using PRG2_MAUI_MVVM_Binding.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PRG2_MAUI_MVVM_Binding.ViewModel
{
    public class StudentsViewModel : INotifyPropertyChanged
    {
        private readonly IStudentStorageService _storage;

        public ObservableCollection<StudentViewModel> StudentList { get; }
            = new();

        private StudentViewModel _selectedStudent;
        public StudentViewModel SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        private string _newFirstName;
        public string NewFirstName
        {
            get => _newFirstName;
            set { _newFirstName = value; OnPropertyChanged(); }
        }

        private string _newSecondName;
        public string NewSecondName
        {
            get => _newSecondName;
            set { _newSecondName = value; OnPropertyChanged(); }
        }

        private int _newAge;
        public int NewAge
        {
            get => _newAge;
            set { _newAge = value; OnPropertyChanged(); }
        }

        public ICommand AddStudentCommand { get; }
        public ICommand SaveCommand { get; }

        public StudentsViewModel(IStudentStorageService storage)
        {
            _storage = storage;

            AddStudentCommand = new Command(AddStudent);
            SaveCommand = new Command(async () => await SaveAsync());

            _ = LoadAsync();
        }

        private async Task LoadAsync()
        {
            var students = await _storage.LoadAsync();
            StudentList.Clear();

            foreach (var student in students)
                StudentList.Add(new StudentViewModel(student));
        }

        private void AddStudent()
        {
            var student = new Student
            {
                FirstName = NewFirstName,
                SecondName = NewSecondName,
                Age = NewAge
            };

            StudentList.Add(new StudentViewModel(student));

            NewFirstName = string.Empty;
            NewSecondName = string.Empty;
            NewAge = 0;
        }

        private async Task SaveAsync()
        {
            var models = StudentList.Select(vm => vm.Model).ToList();
            await _storage.SaveAsync(models);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

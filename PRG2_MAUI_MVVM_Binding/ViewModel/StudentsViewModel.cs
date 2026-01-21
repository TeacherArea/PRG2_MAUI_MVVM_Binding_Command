using PRG2_MAUI_MVVM_Binding.Services;
using System.Collections.ObjectModel;

namespace PRG2_MAUI_MVVM_Binding.ViewModel
{
    internal class StudentsViewModel
    {
        private readonly IStudentStorageService _storage;

        public ObservableCollection<StudentViewModel> StudentList { get; }
            = new();

        public StudentsViewModel(IStudentStorageService storage)
        {
            _storage = storage;
            _ = LoadAsync();
        }

        private async Task LoadAsync()
        {
            var students = await _storage.LoadAsync();
            StudentList.Clear();

            foreach (var student in students)
                StudentList.Add(new StudentViewModel(student));
        }

        public async Task SaveAsync()
        {
            var models = StudentList.Select(vm => vm.Model).ToList();
            await _storage.SaveAsync(models);
        }
    }
}

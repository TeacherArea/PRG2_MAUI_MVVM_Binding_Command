using System.Text.Json;
using PRG2_MAUI_MVVM_Binding.Model;

namespace PRG2_MAUI_MVVM_Binding.Services
{
    public class JsonStudentStorageService : IStudentStorageService
    {
        private readonly string _filePath;

        public JsonStudentStorageService()
        {
            _filePath = Path.Combine(
                FileSystem.AppDataDirectory,
                "students.json");
        }

        public async Task SaveAsync(IEnumerable<Student> students)
        {
            var json = JsonSerializer.Serialize(students,
                new JsonSerializerOptions { WriteIndented = true });

            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<IList<Student>> LoadAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Student>();

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Student>>(json)
                   ?? new List<Student>();
        }
    }
}

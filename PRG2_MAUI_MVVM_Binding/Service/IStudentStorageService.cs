using PRG2_MAUI_MVVM_Binding.Model;

namespace PRG2_MAUI_MVVM_Binding.Services
{
    // poängen med detta interface är att vi enkelt ska kunna byta Json till något annat, som SQLite
    public interface IStudentStorageService
    {
        Task SaveAsync(IEnumerable<Student> students);
        Task<IList<Student>> LoadAsync();
    }
}

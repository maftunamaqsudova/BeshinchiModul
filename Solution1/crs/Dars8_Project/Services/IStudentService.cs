using Dars8_Project.Dtos;

namespace Dars8_Project.Services
{
    public interface IStudentService
    {
        Task<long> AddStudentAsync(StudentCreateDto dto);
        Task<IEnumerable<StudentGetDto>> GetAllStudentsAsync();
        Task<StudentGetDto> GetStudentByIdAsync(long id);
        Task<bool> UpdateStudentAsync(long id, StudentCreateDto dto);
        Task<bool> DeleteStudentAsync(long id);
    }
}
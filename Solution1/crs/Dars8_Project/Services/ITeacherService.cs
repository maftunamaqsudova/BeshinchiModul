using Dars8_Project.Dtos;

namespace Dars8_Project.Services
{
    public interface ITeacherService
    {
        Task<long> AddTeacherAsync(TeacherCreateDto dto);
        Task<IEnumerable<TeacherGetDto>> GetAllTeachersAsync();
        Task<TeacherGetDto> GetTeacherByIdAsync(long id);
        Task<bool> UpdateTeacherAsync(long id, TeacherCreateDto dto);
        Task<bool> DeleteTeacherAsync(long id);
    }
}
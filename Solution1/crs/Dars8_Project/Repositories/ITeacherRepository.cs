using Dars8_Project.Dtos;
using Dars8_Project.Entities;

namespace Dars8_Project.Repositories
{
    public interface ITeacherRepository
    {
        Task<long> CreateAsync(TeacherCreateDto teacherDto);
        Task<IEnumerable<TeacherGetDto>> GetAllAsync();
        Task<TeacherGetDto> GetByIdAsync(long id);
        Task<bool> UpdateAsync(long id, TeacherCreateDto teacherDto);
        Task<bool> DeleteAsync(long id);
    }
}
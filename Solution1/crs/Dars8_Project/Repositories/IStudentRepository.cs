using Dars8_Project.Dtos;
using Dars8_Project.Entities;

namespace Dars8_Project.Repositories
{
    public interface IStudentRepository
    {
        Task<long> CreateAsync(StudentCreateDto studentDto);
        Task<IEnumerable<StudentGetDto>> GetAllAsync();
        Task<StudentGetDto>? GetByIdAsync(long id);
        Task<bool> UpdateAsync(long id, StudentCreateDto studentDto);
        Task<bool> DeleteAsync(long id);
    }
}
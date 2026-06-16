using Dars8_Project.Dtos;
using Dars8_Project.Repositories;

namespace Dars8_Project.Services
{
    public class StudentService : IStudentService
    {
            private readonly IStudentRepository _repository;

            public StudentService(IStudentRepository repository)
            {
                _repository = repository;
            }

            public async Task<long> AddStudentAsync(StudentCreateDto dto)
            {
                // Biznes mantiqi: Masalan, sinf 1 va 11 oralig'ida ekanligini tekshirish
                if (dto.Grade < 1 || dto.Grade > 11)
                    throw new Exception("Sinf 1 va 11 oralig'ida bo'lishi kerak!");

                return await _repository.CreateAsync(dto);
            }

            public async Task<IEnumerable<StudentGetDto>> GetAllStudentsAsync() =>
                await _repository.GetAllAsync();

        public async Task<StudentGetDto> GetStudentByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateStudentAsync(long id, StudentCreateDto dto) =>
                await _repository.UpdateAsync(id, dto);

            public async Task<bool> DeleteStudentAsync(long id) =>
                await _repository.DeleteAsync(id);
        }
    }


using Dars8_Project.Dtos;
using Dars8_Project.Repositories;

namespace Dars8_Project.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _repository;

        public TeacherService(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public async Task<long> AddTeacherAsync(TeacherCreateDto dto)
        {
            // Biznes mantiqi: Ism va familiya bo'sh emasligini tekshirish
            if (string.IsNullOrWhiteSpace(dto.FirstName) || string.IsNullOrWhiteSpace(dto.LastName))
                throw new Exception("Ism va familiya to'ldirilishi shart!");

            return await _repository.CreateAsync(dto);
        }

        public async Task<IEnumerable<TeacherGetDto>> GetAllTeachersAsync() =>
            await _repository.GetAllAsync();

        public async Task<TeacherGetDto> GetTeacherByIdAsync(long id) =>
            await _repository.GetByIdAsync(id);

        public async Task<bool> UpdateTeacherAsync(long id, TeacherCreateDto dto) =>
            await _repository.UpdateAsync(id, dto);

        public async Task<bool> DeleteTeacherAsync(long id) =>
            await _repository.DeleteAsync(id);
    }
}

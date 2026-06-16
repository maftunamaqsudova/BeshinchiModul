using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using Dars8_Project.Dtos;
using Dars8_Project.Entities;

namespace Dars8_Project.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly string _connectionString;

        public TeacherRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<long> CreateAsync(TeacherCreateDto teacherDto)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new
            {
                FirstName = teacherDto.FirstName,
                LastName = teacherDto.LastName,
                Subject = teacherDto.Subject
            };

            // SQL-da 'sp_AddTeacher' protsedurasi bor deb hisoblaymiz
            return await connection.ExecuteScalarAsync<long>("AddTeacher", parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<TeacherGetDto> GetByIdAsync(long id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<TeacherGetDto>("GetTeacherById",
                new { TeacherId = id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TeacherGetDto>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<TeacherGetDto>("GetAllTeachers",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateAsync(long id, TeacherCreateDto teacherDto)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new
            {
                TeacherId = id,
                FirstName = teacherDto.FirstName,
                LastName = teacherDto.LastName,
                Subject = teacherDto.Subject
            };

            var rowsAffected = await connection.ExecuteAsync("UpdateTeacher", parameters,
                commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            using var connection = new SqlConnection(_connectionString);
            var rowsAffected = await connection.ExecuteAsync("DeleteTeacher",
                new { TeacherId = id },
                commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }
    }
}

using System.Data;
using Dapper;
using Dars8_Project.Dtos;
using Dars8_Project.Entities;
using Microsoft.Data.SqlClient;

namespace Dars8_Project.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<long> CreateAsync(StudentCreateDto studentDto)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new
            {
                studentDto.FirstName,
                studentDto.LastName,
                studentDto.Grade
            };

            // Protsedurani chaqiramiz
            return await connection.ExecuteScalarAsync<long>("AddStudent", parameters,
                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            using var connection = new SqlConnection(_connectionString);
            var rowsAffected = await connection.ExecuteAsync("sp_DeleteStudent",
                new { StudentId = id },
                commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }

        public async Task<IEnumerable<StudentGetDto>> GetAllAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<StudentGetDto>("sp_GetAllStudents",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<StudentGetDto>? GetByIdAsync(long id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<StudentGetDto>("sp_GetStudentById",
                new { StudentId = id },
                commandType: CommandType.StoredProcedure);
        }


        public async Task<bool> UpdateAsync(long id, StudentCreateDto studentDto)
        {
            using var connection = new SqlConnection(_connectionString);
            var parameters = new
            {
                StudentId = id,
                studentDto.FirstName,
                studentDto.LastName,
                studentDto.Grade
            };

            var rowsAffected = await connection.ExecuteAsync("sp_UpdateStudent", parameters,
                commandType: CommandType.StoredProcedure);
            return rowsAffected > 0;
        }
    }
}

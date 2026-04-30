using Dars8_Project.Dtos;
using Dars8_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dars8_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null) return NotFound("Talaba topilmadi.");
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDto dto)
        {
            try
            {
                var id = await _studentService.AddStudentAsync(dto);
                return Ok(new { Message = "Talaba saqlandi", Id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, StudentCreateDto dto)
        {
            var result = await _studentService.UpdateStudentAsync(id, dto);
            if (!result) return NotFound("Yangilashda xato yoki talaba topilmadi.");
            return Ok("Ma'lumotlar yangilandi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (!result) return NotFound("O'chirishda xato yoki talaba topilmadi.");
            return Ok("Talaba o'chirildi.");
        }
    }
}

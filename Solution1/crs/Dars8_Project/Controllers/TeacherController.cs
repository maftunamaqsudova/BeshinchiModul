using Dars8_Project.Dtos;
using Dars8_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dars8_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher == null) return NotFound("O'qituvchi topilmadi.");
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateDto dto)
        {
            try
            {
                var id = await _teacherService.AddTeacherAsync(dto);
                return Ok(new { Message = "O'qituvchi saqlandi", Id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, TeacherCreateDto dto)
        {
            var result = await _teacherService.UpdateTeacherAsync(id, dto);
            if (!result) return NotFound("Yangilashda xato.");
            return Ok("O'qituvchi ma'lumotlari yangilandi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _teacherService.DeleteTeacherAsync(id);
            if (!result) return NotFound("O'chirishda xato.");
            return Ok("O'qituvchi o'chirildi.");
        }
    }
}

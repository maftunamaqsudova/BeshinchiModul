
using Dars8_Project.Repositories;
using Dars8_Project.Services;

namespace Dars8_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. SERVICES (Dependency Injection) qismi
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Connection String-ni appsettings.json-dan yoki to'g'ridan-to'g'ri shu yerdan olish
            // Eslatma: O'zingizning baza nomingizni tekshiring (Database=SchoolDB)
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                      ?? "Server=.; Database=SchoolDB; Trusted_Connection=True; TrustServerCertificate=True;";

            // Repository-larni ro'yxatdan o'tkazish (Scoped - har bir so'rov uchun yangi obyekt)
            builder.Services.AddScoped<IStudentRepository>(x => new StudentRepository(connectionString));
            builder.Services.AddScoped<ITeacherRepository>(x => new TeacherRepository(connectionString));

            // Servislarni ro'yxatdan o'tkazish
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<ITeacherService, TeacherService>();

            var app = builder.Build();

            // 2. MIDDLEWARE (Pipeline) qismi
            if (app.Environment.IsDevelopment())
            {
                // Swagger faqat dev rejimda ishlaydi
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }   
}


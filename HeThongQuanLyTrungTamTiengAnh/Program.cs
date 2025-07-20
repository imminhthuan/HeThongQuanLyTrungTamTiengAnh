
using HeThongQuanLyTrungTamTiengAnh.Interfaces;
using HeThongQuanLyTrungTamTiengAnh.Mappings;
using HeThongQuanLyTrungTamTiengAnh.Model;
using HeThongQuanLyTrungTamTiengAnh.Repositories;
using HeThongQuanLyTrungTamTiengAnh.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HeThongQuanLyTrungTamTiengAnh
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // cau hinh Database
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


            // Dang ky Repository
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentClassesRepository, StudentClassesRepository>();
            builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IClassesRepository, ClassesRepository>();
            builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();

            // Dang ky Service
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITeacherService, TeacherService>();
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IStudentClassesService, StudentClassesService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IClassesService, ClassesService>();
            builder.Services.AddScoped<IAttendanceService, AttendanceService>();


            // AutoMapper 
            builder.Services.AddAutoMapper(typeof(MappingProfile));


            // Add services to the container.

            builder.Services.AddControllers();


            // cau hinh Authentication (JWT Bearer)
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],   // Lay tu appsettings.json
                    ValidAudience = builder.Configuration["Jwt:Audience"], // Lay tu appsettings.json
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])) // Lay tu appsettings.json
                };
            });

            // cau hinh CORS (cho frontEnd)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                   builder => builder.WithOrigins("")
                   .AllowAnyHeader()
                   .AllowAnyMethod());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();


            // Cấu hình Middleware dựa trên môi trường
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // Su dung Developer Exception Page trong moi truong phat trien xem loi chi tiet

                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else // Moi Truong Production (hoac Staging, Test)
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts(); // Sử dụng HSTS (HTTP Strict Transport Security) - bảo mật hơn cho Production
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

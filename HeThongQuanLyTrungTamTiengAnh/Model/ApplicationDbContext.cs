using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTrungTamTiengAnh.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base((DbContextOptions) options) 
        {   
              
        }

        public DbSet<Classes> Classe { get; set; }
        public DbSet<Students> Student { get; set; }
        public DbSet<StudentClasses> StudentClasse { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Teachers> Teacher { get; set; }
        public DbSet<Payments> Payment { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Courses> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

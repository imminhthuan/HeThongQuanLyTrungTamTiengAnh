using Microsoft.EntityFrameworkCore;

namespace HeThongQuanLyTrungTamTiengAnh.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base((DbContextOptions) options) 
        {   
              
        }

        public DbSet<Classes> classes { get; set; }
        public DbSet<Students> students { get; set; }
        public DbSet<StudentClasses> studentClasses { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Teachers> teachers { get; set; }
        public DbSet<Payments> payments { get; set; }
        public DbSet<Attendance> attendances { get; set; }
        public DbSet<Courses> courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

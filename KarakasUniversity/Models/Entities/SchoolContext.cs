using KarakasUniversity.Models;
using KarakasUniversity.Models.Interfaces;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace KarakasUniversity.DAL
{
    public class SchoolContext : DbContext ,ISchoolContext
    {

        public SchoolContext() : base("SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           //removes pluralized table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

       
    }
}
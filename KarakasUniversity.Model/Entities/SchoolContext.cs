using KarakasUniversity.Models;
using KarakasUniversity.Models.Interfaces;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace KarakasUniversity.Model.Entities
{
    public class SchoolContext : DbContext, ISchoolContext
    {

        public SchoolContext() : base("SchoolContext")
        {
            Database.SetInitializer<SchoolContext>(null);
        }
        //Db connection sonradan ekleme 
        public SchoolContext(DbConnection connection ): base(connection,true)
        {
            Database.SetInitializer<SchoolContext>(null);
            Database.CreateIfNotExists();
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
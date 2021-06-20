
namespace KarakasUniversity.Services
{
    using KarakasUniversity.Models;
    using KarakasUniversity.Models.Interfaces;
    using KarakasUniversity.Services.Interfaces;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class StudentServices : IStudentService
    {
        private readonly ISchoolContext _schoolContext;


        public StudentServices(ISchoolContext schoolContext)
        {
            _schoolContext= schoolContext;
        }




        public List<Student> getStudentIndex(string sortOrder, string searchString)
        {
            var students = from s in _schoolContext.Students
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    students = students.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
      

            return students.ToList();
        }

        public Student getStudentDetails(int? id)
        {
//if (id == null)
  //          {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      //      }
            Student student = _schoolContext.Students.Find(id);
            //    if (student == null)
            //  {
            //    return HttpNotFound();
            //   }
            return student;
        }

        public void postStudentCreate(Student student) 
        {
            _schoolContext.Students.Add(student);
            _schoolContext.SaveChanges();

          //deleted the save changes method
        }
        public Student getStudentEdit(int? id)
        {
          Student student=_schoolContext.Students.Find(id);

            return student;

        }

        
       





    }


}

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
        private readonly ISchoolContext _dataContext;


        public StudentServices(ISchoolContext schoolContext)
        {
            _dataContext= schoolContext;
        }




        public List<Student> getStudentIndex(string sortOrder, string searchString)
        {
            var students = from s in _dataContext.Students
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
            Student student = _dataContext.Students.Find(id);
            //    if (student == null)
            //  {
            //    return HttpNotFound();
            //   }
            return student;
        }

       





    }


}
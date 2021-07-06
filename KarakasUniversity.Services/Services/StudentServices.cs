
using PagedList;

namespace KarakasUniversity.Services
{
    
    using KarakasUniversity.Model.Entities;
    using KarakasUniversity.Models.Interfaces;
    using KarakasUniversity.Services.DTO;
    using KarakasUniversity.Services.Interfaces;
    using KarakasUniversity.Services.Mapping;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;


    public class StudentServices : IStudentService
    {
        private readonly ISchoolContext _schoolContext;


        public StudentServices(ISchoolContext schoolContext)
        {
            _schoolContext= schoolContext;
        }




        public List<StudentViewModel> getStudentIndex(string sortOrder, string searchString)
        {
            //bak asquaeryble farka bak öncekiyle
            var students = _schoolContext.Students.AsQueryable();
                           
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

            var studentList = students.ToList();
            return studentList.toStudentViewModelList();
                
        }

        public StudentViewModel getStudent(int? id)
        {
            var query = _schoolContext.Students.Where(b => b.ID == id);
            var student = query.FirstOrDefault();

            return student.toStudentViewModel();
        }

        public void postStudentCreate(StudentRequestModel model) 
        {
            Student student = model.toStudent();
            _schoolContext.Students.Add(student);
            _schoolContext.SaveChanges();

          //deleted the save changes method
        }
        public StudentRequestModel getStudentEdit(int? id)
        {
            // Student student=_schoolContext.Students.Find(id);
            var query = _schoolContext.Students.Where(b => b.ID == id);
            var student = query.FirstOrDefault();

            //Map to StudentRequestModel here 
             
            return student.toStudentRequestModel();

        }
        
        public void postStudentEdit(int id,String firstName, String lastName, DateTime enrollmentDate)
        {
            var query = _schoolContext.Students.Where(b => b.ID == id);

            var studentEdit = query.FirstOrDefault();

            studentEdit.FirstMidName = firstName;
            studentEdit.LastName = lastName;
            studentEdit.EnrollmentDate = enrollmentDate;


         //   _schoolContext.Entry(std).State = EntityState.Modified;
            _schoolContext.SaveChanges();

         //  return RedirectToAction("Index");

        }

        public void postStudentDelete(int id)
        {
            
            var stu = _schoolContext.Students.Where(b => b.ID == id);
            var student = stu.FirstOrDefault();
            _schoolContext.Students.Remove(student);
            _schoolContext.SaveChanges();
        }

        public void dispose()
        {
            _schoolContext.Dispose();
        }


    }


}
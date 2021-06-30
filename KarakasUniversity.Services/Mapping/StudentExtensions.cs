using KarakasUniversity.Model.Entities;
using KarakasUniversity.Models;
using KarakasUniversity.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakasUniversity.Services.Mapping
{
   public static class StudentExtensions
    {
        public static StudentRequestModel toStudentRequestModel(this Student student)
        {
            var studentModel = new StudentRequestModel
            {
                ID= student.ID,
                FirstMidName = student.FirstMidName,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate

            };

            return studentModel;
        }

        public static StudentViewModel toStudentViewModel(this Student student)
        {
            var studentModel = new StudentViewModel
            {
                ID= student.ID,
                FirstMidName = student.FirstMidName,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate,
                Enrollments=student.Enrollments

            };
            return studentModel;
        }
        public static Student toStudent(this StudentRequestModel model)
        {
            var student = new Student
            {
                ID= model.ID,
                FirstMidName = model.FirstMidName,
                LastName = model.LastName,
                EnrollmentDate = model.EnrollmentDate,
            };
            return student;
        }
        public static List<StudentViewModel> toStudentViewModelList(this List<Student> studentList)
        {
            return studentList.Select(x => x.toStudentViewModel()).ToList();
        }

    }
}

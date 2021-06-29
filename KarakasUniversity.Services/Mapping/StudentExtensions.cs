﻿using KarakasUniversity.Model.Entities;
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
                FirstMidName = student.FirstMidName,
                LastName = student.LastName,
                EnrollmentDate = student.EnrollmentDate,
                Enrollments=student.Enrollments

            };
            return studentModel;
        }

    }
}

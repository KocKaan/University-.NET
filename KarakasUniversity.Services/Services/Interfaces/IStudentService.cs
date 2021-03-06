using KarakasUniversity.Model.Entities;
using KarakasUniversity.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakasUniversity.Services.Interfaces
{
    public interface IStudentService
    {
        StudentViewModel getStudent(int? id);

        List<StudentViewModel> getStudentIndex(string sortOrder, string searchString);

        void postStudentCreate(StudentRequestModel model);

        StudentRequestModel getStudentEdit(int? id);

        void postStudentEdit(int id, String firstName, String lastName, DateTime enrollmentDate);

        void postStudentDelete(int id);

        void dispose();
    }
}

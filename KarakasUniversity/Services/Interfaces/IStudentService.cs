using KarakasUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakasUniversity.Services.Interfaces
{
    public interface IStudentService
    {
        Student getStudent(int? id);

        List<Student> getStudentIndex(string sortOrder, string searchString);

        void postStudentCreate(Student student);

        Student getStudentEdit(int? id);

        void postStudentEdit(Student std);

        void postStudentDelete(int id);

        void dispose();


    }
}

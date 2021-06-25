using KarakasUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakasUniversity.Services.Interfaces
{
    public interface IHomeService
    {
        List<EnrollmentDateGroup> getStudentEnrollments();

        void dispose();

    }
}

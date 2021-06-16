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
        Student getStudentDetails(int? id);

    }
}

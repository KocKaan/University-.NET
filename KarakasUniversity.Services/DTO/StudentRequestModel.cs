using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarakasUniversity.Services.DTO
{
     public class StudentRequestModel
    {
        public int ID { get; set; }
        public String LastName { get; set; }

        public String FirstMidName { get; set; }

        public DateTime EnrollmentDate { get; set; }

    }
}

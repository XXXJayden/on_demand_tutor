using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Tutor
{
    public class SearchTutorDTO
    {
        private int grade;
        private string subject;
        private Service Service { get; set; }
    }
}

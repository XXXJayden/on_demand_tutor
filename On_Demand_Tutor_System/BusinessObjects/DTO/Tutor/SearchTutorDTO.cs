using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Tutor
{
    public class SearchTutorDTO
    {
        [Required(ErrorMessage = "Please input grade")]
        public string? grade { get; set; }
        [Required(ErrorMessage = "Please input subject")]
        public string? subject { get; set; }
        [Required(ErrorMessage = "Please input service")]
        public string? serviceId { get; set; }
    }
}

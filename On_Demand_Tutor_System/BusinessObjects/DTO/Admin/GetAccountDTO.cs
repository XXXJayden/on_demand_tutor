using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTO.Admin
{
    public class GetAccountDTO
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Major { get; set; }
        public string Grade { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }
    }
}

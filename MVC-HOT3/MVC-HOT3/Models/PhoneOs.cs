using System.ComponentModel.DataAnnotations;

namespace MVC_HOT3.Models
{
    public class PhoneOs
    {
        public int PhoneOsID { get; set; }

        [Required(ErrorMessage = "Please enter a Phone OS Name")]
        public string? PhoneOsName { get; set; }
    }
}

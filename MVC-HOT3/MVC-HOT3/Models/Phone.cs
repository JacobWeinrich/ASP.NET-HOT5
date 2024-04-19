using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MVC_HOT3.Models
{
    public class Phone
    {

        public int PhoneID { get; set; }
        public string Slug => $"{PhoneBrand?.Replace(' ', '-') ?? "offBrand"}-{PhoneName?.Replace(' ', '-') ?? "No Name"}";

        [Required(ErrorMessage = "Please enter a Image Name")]
        public string? PhoneImageName { get; set; }

        [Required(ErrorMessage = "Please enter a Phone Name")]
        public string? PhoneName { get; set; }

        [Required(ErrorMessage = "Please enter a Brand Name")]
        public string? PhoneBrand { get; set; }

        [Required(ErrorMessage = "Please enter a Model Number")]
        public string? PhoneModel { get; set; }

        [Required(ErrorMessage = "Please enter a Phone Price")]
        public double? PhonePrice { get; set; }

        [Required(ErrorMessage = "Please enter a Phone OS ID")]
        public int? PhoneOsID{ get; set; }

        [ValidateNever]
        public PhoneOs PhoneOs { get; set; } = null!;


    }
}

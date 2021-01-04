using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreateProfileViewModel
    {
        [Required]
        [Display(Name ="About Us")]
        public string AboutUs { get; set; }

        [Display(Name = "silder image -1")]
        public IFormFile File1 { get; set; }

        [Display(Name = "silder image -2")]
        public IFormFile File2 { get; set; }

        [Display(Name = "silder image -3")]
        public IFormFile File3 { get; set; }
        
        [Required]
        public string Vission { get; set; }

        [Required]
        public string Mission { get; set; }

        [Required]
        [Display(Name = "Our Plan -1")]
        public string Plan1 { get; set; }

        [Required]
        [Display(Name = "Our Plan -2")]
        public string Plan2 { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [Required]
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [Required]
        [Display(Name = "Address Line 3")]
        public string Address3 { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        
        [Required]
        [Display(Name = "Find Us")]
        public int FindUs { get; set; }
        
        [Required]
        [Display(Name = "Number of Unique Projects")]
        public int UniqueProject { get; set; }
        
        [Required]
        [Display(Name = "Parts")]
        public int Parts { get; set; }

        [Required]
        public int Achivements { get; set; }

        [Required]
        public int Countries { get; set; }

        [Required]
        [Display(Name = "In Progress Projects")]
        public int ProjectInProgress { get; set; }
    }
    public class EditProfileViewModel:CreateProfileViewModel
    {
        public int Id { get; set; }
        public string image1Url { get; set; }
        public string image2Url { get; set; }
        public string image3Url { get; set; }
    }
}

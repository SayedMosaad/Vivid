using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vivid.ViewModels
{
    public class RequestViewModel
    {
        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 4 chars")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Please enter at least 8 chars of subject")]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
    }
}

using AdProject.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdProject.Web.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Name", ResourceType = typeof(TextResource))]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Email", ResourceType = typeof(TextResource))]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(TextResource))]
        [Required]
        public string Password { get; set; }

        [Display(Name = "PasswordConfirm", ResourceType = typeof(TextResource))]
        [Required]
        public string PasswordConfirm { get; set; }

        public bool TermAccepted { get; set; }
    }
}

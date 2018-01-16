using AdProject.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdProject.Web.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email", ResourceType = typeof(TextResource))]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(TextResource))]
        [Required]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(TextResource))]
        public bool RememberMe { get; set; }
    }
}

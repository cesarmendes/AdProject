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
        [EmailAddress]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(TextResource))]
        [Display(Name = "Email", ResourceType = typeof(TextResource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(TextResource))]
        [Display(Name = "Password", ResourceType = typeof(TextResource))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(TextResource))]
        public bool RememberMe { get; set; }
    }
}

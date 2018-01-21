using AdProject.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdProject.Web.Models
{
    public class ForgotPasswordViewModel
    {
        [EmailAddress]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(TextResource))]
        public string Email { get; set; }
    }
}

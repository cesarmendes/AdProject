using AdProject.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdProject.Web.Models
{
    public class TrocarSenhaViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(TextResource))]
        [Display(Name = "PasswordCurrent", ResourceType = typeof(TextResource))]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(TextResource))]
        [Display(Name = "Password", ResourceType = typeof(TextResource))]
        public string Senha { get; set; }

        [Compare("Senha")]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(TextResource))]
        [Display(Name = "PasswordConfirm", ResourceType = typeof(TextResource))]
        public string ConfirmarSenha { get; set; }
    }
}

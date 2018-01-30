using AdProject.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdProject.Web.Models
{
    public class CadastroViewModel
    {
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(TextResource))]
        [Display(Name = "Name", ResourceType = typeof(TextResource))]
        public string Nome { get; set; }

        [EmailAddress]
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(TextResource))]
        [Display(Name = "Email", ResourceType = typeof(TextResource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(TextResource))]
        [Display(Name = "Password", ResourceType = typeof(TextResource))]
        public string Senha { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(TextResource))]
        [Display(Name = "PasswordConfirm", ResourceType = typeof(TextResource))]
        public string ConfirmarSenha { get; set; }

        public bool AceitoTermos { get; set; }
    }
}

using AdProject.Dominio.Entidades;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.Identity
{
    public class AppUser : IdentityUser<long>
    {
        public virtual Perfil Profile { get; set; }
    }
}

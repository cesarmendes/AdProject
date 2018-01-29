using AdProject.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.Entidades
{
    public class Perfil : Entidade<long>
    {
        public string Nome { get; set; }
    }
}

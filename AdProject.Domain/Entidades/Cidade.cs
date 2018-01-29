using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.Entidades
{
    public class Cidade : Entidade<int>
    {
        public int IdEstado { get; set; }
        public string Nome { get; set; }
        public virtual Estado Estado { get; set; }
    }
}

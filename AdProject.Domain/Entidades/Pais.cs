using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.Entidades
{
    public class Pais : Entidade<int>
    {
        public string Nome { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}

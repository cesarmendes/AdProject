using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.Entidades
{
    public class SubCategoria : Entidade<long>
    {
        public long IdCategoria { get; set; }
        public string Nome { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}

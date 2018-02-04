using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.Entidades
{
    public class Subcategoria : Entidade<int>
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}

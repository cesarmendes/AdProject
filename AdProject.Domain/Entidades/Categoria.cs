using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.Entidades
{
    public class Categoria : Entidade<int>
    {
        public string Nome { get; set; }
        public virtual ICollection<Subcategoria> SubCategorias { get; set; }
    }
}

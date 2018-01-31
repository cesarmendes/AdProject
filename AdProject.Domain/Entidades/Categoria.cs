using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.Entidades
{
    public class Categoria : Entidade<long>
    {
        public string Nome { get; set; }
        public virtual ICollection<Subcategoria> SubCategorias { get; set; }
    }
}

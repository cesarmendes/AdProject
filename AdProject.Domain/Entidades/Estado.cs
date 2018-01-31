using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.Entidades
{
    public class Estado : Entidade<int>
    {
        public int IdPais { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}

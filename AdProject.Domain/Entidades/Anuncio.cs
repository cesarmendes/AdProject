using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.Entidades
{
    public class Anuncio : Entidade<long>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public Nullable<decimal> ValorAnterior { get; set; }
        public DateTime Data { get; set; }
    }
}

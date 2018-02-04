using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Tipos
{
    public abstract class TiposBaseDados
    {
        public string Esquema()
        {
            return "dbo";
        }
        public abstract string Int();
        public abstract string BigInt();
        public abstract string Decimal();
        public abstract string Boolean();
        public abstract string String();
        public abstract string Text();
        public abstract string DateTime();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Tipos
{
    public class TiposPostGreSql : TiposBaseDados
    {
        public override string BigInt()
        {
            return "BIGINT";
        }

        public override string Boolean()
        {
            return "BIT";
        }

        public override string DateTime()
        {
            return "TIMESTAMP";
        }

        public override string Decimal()
        {
            return "DECIMAL";
        }

        public override string Int()
        {
            return "INT";
        }

        public override string String()
        {
            return "VARCHAR";
        }

        public override string Text()
        {
            return "TEXT";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infrastructure.Data.Contexts
{
    public class AdTables
    {
        public static readonly string SCHEME_NAME = "dbo";
        public static readonly string TYPE_INT = "INT";
        public static readonly string TYPE_BIGINT = "BIGINT";
        public static readonly string TYPE_BOOL = "BIT";
        public static readonly string TYPE_STRING = "VARCHAR";
    }

    public class ProfileTable : AdTables
    {
        public static readonly string TABLE_NAME = "TBL_USER_PROFILE";
        public static readonly string FIELD_ID = "ID";
    }
}

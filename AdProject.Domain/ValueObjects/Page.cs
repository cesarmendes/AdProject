using AdProject.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.ValueObjects
{
    public class Page<TKey, TEntity>
            where TKey : struct
            where TEntity : Entidade<TKey>
    {
        public Page(int actual, int size)
        {
            this.Actual = actual;
            this.Size = size;
        }

        public int Actual { get; private set; }
        public int Size { get; private set; }
    }
}

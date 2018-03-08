using AdProject.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.ValueObjects
{
    public abstract class Filtro<TChave, TEntidade>
        where TChave : struct
        where TEntidade : Entidade<TChave>

    {
        public Filtro(TChave id)
        {
            this.Id = id;

        }

        public Nullable<TChave> Id { get; private set; }

        public abstract Func<TEntidade, bool> Query();
    }
}

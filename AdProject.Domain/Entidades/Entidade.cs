using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.Entidades
{
    public abstract class Entidade<TKey>
        where TKey : struct
    {
        #region Private variables
        private TKey _id;
        #endregion

        #region Public properties
        public TKey Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region Constructors
        public Entidade()
        {
        }

        public Entidade(TKey id)
        {
            this._id = id;
        }
        #endregion

    }
}

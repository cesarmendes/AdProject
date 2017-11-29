using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Domain.ValueObjects
{
    public abstract class Entity<Type>
    {
        #region Private variables
        private Type _id;
        #endregion

        #region Public properties
        public Type Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region Constructors
        public Entity()
        {
        }

        public Entity(Type id)
        {
            this._id = id;
        }
        #endregion

    }
}

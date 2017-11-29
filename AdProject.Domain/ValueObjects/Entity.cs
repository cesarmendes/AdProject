﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Domain.ValueObjects
{
    public abstract class Entity<TKey>
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
        public Entity()
        {
        }

        public Entity(TKey id)
        {
            this._id = id;
        }
        #endregion

    }
}

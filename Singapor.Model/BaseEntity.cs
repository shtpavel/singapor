﻿using System;

namespace Singapor.Model
{
    public class BaseEntity
    {
        #region Properties

        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion

        #region Constructors

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        #endregion
    }
}
﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
    public class UserDatabaseConfiguration : EntityTypeConfiguration<User>
    {
        public UserDatabaseConfiguration()
        {
            ToTable("User");
            HasKey(x => x.Id);
        }
    }
}
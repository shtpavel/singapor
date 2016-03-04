﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.Model.Entities;

namespace Singapor.DAL.Configurations
{
    public class ServiceDatabaseConfiguration : EntityTypeConfiguration<Service>
    {
        public ServiceDatabaseConfiguration()
        {
            ToTable("Service");
            HasKey(x => x.Id);
        }
    }
}
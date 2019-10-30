using Pokemon2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Pokemon2.DB.Map
{
    public class MapCiudad : EntityTypeConfiguration<Ciudad>
    {
        public MapCiudad()
        {
            ToTable("Ciudad");
            HasKey(a => a.IdCiudad);

        }
    }
}
using Eduction.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Data.Mapping
{
    public class TestMap : IEntityTypeConfiguration<Test>
    {
      


        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
        }
    }
}


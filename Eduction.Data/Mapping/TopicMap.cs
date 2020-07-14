using Eduction.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Data.Mapping
{
	public class TopicMap : IEntityTypeConfiguration<Topic>
	{
		public void Configure(EntityTypeBuilder<Topic> builder)
		{
			builder.Property(p => p.Title).IsRequired().HasMaxLength(150);
			
		}
	}
}

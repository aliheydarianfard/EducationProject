using Eduction.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Data.Mapping
{
	public class CourseMap : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
			builder.Property(p => p.PublisherName).IsRequired().HasMaxLength(50);
			builder.Property(p => p.Code).IsRequired().HasMaxLength(15);
			builder.Property(p => p.Time).IsRequired().HasMaxLength(50);
		
			builder.Property(p => p.CreateOn).ValueGeneratedOnAdd().HasDefaultValueSql("GetDate()");
		}
	}
}

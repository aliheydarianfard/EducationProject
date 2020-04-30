using Eduction.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Data.Mapping
{
	public class TeacherMap : IEntityTypeConfiguration<Teacher>
	{
		public void Configure(EntityTypeBuilder<Teacher> builder)
		{
			builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
			builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
			builder.Property(p => p.BirthDay).IsRequired().HasMaxLength(30);
			builder.Property(p => p.PhoneNumber).IsRequired().HasMaxLength(12);
			builder.Property(p => p.NationalCode).IsRequired().HasMaxLength(50);
			builder.Property(p => p.LastDegreeOfEducation).IsRequired().HasMaxLength(50);
			builder.Ignore(p => p.FullName);
			builder.Property(p => p.CreateOn).ValueGeneratedOnAdd().HasDefaultValueSql("GetDate()");
		}
	}
}

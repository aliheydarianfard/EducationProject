using Eduction.Core.Domains;
using Eduction.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Data
{
	public class SqlServerApplicationContext: DbContext,IApplcationDbContext
	{
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EductionDB;Integrated Security=true;");
		//}


		public SqlServerApplicationContext(DbContextOptions options)
			: base(options)
		{

		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.SetCreateOn();
			modelBuilder.SetUpdateOn();
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerApplicationContext).Assembly);
			base.OnModelCreating(modelBuilder);
		}
		



	}
}

using Eduction.Core.Domains;
using Eduction.Data.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Data
{
    public class SqlServerApplicationContext : IdentityDbContext<Customer, CustomerRole, int>, IApplcationDbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EductionDB;Integrated Security=true;").UseLazyLoadingProxies();
        //    optionsBuilder.UseSqlServer(@"Server=148.251.103.89\MSSQLSERVER2016;Database=objectgr_DB; User ID=objectgr_ali; Password=7Ryci1~9;");
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

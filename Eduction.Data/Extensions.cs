using Eduction.Core.Domains.BaseDomains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eduction.Data
{
    public static class Extensions
    {
        public static void SetCreateOn(this ModelBuilder modelBuilder)
        {
            var ListIDateEntitiyClasses = typeof(IDateEntity).GetAllClassNames();
            var ListEntitytype = modelBuilder.Model.GetEntityTypes().Where(p => ListIDateEntitiyClasses.Contains(p.ClrType.FullName));
            foreach (var Entitytype in ListEntitytype)
            {
                var Peroperty = Entitytype.FindProperty("CreateOn");
                if (Peroperty != null)
                {
                    Peroperty.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
                    Peroperty.SetDefaultValueSql("GetDate()");
                }

            }
        }
        public static void SetUpdateOn(this ModelBuilder modelBuilder)
        {
            var ListIDateEntitiyClasses = typeof(IDateEntity).GetAllClassNames();
            var ListEntitytype = modelBuilder.Model.GetEntityTypes().Where(p => ListIDateEntitiyClasses.Contains(p.ClrType.FullName));
            foreach (var Entitytype in ListEntitytype)
            {
                var Peroperty = Entitytype.FindProperty("UpdateOn");
                if (Peroperty != null)
                {
                    Peroperty.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAddOrUpdate;
                    Peroperty.SetDefaultValueSql("GetDate()");
                }

            }
        }
        public static List<string> GetAllClassNames(this Type type)
        {

            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                    .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                    .Select(x => x.FullName).ToList();
        }
     
    }
}

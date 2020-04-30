using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace Eduction.Data
{
	public interface IApplcationDbContext
	{

		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		int SaveChanges();
		Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken = default);
		EntityEntry Entry(object entity);
		
	}
}

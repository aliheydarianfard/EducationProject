using Eduction.Core.Domains.BaseDomains;
using Eduction.Service.DTOs;
using Mapster;
using System;
using System.Collections.Generic;
using Eduction.Core.Extension;
using System.Text;

namespace Eduction.Service.Extentions
{
	public static class MappingExtenstion
	{
		public static TDTO TODTO<TDTO>(this Entity entity) where TDTO : BaseDTO
		{
			if (entity == null)
				return null;
			if (typeof(TDTO).GetInterface("IDateDTO") != null && entity.GetType().GetInterface("IDateEntity") != null)
			{
				TypeAdapterConfig<IDateEntity, TDTO>.NewConfig().Map("LocalCreateOn", p => p.CreateOn.ToPersian()).
					Map("LocalUpdateOn", p => p.UpdateOn.ToPersian());
			}

			var dto = entity.Adapt<TDTO>();

			return dto;
		}



		public static TEntity ToEntity<TEntity>(this BaseDTO baseDTO) where TEntity : Entity
		{

			if (typeof(TEntity).GetInterface("IDateEntity") != null)
			{
				TypeAdapterConfig<BaseDTO, TEntity>.NewConfig().Ignore("CreateOn", "UpdateOn", "LocalCreateOn", "LocalUpdateOn");
			}
			var entity = baseDTO.Adapt<TEntity>();

			return entity;

		}
	}
}

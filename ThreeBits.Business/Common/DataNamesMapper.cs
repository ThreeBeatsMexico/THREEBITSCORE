using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Business.Mapper;

namespace ThreeBits.Business.Common
{
	public class DataNamesMapper<TDB> where TDB : class, new()
	{
		public TDB Map(DataRow row)
		{
			TDB entity = new TDB();
			return Map(row, entity);
		}

		public TDB Map(DataRow row, TDB entity)
		{
			(from DataColumn x in row.Table.Columns
			 select x.ColumnName).ToList();
			foreach (PropertyInfo prop in (from x in typeof(TDB).GetProperties()
										   where x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any()
										   select x).ToList())
			{
				PropertyMapHelper.Map(typeof(TDB), row, prop, entity);
			}
			return entity;
		}

		public IEnumerable<TDB> Map(DataTable table)
		{
			List<TDB> entities = new List<TDB>();
			(from DataColumn x in table.Columns
			 select x.ColumnName).ToList();
			List<PropertyInfo> properties = (from x in typeof(TDB).GetProperties()
											 where x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any()
											 select x).ToList();
			foreach (DataRow row in table.Rows)
			{
				TDB entity = new TDB();
				foreach (PropertyInfo prop in properties)
				{
					PropertyMapHelper.Map(typeof(TDB), row, prop, entity);
				}
				entities.Add(entity);
			}
			return entities;
		}

		public IEnumerable<TDB> Map(DataRow[] rows)
		{
			List<TDB> entities = new List<TDB>();
			if (rows.Length != 0)
			{
				(from DataColumn x in rows[0].Table.Columns
				 select x.ColumnName).ToList();
				List<PropertyInfo> properties = (from x in typeof(TDB).GetProperties()
												 where x.GetCustomAttributes(typeof(DataNamesAttribute), true).Any()
												 select x).ToList();
				foreach (DataRow row in rows)
				{
					TDB entity = new TDB();
					foreach (PropertyInfo prop in properties)
					{
						PropertyMapHelper.Map(typeof(TDB), row, prop, entity);
					}
					entities.Add(entity);
				}
			}
			return entities;
		}
	}
}

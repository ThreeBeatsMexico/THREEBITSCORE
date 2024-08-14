using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThreeBits.Business.Mapper
{
	internal class PropertyMapHelper
	{
		public static void Map(Type type, DataRow row, PropertyInfo prop, object entity)
		{
			foreach (string columnName in AttributeHelper.GetDataNames(type, prop.Name))
			{
				if (!string.IsNullOrWhiteSpace(columnName) && row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
				{
					ParsePrimitive(prop, entity, row[columnName]);
					break;
				}
			}
		}

		private static void ParsePrimitive(PropertyInfo prop, object entity, object value)
		{
			if (prop.PropertyType == typeof(string))
			{
				string newString = value.ToString().Trim();
				if (Attribute.IsDefined(prop, typeof(HideValueAttribute)))
				{
					if (prop.Name == "Colonia")
					{
						if (newString.Length > 3)
						{
							string text = newString.Substring(0, 3);
							string finalCalle = new Regex("\\S").Replace(newString.Substring(3), "*");
							newString = text + finalCalle;
						}
					}
					else
					{
						newString = new Regex("\\S").Replace(newString, "*");
					}
				}
				prop.SetValue(entity, newString, null);
			}
			else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
			{
				if (value == null)
				{
					prop.SetValue(entity, null, null);
				}
				else
				{
					prop.SetValue(entity, ParseBoolean(value.ToString()), null);
				}
			}
			else if (prop.PropertyType == typeof(long))
			{
				prop.SetValue(entity, long.Parse(value.ToString()), null);
			}
			else if (prop.PropertyType == typeof(short) || prop.PropertyType == typeof(short?))
			{
				if (value == null)
				{
					prop.SetValue(entity, null, null);
				}
				else
				{
					prop.SetValue(entity, short.Parse(value.ToString()), null);
				}
			}
			else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
			{
				if (value == null)
				{
					prop.SetValue(entity, null, null);
				}
				else
				{
					prop.SetValue(entity, int.Parse(value.ToString()), null);
				}
			}
			else if (prop.PropertyType == typeof(decimal))
			{
				prop.SetValue(entity, decimal.Parse(value.ToString()), null);
			}
			else if (prop.PropertyType == typeof(double) || prop.PropertyType == typeof(double?))
			{
				if (double.TryParse(value.ToString(), out var _))
				{
					prop.SetValue(entity, double.Parse(value.ToString()), null);
				}
			}
			else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
			{
				if (DateTime.TryParse(value.ToString(), out var date))
				{
					prop.SetValue(entity, date, null);
				}
				else if (DateTime.TryParseExact(value.ToString(), "ddMMyyyy", new CultureInfo("en-US"), DateTimeStyles.AssumeLocal, out date))
				{
					prop.SetValue(entity, date, null);
				}
			}
			else if (prop.PropertyType == typeof(Guid))
			{
				if (Guid.TryParse(value.ToString(), out var guid))
				{
					prop.SetValue(entity, guid, null);
				}
				else if (Guid.TryParseExact(value.ToString(), "B", out guid))
				{
					prop.SetValue(entity, guid, null);
				}
			}
		}

		public static bool ParseBoolean(object value)
		{
			if (value == null || value == DBNull.Value)
			{
				return false;
			}
			switch (value.ToString().ToLowerInvariant())
			{
				case "1":
				case "y":
				case "yes":
				case "true":
					return true;
				default:
					return false;
			}
		}
	}
}

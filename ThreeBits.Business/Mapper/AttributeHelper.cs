using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Business.Mapper
{
	internal class AttributeHelper
	{
	
		public static List<string> GetDataNames(Type type, string propertyName)
		{
			object property = (from x in type.GetProperty(propertyName).GetCustomAttributes(false)
							   where x.GetType().Name == "DataNamesAttribute"
							   select x).FirstOrDefault();
			if (property != null)
			{
				return ((DataNamesAttribute)property).ValueNames;
			}
			return new List<string>();
		}
	}
}

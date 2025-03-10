﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Business.Mapper
{
	public class DataNamesAttribute : Attribute
	{
		protected List<string> _valueNames { get; set; }

		public List<string> ValueNames
		{
			get
			{
				return _valueNames;
			}
			set
			{
				_valueNames = value;
			}
		}

		public DataNamesAttribute()
		{
			_valueNames = new List<string>();
		}

		public DataNamesAttribute(params string[] valueNames)
		{
			_valueNames = valueNames.ToList();
		}
	}
}

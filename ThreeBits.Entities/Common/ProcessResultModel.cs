using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ThreeBits.Entities.Common
{
	public class ProcessResultModel<T>
	{
		public bool flag { get; set; } = true;


		public string errorMessage { get; set; }

		public T data { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Services.Security
{
	public class SeguridadException : Exception
	{
		public SeguridadException()
		{
		}

		public SeguridadException(string message)
			: base(message)
		{
		}

		public SeguridadException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}

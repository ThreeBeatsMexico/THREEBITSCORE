using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.Security
{
	public class AppsUsuarioBE
	{
		private long iIDAPLICACION;

		private int iIDROL;

		private string sDESCRIPCION;

		public long IDAPLICACION
		{
			get
			{
				return iIDAPLICACION;
			}
			set
			{
				iIDAPLICACION = value;
			}
		}

		public int IDROL
		{
			get
			{
				return iIDROL;
			}
			set
			{
				iIDROL = value;
			}
		}

		public string DESCRIPCION
		{
			get
			{
				return sDESCRIPCION;
			}
			set
			{
				sDESCRIPCION = value;
			}
		}
	}
}

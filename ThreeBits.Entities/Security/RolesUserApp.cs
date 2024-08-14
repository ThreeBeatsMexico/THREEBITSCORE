using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.Security
{
	public class RolesUserApp
	{
		private int iIDROL;

		private long iIDUSUARIO;

		private string sDESCRIPCION;

		private bool bACTIVO;

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

		public long IDUSUARIO
		{
			get
			{
				return iIDUSUARIO;
			}
			set
			{
				iIDUSUARIO = value;
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

		public bool ACTIVO
		{
			get
			{
				return bACTIVO;
			}
			set
			{
				bACTIVO = value;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.User
{
	[DataContract]
	public class EstacionesXAppBE
	{
		private long iIDESTACIONXAPP;

		private long iIDAPLICACION;

		private int iIDESTACION;

		private int iIDESTACIONPARTICULAR;

		private string sDESCRIPCION;

		private bool bACTIVO;

		[DataMember]
		public long IDESTACIONXAPP
		{
			get
			{
				return iIDESTACIONXAPP;
			}
			set
			{
				iIDESTACIONXAPP = value;
			}
		}

		[DataMember]
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

		[DataMember]
		public int IDESTACION
		{
			get
			{
				return iIDESTACION;
			}
			set
			{
				iIDESTACION = value;
			}
		}

		[DataMember]
		public int IDESTACIONPARTICULAR
		{
			get
			{
				return iIDESTACIONPARTICULAR;
			}
			set
			{
				iIDESTACIONPARTICULAR = value;
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

		[DataMember]
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

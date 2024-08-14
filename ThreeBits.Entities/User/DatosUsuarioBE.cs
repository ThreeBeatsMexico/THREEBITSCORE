using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;

namespace ThreeBits.Entities.User
{
    [DataContract]
	public class DatosUsuarioBE
	{
		private UsuariosBE oUsuarios;

		private List<DomicilioBE> oDomicilios;

		private List<ContactoBE> oContactos;

		private List<RolesXUsuarioBE> oRolesXUsuario;

		private ReglasBE oReglas;

		private long lApp;

		public UsuariosBE Usuario
		{
			get
			{
				return oUsuarios;
			}
			set
			{
				oUsuarios = value;
			}
		}

		public List<DomicilioBE> Domicilios
		{
			get
			{
				return oDomicilios;
			}
			set
			{
				oDomicilios = value;
			}
		}

		public List<ContactoBE> Contactos
		{
			get
			{
				return oContactos;
			}
			set
			{
				oContactos = value;
			}
		}

		public List<RolesXUsuarioBE> RolesXUsuario
		{
			get
			{
				return oRolesXUsuario;
			}
			set
			{
				oRolesXUsuario = value;
			}
		}

		public ReglasBE Reglas
		{
			get
			{
				return oReglas;
			}
			set
			{
				oReglas = value;
			}
		}

		public long App
		{
			get
			{
				return lApp;
			}
			set
			{
				lApp = value;
			}
		}
	}
}

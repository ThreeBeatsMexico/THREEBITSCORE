using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;

namespace ThreeBits.Entities.User
{
	public class reqAddRolesxUsuario
	{
		public ReglasBE Reglas { get; set; }

		public List<RolesXUsuarioBE> RolesXUsuario { get; set; }
	}
}

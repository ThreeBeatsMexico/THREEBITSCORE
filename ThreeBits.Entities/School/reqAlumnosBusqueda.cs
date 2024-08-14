using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.School
{
	public class reqAlumnosBusqueda
	{
		public string sIdColegio { get; set; }

		public string sNumeroMatricula { get; set; }

		public string sAPaterno { get; set; }

		public string sAMaterno { get; set; }

		public string sNombres { get; set; }

		public string sFechaNacimiento { get; set; }

		public string sEstatus { get; set; }
	}
}

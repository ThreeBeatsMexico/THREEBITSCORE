using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Pagos;
using ThreeBits.Entities.School;
using ThreeBits.Interfaces.School;

namespace ThreeBits.Services.School
{
	public class SchoolServiceBR : _BaseService, ISchoolServiceBR
	{
		private readonly ILogger _logger;

		private readonly ISchoolServiceDA _schoolServiceDA;

		public SchoolServiceBR(ILogger<SchoolServiceBR> logger, ISchoolServiceDA userServiceDA)
		{
			_logger = logger;
			_schoolServiceDA = userServiceDA;
		}

		public List<AlumnosBE> ListaAlumnos(reqAlumnosBusqueda _schoolServiceDAsBE)
		{
			return _schoolServiceDA.ListaAlumnosDat(_schoolServiceDAsBE);
		}

		public List<AlumnosBE> ListaAlumnosGrupo(string idGrupo, string idGrado, string idCiclo)
		{
			return _schoolServiceDA.ListaAlumnosGrupoDat(idGrupo, idGrado, idCiclo);
		}

		public List<AlumnosBE> ListaAlumnosGrupoAdd(string idGrado, string idCiclo)
		{
			return _schoolServiceDA.ListaAlumnosGrupoAddDat(idGrado, idCiclo);
		}

		public List<AlumnosBE> ListaAlumnosSearch(string idColegio)
		{
			return _schoolServiceDA.ListaAlumnosSearchDat(idColegio);
		}

		public AlumnosBE ObtieneAlumno(string Alumno)
		{
			return _schoolServiceDA.ObtieneAlumnoDat(Alumno);
		}

		public AlumnosBE ObtieneInfAlumnoBus(string Alumno)
		{
			return _schoolServiceDA.ObtieneInfoAlumnoDat(Alumno);
		}

		public AlumnosBE ObtieneAlumno2(string Alumno)
		{
			return _schoolServiceDA.ObtieneAlumno2Dat(Alumno);
		}

		public string fnRegistraAlumnoBus(AlumnosBE AlumnoItem)
		{
			return _schoolServiceDA.fnRegistroAlumnoDat(AlumnoItem);
		}

		//public DataSet ObtieneAlumnoRpt(string Matricula)
		//{
		//	return _schoolServiceDA.ObtenerAlumnoRpt(Matricula);
		//}

		public List<GradoBE> ObtieneGrado(string Nivel)
		{
			return _schoolServiceDA.ObtieneGradoDat(Nivel);
		}

		public string AsignaAlumnoGrupo(string idAlumno, string grupo, string ciclo, string user)
		{
			return _schoolServiceDA.AsignaAlumnoGrupoDat(idAlumno, grupo, ciclo, user);
		}

		public List<PagosBE> ListaPagosAlumno(string idAlumno)
		{
			return _schoolServiceDA.ListaPagosAlumnoDat(idAlumno);
		}

		//public DataSet ObtieneRecibo(string Alumno)
		//{
		//	return _schoolServiceDA.ObtenerReciboRpt(Alumno);
		//}

		//public DataSet ObtieneDeudoresRpt()
		//{
		//	return _schoolServiceDA.ObtenerDeudoresRpt();
		//}

		//public DataSet ObtieneCredencialRpt(string Matriculas)
		//{
		//	return _schoolServiceDA.ObtenerCredencialesRpt(Matriculas);
		//}
	}
}

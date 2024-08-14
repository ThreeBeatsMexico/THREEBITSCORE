using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Pagos;
using ThreeBits.Entities.School;

namespace ThreeBits.Interfaces.School
{
	public interface ISchoolServiceBR
	{
		List<AlumnosBE> ListaAlumnos(reqAlumnosBusqueda _schoolServiceDAsBE);

		List<AlumnosBE> ListaAlumnosGrupo(string idGrupo, string idGrado, string idCiclo);

		List<AlumnosBE> ListaAlumnosGrupoAdd(string idGrado, string idCiclo);

		List<AlumnosBE> ListaAlumnosSearch(string idColegio);

		AlumnosBE ObtieneAlumno(string Alumno);

		AlumnosBE ObtieneInfAlumnoBus(string Alumno);

		AlumnosBE ObtieneAlumno2(string Alumno);

		string fnRegistraAlumnoBus(AlumnosBE AlumnoItem);

		//DataSet ObtieneAlumnoRpt(string Matricula);

		List<GradoBE> ObtieneGrado(string Nivel);

		string AsignaAlumnoGrupo(string idAlumno, string grupo, string ciclo, string user);

		List<PagosBE> ListaPagosAlumno(string idAlumno);

		//DataSet ObtieneRecibo(string Alumno);

		//DataSet ObtieneDeudoresRpt();

		//DataSet ObtieneCredencialRpt(string Matriculas);
	}
}

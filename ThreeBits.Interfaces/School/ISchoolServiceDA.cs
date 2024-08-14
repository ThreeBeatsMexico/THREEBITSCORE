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
	public interface ISchoolServiceDA
	{
		DataTable getAlumnosDA(AlumnosBE item);

		string fnRegistroAlumnoDat(AlumnosBE item);

		List<AlumnosBE> ListaAlumnosDat(reqAlumnosBusqueda oAlumnosBE);

		List<AlumnosBE> ListaAlumnosGrupoDat(string idGrupo, string idGrado, string idCiclo);

		List<AlumnosBE> ListaAlumnosGrupoAddDat(string idGrado, string idCiclo);

		AlumnosBE ObtieneAlumnoDat(string Alumno);

		AlumnosBE ObtieneAlumno2Dat(string Alumno);

		//AlumnoDs ObtenerAlumnoRpt(string sMatricula);

		List<GradoBE> ObtieneGradoDat(string Nivel);

		string AsignaAlumnoGrupoDat(string idAlumno, string grupo, string ciclo, string user);

		List<AlumnosBE> ListaAlumnosSearchDat(string idColegio);

		List<PagosBE> ListaPagosAlumnoDat(string Alumno);

		AlumnosBE ObtieneInfoAlumnoDat(string Alumno);

		//RecibosDs ObtenerReciboRpt(string sAlumno);

		//DeudoresDs ObtenerDeudoresRpt();

		//CredencialDS ObtenerCredencialesRpt(string Matricula);
	}

}

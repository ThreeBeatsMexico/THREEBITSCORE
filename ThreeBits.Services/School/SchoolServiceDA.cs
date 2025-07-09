using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.Common;
using ThreeBits.Entities.Pagos;
using ThreeBits.Entities.School;
using ThreeBits.Interfaces.School;

namespace ThreeBits.Services.School
{
	public class SchoolServiceDA : MySqlDataContext, ISchoolServiceDA
	{
		private readonly ILogger _logger;

		private readonly IConfiguration _configuration;

		public SchoolServiceDA(ILogger<SchoolServiceDA> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
            _MySqlconnectionString = _configuration["ConnectionStrings:MySqlSchoolConnection"];
		}

		public DataTable getAlumnosDA(AlumnosBE item)
		{
			MySqlCommand dbCommand = new MySqlCommand("proc_LISTA_ALUMNOS")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("p_IDCOLEGIO", MySqlDbType.VarChar).Value = item.sIdColegio;
			dbCommand.Parameters.Add("p_MATRICULA", MySqlDbType.VarChar).Value = item.sNumeroMatricula;
			dbCommand.Parameters.Add("p_NOMBRES", MySqlDbType.VarChar).Value = item.sNombres;
			dbCommand.Parameters.Add("p_APATERNO", MySqlDbType.VarChar).Value = item.sAPaterno;
			dbCommand.Parameters.Add("p_AMATERNO", MySqlDbType.VarChar).Value = item.sAMaterno;
			dbCommand.Parameters.Add("p_FECHANACIMIENTO", MySqlDbType.VarChar).Value = item.sFechaNacimiento;
			dbCommand.Parameters.Add("p_ESTATUS", MySqlDbType.VarChar).Value = item.sEstatus;
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				return DataTable;
			}
			throw new DbDataContextException(dbError);
		}

		public string fnRegistroAlumnoDat(AlumnosBE item)
		{
			string sRespuesta = string.Empty;
			MySqlCommand dbCommand = new MySqlCommand("proc_ALUMNOS")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("NumeroMatricula", MySqlDbType.VarChar).Value = item.sNumeroMatricula;
			dbCommand.Parameters.Add("APaterno", MySqlDbType.VarChar).Value = item.sAPaterno;
			dbCommand.Parameters.Add("AMaterno", MySqlDbType.VarChar).Value = item.sAMaterno;
			dbCommand.Parameters.Add("Nombres", MySqlDbType.VarChar).Value = item.sNombres;
			dbCommand.Parameters.Add("FechaNacimiento", MySqlDbType.VarChar).Value = item.sFechaNacimiento;
			dbCommand.Parameters.Add("Sexo", MySqlDbType.VarChar).Value = item.sSexo;
			dbCommand.Parameters.Add("Nacionalidad", MySqlDbType.VarChar).Value = item.sNacionalidad;
			dbCommand.Parameters.Add("Grado", MySqlDbType.VarChar).Value = item.sGrado;
			dbCommand.Parameters.Add("EscuelaProcedencia", MySqlDbType.VarChar).Value = item.sEscuelaProcedencia;
			dbCommand.Parameters.Add("Hermanos", MySqlDbType.VarChar).Value = item.sHermanos;
			dbCommand.Parameters.Add("GradoHermanos", MySqlDbType.VarChar).Value = item.sGradoHermanos;
			dbCommand.Parameters.Add("Calle", MySqlDbType.VarChar).Value = item.sCalle;
			dbCommand.Parameters.Add("Numero", MySqlDbType.VarChar).Value = item.sNumero;
			dbCommand.Parameters.Add("Colonia", MySqlDbType.VarChar).Value = item.sColonia;
			dbCommand.Parameters.Add("Delegacion", MySqlDbType.VarChar).Value = item.sDelegacion;
			dbCommand.Parameters.Add("Estado", MySqlDbType.VarChar).Value = item.sEstado;
			dbCommand.Parameters.Add("CodigoPostal", MySqlDbType.VarChar).Value = item.sCodigoPostal;
			dbCommand.Parameters.Add("Telefono", MySqlDbType.VarChar).Value = item.sTelefono;
			dbCommand.Parameters.Add("Email", MySqlDbType.VarChar).Value = item.sEmail;
			dbCommand.Parameters.Add("Curp", MySqlDbType.VarChar).Value = item.sCurp;
			dbCommand.Parameters.Add("EdadAnos", MySqlDbType.VarChar).Value = item.sEdadAnos;
			dbCommand.Parameters.Add("EdadMeses", MySqlDbType.VarChar).Value = item.sEdadMeses;
			dbCommand.Parameters.Add("Foto", MySqlDbType.VarChar).Value = item.sFoto;
			dbCommand.Parameters.Add("NivelAcademico", MySqlDbType.VarChar).Value = item.sNivelAcademico;
			dbCommand.Parameters.Add("NombrePadreTutor", MySqlDbType.VarChar).Value = item.sNombrePadreTutor;
			dbCommand.Parameters.Add("OcupacionPadre", MySqlDbType.VarChar).Value = item.sOcupacionPadre;
			dbCommand.Parameters.Add("TelefonoPadre", MySqlDbType.VarChar).Value = item.sTelefonoPadre;
			dbCommand.Parameters.Add("TelefonoTrabajoPadre", MySqlDbType.VarChar).Value = item.sTelefonoTrabajoPadre;
			dbCommand.Parameters.Add("CelularPadre", MySqlDbType.VarChar).Value = item.sCelularPadre;
			dbCommand.Parameters.Add("FechaNacimientoPadre", MySqlDbType.VarChar).Value = item.sFechaNacimientoPadre;
			dbCommand.Parameters.Add("SueldoPadre", MySqlDbType.VarChar).Value = item.sSueldoPadre;
			dbCommand.Parameters.Add("NacionalidadPadre", MySqlDbType.VarChar).Value = item.sNacionalidadPadre;
			dbCommand.Parameters.Add("NombreMadreTutor", MySqlDbType.VarChar).Value = item.sNombreMadreTutor;
			dbCommand.Parameters.Add("OcupacionMadre", MySqlDbType.VarChar).Value = item.sOcupacionMadre;
			dbCommand.Parameters.Add("TelefonoMadre", MySqlDbType.VarChar).Value = item.sTelefonoMadre;
			dbCommand.Parameters.Add("TelefonoTrabajoMadre", MySqlDbType.VarChar).Value = item.sTelefonoTrabajoMadre;
			dbCommand.Parameters.Add("CelularMadre", MySqlDbType.VarChar).Value = item.sCelularMadre;
			dbCommand.Parameters.Add("FechaNacimientoMadre", MySqlDbType.VarChar).Value = item.sFechaNacimientoMadre;
			dbCommand.Parameters.Add("SueldoMadre", MySqlDbType.VarChar).Value = item.sSueldoMadre;
			dbCommand.Parameters.Add("NacionalidadMadre", MySqlDbType.VarChar).Value = item.sNacionalidadMadre;
			dbCommand.Parameters.Add("NombreFamVecino", MySqlDbType.VarChar).Value = item.sNombreFamVecino;
			dbCommand.Parameters.Add("TelefonoVecino", MySqlDbType.VarChar).Value = item.sTelefonoVecino;
			dbCommand.Parameters.Add("TelefonoTrabajoVecino", MySqlDbType.VarChar).Value = item.sTelefonoTrabajoVecino;
			dbCommand.Parameters.Add("CelularVecino", MySqlDbType.VarChar).Value = item.sCelularVecino;
			dbCommand.Parameters.Add("EducacionFisica", MySqlDbType.VarChar).Value = item.sEducacionFisica;
			dbCommand.Parameters.Add("Medicamento", MySqlDbType.VarChar).Value = item.sMedicamento;
			dbCommand.Parameters.Add("NombreMedicamento", MySqlDbType.VarChar).Value = item.sNombreMedicamento;
			dbCommand.Parameters.Add("DosisMedicamento", MySqlDbType.VarChar).Value = item.sDosisMedicamento;
			dbCommand.Parameters.Add("Peso", MySqlDbType.VarChar).Value = item.sPeso;
			dbCommand.Parameters.Add("Talla", MySqlDbType.VarChar).Value = item.sTalla;
			dbCommand.Parameters.Add("TipoSangre", MySqlDbType.VarChar).Value = item.sTipoSangre;
			dbCommand.Parameters.Add("Enfermedades", MySqlDbType.VarChar).Value = item.sEnfermedades;
			dbCommand.Parameters.Add("NombreEnfermedades", MySqlDbType.VarChar).Value = item.sNombreEnfermedades;
			dbCommand.Parameters.Add("ProcedimientoCrisis", MySqlDbType.VarChar).Value = item.sProcedimientoCrisis;
			dbCommand.Parameters.Add("Certificado", MySqlDbType.VarChar).Value = item.sCertificado;
			dbCommand.Parameters.Add("EnfermedadCertificado", MySqlDbType.VarChar).Value = item.sEnfermedadCertificado;
			dbCommand.Parameters.Add("Alergia", MySqlDbType.VarChar).Value = item.sAlergia;
			dbCommand.Parameters.Add("NombreAlergia", MySqlDbType.VarChar).Value = item.sNombreAlergia;
			dbCommand.Parameters.Add("ProcedimintoCrisisAlergia", MySqlDbType.VarChar).Value = item.sProcedimintoCrisisAlergia;
			dbCommand.Parameters.Add("NombreAccidente", MySqlDbType.VarChar).Value = item.sNombreAccidente;
			dbCommand.Parameters.Add("TelefonoAccidente", MySqlDbType.VarChar).Value = item.sTelefonoAccidente;
			dbCommand.Parameters.Add("NombreHospital", MySqlDbType.VarChar).Value = item.sNombreHospital;
			dbCommand.Parameters.Add("Medico", MySqlDbType.VarChar).Value = item.sMedico;
			dbCommand.Parameters.Add("NombreMedico", MySqlDbType.VarChar).Value = item.sNombreMedico;
			dbCommand.Parameters.Add("TelefonoMedico", MySqlDbType.VarChar).Value = item.sTelefonoMedico;
			dbCommand.Parameters.Add("CedulaMedico", MySqlDbType.VarChar).Value = item.sCedulaMedico;
			dbCommand.Parameters.Add("AutorizaTraslado", MySqlDbType.VarChar).Value = item.sAutorizaTraslado;
			dbCommand.Parameters.Add("ProcedimientoAccidente", MySqlDbType.VarChar).Value = item.sProcedimientoAccidente;
			dbCommand.Parameters.Add("NombreUsuario", MySqlDbType.VarChar).Value = item.sUsuario;
			dbCommand.Parameters.Add("Tutor", MySqlDbType.VarChar).Value = item.sTutor;
			dbCommand.Parameters.Add("Estatus", MySqlDbType.VarChar).Value = item.sEstatus;
			dbCommand.Parameters.Add("ServerPath", MySqlDbType.VarChar).Value = item.sServerPath;
			dbCommand.Parameters.Add("Beca", MySqlDbType.VarChar).Value = item.sBeca;
			dbCommand.Parameters.Add("FormaPago", MySqlDbType.VarChar).Value = item.sFormaPago;
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				IEnumerator enumerator = DataTable.Rows.GetEnumerator();
				try
				{
					if (enumerator.MoveNext())
					{
						return ((DataRow)enumerator.Current)["MATRICULA"].ToString();
					}
					return sRespuesta;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			throw new DbDataContextException(dbError);
		}

		public List<AlumnosBE> ListaAlumnosDat(reqAlumnosBusqueda oAlumnosBE)
		{
			List<AlumnosBE> oAlumnosLista = new List<AlumnosBE>();
			MySqlCommand dbCommand = new MySqlCommand("proc_LISTA_ALUMNOS")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("p_IdColegio", MySqlDbType.VarChar).Value = oAlumnosBE.sIdColegio;
			dbCommand.Parameters.Add("p_MATRICULA", MySqlDbType.VarChar).Value = oAlumnosBE.sNumeroMatricula;
			dbCommand.Parameters.Add("p_Nombres", MySqlDbType.VarChar).Value = oAlumnosBE.sNombres;
			dbCommand.Parameters.Add("p_APaterno", MySqlDbType.VarChar).Value = oAlumnosBE.sAPaterno;
			dbCommand.Parameters.Add("p_AMaterno", MySqlDbType.VarChar).Value = oAlumnosBE.sAMaterno;
			dbCommand.Parameters.Add("p_FechaNacimiento", MySqlDbType.VarChar).Value = oAlumnosBE.sFechaNacimiento;
			dbCommand.Parameters.Add("p_Estatus", MySqlDbType.VarChar).Value = oAlumnosBE.sEstatus;
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				foreach (DataRow row in DataTable.Rows)
				{
					AlumnosBE item = new AlumnosBE();
					item.sIdAlumno = row["IdAlumno"].ToString();
					item.sNumeroMatricula = row["NumeroMatricula"].ToString();
					item.sNombres = row["Nombres"].ToString();
					item.sAPaterno = row["APaterno"].ToString();
					item.sAMaterno = row["AMaterno"].ToString();
					item.sFechaNacimiento = row["FechaNacimiento"].ToString();
					item.sEstado = row["DESCESTATUS"].ToString();
					oAlumnosLista.Add(item);
				}
				return oAlumnosLista;
			}
			throw new DbDataContextException(dbError);
		}

		public List<AlumnosBE> ListaAlumnosGrupoDat(string idGrupo, string idGrado, string idCiclo)
		{
			List<AlumnosBE> oAlumnosLista = new List<AlumnosBE>();
			MySqlCommand dbCommand = new MySqlCommand("proc_LISTA_ALUMNOS_GRUPO")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("IDGRADO", MySqlDbType.VarChar).Value = idGrado;
			dbCommand.Parameters.Add("IDGRUPO", MySqlDbType.VarChar).Value = idGrupo;
			dbCommand.Parameters.Add("IDCICLO", MySqlDbType.VarChar).Value = idCiclo;
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				foreach (DataRow row in DataTable.Rows)
				{
					AlumnosBE item = new AlumnosBE();
					item.sIdAlumno = row["IdAlumno"].ToString();
					item.sNumeroMatricula = row["NumeroMatricula"].ToString();
					item.sNombres = row["Nombres"].ToString();
					item.sAPaterno = row["APaterno"].ToString();
					item.sAMaterno = row["AMaterno"].ToString();
					item.sGrado = row["Grado"].ToString();
					item.sGrupo = row["Grupo"].ToString();
					item.sCiclo = row["idCiclo"].ToString();
					oAlumnosLista.Add(item);
				}
				return oAlumnosLista;
			}
			throw new DbDataContextException(dbError);
		}

		public List<AlumnosBE> ListaAlumnosGrupoAddDat(string idGrado, string idCiclo)
		{
			List<AlumnosBE> oAlumnosLista = new List<AlumnosBE>();
			MySqlCommand dbCommand = new MySqlCommand("proc_LISTA_ALUMNOS_GRUPO_ADD")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("IDGRADO", MySqlDbType.VarChar).Value = idGrado;
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				foreach (DataRow row in DataTable.Rows)
				{
					AlumnosBE item = new AlumnosBE();
					item.sIdAlumno = row["IdAlumno"].ToString();
					item.sNumeroMatricula = row["NumeroMatricula"].ToString();
					item.sNombres = row["NumeroMatricula"].ToString() + " - " + row["Nombres"].ToString() + " " + row["APaterno"].ToString() + " " + row["AMaterno"].ToString();
					item.sAPaterno = row["APaterno"].ToString();
					item.sAMaterno = row["AMaterno"].ToString();
					oAlumnosLista.Add(item);
				}
				return oAlumnosLista;
			}
			throw new DbDataContextException(dbError);
		}

		public AlumnosBE ObtieneAlumnoDat(string Alumno)
		{
			AlumnosBE item = new AlumnosBE();
			MySqlCommand dbCommand = new MySqlCommand("select a.*, b.* from Alumnos a, InfoAlumnos b where a.NumeroMatricula = b.NumeroMatricula and a.NumeroMatricula = '" + Alumno + "'")
			{
				CommandType = CommandType.Text
			};
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				foreach (DataRow row in DataTable.Rows)
				{
					item.sIdAlumno = row["IdAlumno"].ToString();
					item.sNumeroMatricula = row["NumeroMatricula"].ToString();
					item.sAPaterno = row["APaterno"].ToString();
					item.sAMaterno = row["AMaterno"].ToString();
					item.sNombres = row["Nombres"].ToString();
					item.sFechaNacimiento = row["FechaNacimiento"].ToString();
					item.sSexo = row["Sexo"].ToString();
					item.sNacionalidad = row["Nacionalidad"].ToString();
					item.sGrado = row["Grado"].ToString();
					item.sGrupo = row["Grupo"].ToString();
					item.sNumeroLista = row["NumeroLista"].ToString();
					item.sEscuelaProcedencia = row["EscuelaProcedencia"].ToString();
					item.sHermanos = row["Hermanos"].ToString();
					item.sGradoHermanos = row["GradoHermanos"].ToString();
					item.sCalle = row["Calle"].ToString();
					item.sNumero = row["Numero"].ToString();
					item.sColonia = row["Colonia"].ToString();
					item.sDelegacion = row["Delegacion"].ToString();
					item.sEstado = row["Estado"].ToString();
					item.sCodigoPostal = row["CodigoPostal"].ToString();
					item.sTelefono = row["Telefono"].ToString();
					item.sEmail = row["Email"].ToString();
					item.sCurp = row["Curp"].ToString();
					item.sEdadAnos = row["EdadAnos"].ToString();
					item.sEdadMeses = row["EdadMeses"].ToString();
					item.sFoto = row["Foto"].ToString();
					item.sNivelAcademico = row["NivelAcademico"].ToString();
					item.sEstatus = row["Estatus"].ToString();
					item.sNombrePadreTutor = row["NombrePadreTutor"].ToString();
					item.sOcupacionPadre = row["OcupacionPadre"].ToString();
					item.sTelefonoPadre = row["TelefonoPadre"].ToString();
					item.sTelefonoTrabajoPadre = row["TelefonoTrabajoPadre"].ToString();
					item.sCelularPadre = row["CelularPadre"].ToString();
					item.sFechaNacimientoPadre = row["FechaNacimientoPadre"].ToString();
					item.sSueldoPadre = row["SueldoPadre"].ToString();
					item.sNacionalidadPadre = row["NacionalidadPadre"].ToString();
					item.sNombreMadreTutor = row["NombreMadreTutor"].ToString();
					item.sOcupacionMadre = row["OcupacionMadre"].ToString();
					item.sTelefonoMadre = row["TelefonoMadre"].ToString();
					item.sTelefonoTrabajoMadre = row["TelefonoTrabajoMadre"].ToString();
					item.sCelularMadre = row["CelularMadre"].ToString();
					item.sFechaNacimientoMadre = row["FechaNacimientoMadre"].ToString();
					item.sSueldoMadre = row["SueldoMadre"].ToString();
					item.sNacionalidadMadre = row["NacionalidadMadre"].ToString();
					item.sNombreFamVecino = row["NombreFamVecino"].ToString();
					item.sTelefonoVecino = row["TelefonoVecino"].ToString();
					item.sTelefonoTrabajoVecino = row["TelefonoTrabajoVecino"].ToString();
					item.sCelularVecino = row["CelularVecino"].ToString();
					item.sEducacionFisica = row["EducacionFisica"].ToString();
					item.sMedicamento = row["Medicamento"].ToString();
					item.sMedico = row["NombreMedicamento"].ToString();
					item.sDosisMedicamento = row["DosisMedicamento"].ToString();
					item.sAlimentoProhibido = row["AlimentoProhibido"].ToString();
					item.sPeso = row["Peso"].ToString();
					item.sTalla = row["Talla"].ToString();
					item.sTipoSangre = row["TipoSangre"].ToString();
					item.sEnfermedades = row["Enfermedades"].ToString();
					item.sNombreEnfermedades = row["NombreEnfermedades"].ToString();
					item.sProcedimientoCrisis = row["ProcedimientoCrisis"].ToString();
					item.sCertificado = row["Certificado"].ToString();
					item.sEnfermedadCertificado = row["EnfermedadCertificado"].ToString();
					item.sAlergia = row["Alergia"].ToString();
					item.sNombreAlergia = row["NombreAlergia"].ToString();
					item.sProcedimintoCrisisAlergia = row["ProcedimintoCrisisAlergia"].ToString();
					item.sNombreAccidente = row["NombreAccidente"].ToString();
					item.sTelefonoAccidente = row["TelefonoAccidente"].ToString();
					item.sNombreHospital = row["NombreHospital"].ToString();
					item.sMedico = row["Medico"].ToString();
					item.sNombreMedico = row["NombreMedico"].ToString();
					item.sTelefonoMedico = row["TelefonoMedico"].ToString();
					item.sCedulaMedico = row["CedulaMedico"].ToString();
					item.sAutorizaTraslado = row["AutorizaTraslado"].ToString();
					item.sProcedimientoAccidente = row["ProcedimientoAccidente"].ToString();
					item.sTutor = row["Tutor"].ToString();
					item.sBeca = row["Beca"].ToString();
					item.sFormaPago = row["FormaPago"].ToString();
				}
				return item;
			}
			throw new DbDataContextException(dbError);
		}

		public AlumnosBE ObtieneAlumno2Dat(string Alumno)
		{
			AlumnosBE item = new AlumnosBE();
			MySqlCommand dbCommand = new MySqlCommand("select NumeroMatricula, idAlumno, Apaterno, Amaterno, Nombres from Alumnos where idAlumno = '" + Alumno + "'")
			{
				CommandType = CommandType.Text
			};
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				foreach (DataRow row in DataTable.Rows)
				{
					item.sIdAlumno = row["IdAlumno"].ToString();
					item.sNumeroMatricula = row["NumeroMatricula"].ToString();
					item.sAPaterno = row["APaterno"].ToString();
					item.sAMaterno = row["AMaterno"].ToString();
					item.sNombres = row["Nombres"].ToString();
				}
				return item;
			}
			throw new DbDataContextException(dbError);
		}

		//public AlumnoDs ObtenerAlumnoRpt(string sMatricula)
		//{
		//	AlumnoDs dsAlumno = new AlumnoDs();
		//	MySqlCommand dbCommand = new MySqlCommand("proc_RPT_ALUMNO")
		//	{
		//		CommandType = CommandType.StoredProcedure
		//	};
		//	dbCommand.Parameters.Add("MATRICULA", MySqlDbType.VarChar).Value = sMatricula;
		//	if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
		//	{
		//		DataTable.TableName = "dtAlumno";
		//		dsAlumno.Tables.Add(DataTable);
		//		return dsAlumno;
		//	}
		//	throw new DbDataContextException(dbError);
		//}

		public List<GradoBE> ObtieneGradoDat(string Nivel)
		{
			List<GradoBE> oGradoLista = new List<GradoBE>();
			MySqlCommand dbCommand = new MySqlCommand("proc_LISTA_GRADO")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("NIVEL", MySqlDbType.VarChar).Value = Nivel;
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				foreach (DataRow row in DataTable.Rows)
				{
					GradoBE item = new GradoBE();
					item.sIDGrado = row["IDGRADO"].ToString();
					item.sDescripcionGrado = row["DESCRIPCIONGRADO"].ToString();
					oGradoLista.Add(item);
				}
				return oGradoLista;
			}
			throw new DbDataContextException(dbError);
		}

		public string AsignaAlumnoGrupoDat(string idAlumno, string grupo, string ciclo, string user)
		{
			string respuesta = string.Empty;
			MySqlCommand dbCommand = new MySqlCommand("proc_ASIGNA_ALUMNO_GRUPO")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("IDALUMNO", MySqlDbType.VarChar).Value = idAlumno;
			dbCommand.Parameters.Add("IDGRUPO", MySqlDbType.VarChar).Value = grupo;
			dbCommand.Parameters.Add("IDCICLO", MySqlDbType.VarChar).Value = ciclo;
			dbCommand.Parameters.Add("USUARIO", MySqlDbType.VarChar).Value = user;
			if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
			{
				if (rowsAffected > 0)
				{
					return "1";
				}
				return "0";
			}
			throw new DbDataContextException(dbError);
		}

		public List<AlumnosBE> ListaAlumnosSearchDat(string idColegio)
		{
			List<AlumnosBE> oAlumnosLista = new List<AlumnosBE>();
			MySqlCommand dbCommand = new MySqlCommand("select * from alumnos where idColegio=" + idColegio)
			{
				CommandType = CommandType.Text
			};
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				foreach (DataRow row in DataTable.Rows)
				{
					AlumnosBE item = new AlumnosBE();
					item.sIdAlumno = row["IdAlumno"].ToString();
					item.sNumeroMatricula = row["NumeroMatricula"].ToString();
					item.sNombres = row["NumeroMatricula"].ToString() + " - " + row["Nombres"].ToString() + " " + row["APaterno"].ToString() + " " + row["AMaterno"].ToString();
					item.sAPaterno = row["APaterno"].ToString();
					item.sAMaterno = row["AMaterno"].ToString();
					oAlumnosLista.Add(item);
				}
				return oAlumnosLista;
			}
			throw new DbDataContextException(dbError);
		}

		public List<PagosBE> ListaPagosAlumnoDat(string Alumno)
		{
			List<PagosBE> oPagosLista = new List<PagosBE>();
			MySqlCommand dbCommand = new MySqlCommand("proc_LISTA_PAGOS_ALUMNO")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("IDALUMNO", MySqlDbType.VarChar).Value = Alumno;
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				foreach (DataRow row in DataTable.Rows)
				{
					PagosBE item = new PagosBE();
					item.psIDPago = row["ID"].ToString();
					item.psIDAlumno = row["IDALUMNO"].ToString();
					item.psConcepto = row["CONCEPTO"].ToString();
					item.psMontoActual = row["MontoActual"].ToString();
					item.psEstatus = row["ESTATUS"].ToString();
					item.psFechaMovimiento = row["FechaMovimiento"].ToString();
					oPagosLista.Add(item);
				}
				return oPagosLista;
			}
			throw new DbDataContextException(dbError);
		}

		public AlumnosBE ObtieneInfoAlumnoDat(string Alumno)
		{
			AlumnosBE item = new AlumnosBE();
			MySqlCommand dbCommand = new MySqlCommand("select A.idAlumno, A.NumeroMatricula, A.APaterno, A.AMaterno , A.Nombres, G.DescripcionGrado, GR.NombreGrupo from Alumnos A, GRUPO GR, GRADO G where NumeroMatricula='" + Alumno + "' AND G.IDGrado = a.Grado and A.Grupo = gr.IDGrupo")
			{
				CommandType = CommandType.Text
			};
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				foreach (DataRow row in DataTable.Rows)
				{
					item.sIdAlumno = row["IdAlumno"].ToString();
					item.sNumeroMatricula = row["NumeroMatricula"].ToString();
					item.sAPaterno = row["APaterno"].ToString();
					item.sAMaterno = row["AMaterno"].ToString();
					item.sNombres = row["Nombres"].ToString();
					item.sGrado = row["DescripcionGrado"].ToString();
					item.sGrupo = row["NombreGrupo"].ToString();
				}
				return item;
			}
			throw new DbDataContextException(dbError);
		}

		//public RecibosDs ObtenerReciboRpt(string sAlumno)
		//{
		//	RecibosDs dsRecibo = new RecibosDs();
		//	MySqlCommand dbCommand = new MySqlCommand("proc_RPT_RECIBO")
		//	{
		//		CommandType = CommandType.StoredProcedure
		//	};
		//	dbCommand.Parameters.Add("IDALUMNO", MySqlDbType.VarChar, 50).Value = sAlumno;
		//	if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
		//	{
		//		DataTable.TableName = "dtRecibo";
		//		dsRecibo.Tables.Add(DataTable);
		//		MySqlCommand dbCommand2 = new MySqlCommand("proc_RPT_RECIBO_ALUMNO")
		//		{
		//			CommandType = CommandType.StoredProcedure
		//		};
		//		dbCommand.Parameters.Add("IDALUMNO", MySqlDbType.VarChar, 50).Value = sAlumno;
		//		if (ExecuteReader(ref dbCommand2, out var DataTable2, out var dbError2))
		//		{
		//			DataTable2.TableName = "dtReciboAlumno";
		//			dsRecibo.Tables.Add(DataTable2);
		//			return dsRecibo;
		//		}
		//		throw new DbDataContextException(dbError2);
		//	}
		//	throw new DbDataContextException(dbError);
		//}

		//public DeudoresDs ObtenerDeudoresRpt()
		//{
		//	DeudoresDs dsDeudores = new DeudoresDs();
		//	MySqlCommand dbCommand = new MySqlCommand("proc_LISTA_DEUDORES")
		//	{
		//		CommandType = CommandType.StoredProcedure
		//	};
		//	if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
		//	{
		//		DataTable.TableName = "dtDeudores";
		//		dsDeudores.Tables.Add(DataTable);
		//		return dsDeudores;
		//	}
		//	throw new DbDataContextException(dbError);
		//}

		//public CredencialDS ObtenerCredencialesRpt(string Matricula)
		//{
		//	CredencialDS dsCredencial = new CredencialDS();
		//	MySqlCommand dbCommand = new MySqlCommand("proc_RPT_CREDENCIAL")
		//	{
		//		CommandType = CommandType.StoredProcedure
		//	};
		//	dbCommand.Parameters.Add("MATRICULA", MySqlDbType.VarChar, 300).Value = Matricula;
		//	if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
		//	{
		//		DataTable.TableName = "dtCredencial";
		//		dsCredencial.Tables.Add(DataTable);
		//		return dsCredencial;
		//	}
		//	throw new DbDataContextException(dbError);
		//}
	}

}

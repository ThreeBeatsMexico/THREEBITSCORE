using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
	public class SchoolServiceDA : SqlDataContext, ISchoolServiceDA
	{
		private readonly ILogger _logger;

		private readonly IConfiguration _configuration;

		public SchoolServiceDA(ILogger<SchoolServiceDA> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_connectionString = _configuration["ConnectionStrings:SchoolConnection"];
		}

		public DataTable getAlumnosDA(AlumnosBE item)
		{
			SqlCommand dbCommand = new SqlCommand("proc_LISTA_ALUMNOS")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("IDCOLEGIO", SqlDbType.VarChar).Value = item.sIdColegio;
			dbCommand.Parameters.Add("MATRICULA", SqlDbType.VarChar).Value = item.sNumeroMatricula;
			dbCommand.Parameters.Add("NOMBRES", SqlDbType.VarChar).Value = item.sNombres;
			dbCommand.Parameters.Add("APATERNO", SqlDbType.VarChar).Value = item.sAPaterno;
			dbCommand.Parameters.Add("AMATERNO", SqlDbType.VarChar).Value = item.sAMaterno;
			dbCommand.Parameters.Add("FECHANACIMIENTO", SqlDbType.VarChar).Value = item.sFechaNacimiento;
			dbCommand.Parameters.Add("ESTATUS", SqlDbType.VarChar).Value = item.sEstatus;
			if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
			{
				return DataTable;
			}
			throw new DbDataContextException(dbError);
		}

		public string fnRegistroAlumnoDat(AlumnosBE item)
		{
			string sRespuesta = string.Empty;
			SqlCommand dbCommand = new SqlCommand("proc_ALUMNOS")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("NumeroMatricula", SqlDbType.VarChar).Value = item.sNumeroMatricula;
			dbCommand.Parameters.Add("APaterno", SqlDbType.VarChar).Value = item.sAPaterno;
			dbCommand.Parameters.Add("AMaterno", SqlDbType.VarChar).Value = item.sAMaterno;
			dbCommand.Parameters.Add("Nombres", SqlDbType.VarChar).Value = item.sNombres;
			dbCommand.Parameters.Add("FechaNacimiento", SqlDbType.VarChar).Value = item.sFechaNacimiento;
			dbCommand.Parameters.Add("Sexo", SqlDbType.VarChar).Value = item.sSexo;
			dbCommand.Parameters.Add("Nacionalidad", SqlDbType.VarChar).Value = item.sNacionalidad;
			dbCommand.Parameters.Add("Grado", SqlDbType.VarChar).Value = item.sGrado;
			dbCommand.Parameters.Add("EscuelaProcedencia", SqlDbType.VarChar).Value = item.sEscuelaProcedencia;
			dbCommand.Parameters.Add("Hermanos", SqlDbType.VarChar).Value = item.sHermanos;
			dbCommand.Parameters.Add("GradoHermanos", SqlDbType.VarChar).Value = item.sGradoHermanos;
			dbCommand.Parameters.Add("Calle", SqlDbType.VarChar).Value = item.sCalle;
			dbCommand.Parameters.Add("Numero", SqlDbType.VarChar).Value = item.sNumero;
			dbCommand.Parameters.Add("Colonia", SqlDbType.VarChar).Value = item.sColonia;
			dbCommand.Parameters.Add("Delegacion", SqlDbType.VarChar).Value = item.sDelegacion;
			dbCommand.Parameters.Add("Estado", SqlDbType.VarChar).Value = item.sEstado;
			dbCommand.Parameters.Add("CodigoPostal", SqlDbType.VarChar).Value = item.sCodigoPostal;
			dbCommand.Parameters.Add("Telefono", SqlDbType.VarChar).Value = item.sTelefono;
			dbCommand.Parameters.Add("Email", SqlDbType.VarChar).Value = item.sEmail;
			dbCommand.Parameters.Add("Curp", SqlDbType.VarChar).Value = item.sCurp;
			dbCommand.Parameters.Add("EdadAnos", SqlDbType.VarChar).Value = item.sEdadAnos;
			dbCommand.Parameters.Add("EdadMeses", SqlDbType.VarChar).Value = item.sEdadMeses;
			dbCommand.Parameters.Add("Foto", SqlDbType.VarChar).Value = item.sFoto;
			dbCommand.Parameters.Add("NivelAcademico", SqlDbType.VarChar).Value = item.sNivelAcademico;
			dbCommand.Parameters.Add("NombrePadreTutor", SqlDbType.VarChar).Value = item.sNombrePadreTutor;
			dbCommand.Parameters.Add("OcupacionPadre", SqlDbType.VarChar).Value = item.sOcupacionPadre;
			dbCommand.Parameters.Add("TelefonoPadre", SqlDbType.VarChar).Value = item.sTelefonoPadre;
			dbCommand.Parameters.Add("TelefonoTrabajoPadre", SqlDbType.VarChar).Value = item.sTelefonoTrabajoPadre;
			dbCommand.Parameters.Add("CelularPadre", SqlDbType.VarChar).Value = item.sCelularPadre;
			dbCommand.Parameters.Add("FechaNacimientoPadre", SqlDbType.VarChar).Value = item.sFechaNacimientoPadre;
			dbCommand.Parameters.Add("SueldoPadre", SqlDbType.VarChar).Value = item.sSueldoPadre;
			dbCommand.Parameters.Add("NacionalidadPadre", SqlDbType.VarChar).Value = item.sNacionalidadPadre;
			dbCommand.Parameters.Add("NombreMadreTutor", SqlDbType.VarChar).Value = item.sNombreMadreTutor;
			dbCommand.Parameters.Add("OcupacionMadre", SqlDbType.VarChar).Value = item.sOcupacionMadre;
			dbCommand.Parameters.Add("TelefonoMadre", SqlDbType.VarChar).Value = item.sTelefonoMadre;
			dbCommand.Parameters.Add("TelefonoTrabajoMadre", SqlDbType.VarChar).Value = item.sTelefonoTrabajoMadre;
			dbCommand.Parameters.Add("CelularMadre", SqlDbType.VarChar).Value = item.sCelularMadre;
			dbCommand.Parameters.Add("FechaNacimientoMadre", SqlDbType.VarChar).Value = item.sFechaNacimientoMadre;
			dbCommand.Parameters.Add("SueldoMadre", SqlDbType.VarChar).Value = item.sSueldoMadre;
			dbCommand.Parameters.Add("NacionalidadMadre", SqlDbType.VarChar).Value = item.sNacionalidadMadre;
			dbCommand.Parameters.Add("NombreFamVecino", SqlDbType.VarChar).Value = item.sNombreFamVecino;
			dbCommand.Parameters.Add("TelefonoVecino", SqlDbType.VarChar).Value = item.sTelefonoVecino;
			dbCommand.Parameters.Add("TelefonoTrabajoVecino", SqlDbType.VarChar).Value = item.sTelefonoTrabajoVecino;
			dbCommand.Parameters.Add("CelularVecino", SqlDbType.VarChar).Value = item.sCelularVecino;
			dbCommand.Parameters.Add("EducacionFisica", SqlDbType.VarChar).Value = item.sEducacionFisica;
			dbCommand.Parameters.Add("Medicamento", SqlDbType.VarChar).Value = item.sMedicamento;
			dbCommand.Parameters.Add("NombreMedicamento", SqlDbType.VarChar).Value = item.sNombreMedicamento;
			dbCommand.Parameters.Add("DosisMedicamento", SqlDbType.VarChar).Value = item.sDosisMedicamento;
			dbCommand.Parameters.Add("Peso", SqlDbType.VarChar).Value = item.sPeso;
			dbCommand.Parameters.Add("Talla", SqlDbType.VarChar).Value = item.sTalla;
			dbCommand.Parameters.Add("TipoSangre", SqlDbType.VarChar).Value = item.sTipoSangre;
			dbCommand.Parameters.Add("Enfermedades", SqlDbType.VarChar).Value = item.sEnfermedades;
			dbCommand.Parameters.Add("NombreEnfermedades", SqlDbType.VarChar).Value = item.sNombreEnfermedades;
			dbCommand.Parameters.Add("ProcedimientoCrisis", SqlDbType.VarChar).Value = item.sProcedimientoCrisis;
			dbCommand.Parameters.Add("Certificado", SqlDbType.VarChar).Value = item.sCertificado;
			dbCommand.Parameters.Add("EnfermedadCertificado", SqlDbType.VarChar).Value = item.sEnfermedadCertificado;
			dbCommand.Parameters.Add("Alergia", SqlDbType.VarChar).Value = item.sAlergia;
			dbCommand.Parameters.Add("NombreAlergia", SqlDbType.VarChar).Value = item.sNombreAlergia;
			dbCommand.Parameters.Add("ProcedimintoCrisisAlergia", SqlDbType.VarChar).Value = item.sProcedimintoCrisisAlergia;
			dbCommand.Parameters.Add("NombreAccidente", SqlDbType.VarChar).Value = item.sNombreAccidente;
			dbCommand.Parameters.Add("TelefonoAccidente", SqlDbType.VarChar).Value = item.sTelefonoAccidente;
			dbCommand.Parameters.Add("NombreHospital", SqlDbType.VarChar).Value = item.sNombreHospital;
			dbCommand.Parameters.Add("Medico", SqlDbType.VarChar).Value = item.sMedico;
			dbCommand.Parameters.Add("NombreMedico", SqlDbType.VarChar).Value = item.sNombreMedico;
			dbCommand.Parameters.Add("TelefonoMedico", SqlDbType.VarChar).Value = item.sTelefonoMedico;
			dbCommand.Parameters.Add("CedulaMedico", SqlDbType.VarChar).Value = item.sCedulaMedico;
			dbCommand.Parameters.Add("AutorizaTraslado", SqlDbType.VarChar).Value = item.sAutorizaTraslado;
			dbCommand.Parameters.Add("ProcedimientoAccidente", SqlDbType.VarChar).Value = item.sProcedimientoAccidente;
			dbCommand.Parameters.Add("NombreUsuario", SqlDbType.VarChar).Value = item.sUsuario;
			dbCommand.Parameters.Add("Tutor", SqlDbType.VarChar).Value = item.sTutor;
			dbCommand.Parameters.Add("Estatus", SqlDbType.VarChar).Value = item.sEstatus;
			dbCommand.Parameters.Add("ServerPath", SqlDbType.VarChar).Value = item.sServerPath;
			dbCommand.Parameters.Add("Beca", SqlDbType.VarChar).Value = item.sBeca;
			dbCommand.Parameters.Add("FormaPago", SqlDbType.VarChar).Value = item.sFormaPago;
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
			SqlCommand dbCommand = new SqlCommand("proc_LISTA_ALUMNOS")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("@IdColegio", SqlDbType.VarChar).Value = oAlumnosBE.sIdColegio;
			dbCommand.Parameters.Add("@MATRICULA", SqlDbType.VarChar).Value = oAlumnosBE.sNumeroMatricula;
			dbCommand.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = oAlumnosBE.sNombres;
			dbCommand.Parameters.Add("@APaterno", SqlDbType.VarChar).Value = oAlumnosBE.sAPaterno;
			dbCommand.Parameters.Add("@AMaterno", SqlDbType.VarChar).Value = oAlumnosBE.sAMaterno;
			dbCommand.Parameters.Add("@FechaNacimiento", SqlDbType.VarChar).Value = oAlumnosBE.sFechaNacimiento;
			dbCommand.Parameters.Add("@Estatus", SqlDbType.VarChar).Value = oAlumnosBE.sEstatus;
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
			SqlCommand dbCommand = new SqlCommand("proc_LISTA_ALUMNOS_GRUPO")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("IDGRADO", SqlDbType.VarChar).Value = idGrado;
			dbCommand.Parameters.Add("IDGRUPO", SqlDbType.VarChar).Value = idGrupo;
			dbCommand.Parameters.Add("IDCICLO", SqlDbType.VarChar).Value = idCiclo;
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
			SqlCommand dbCommand = new SqlCommand("proc_LISTA_ALUMNOS_GRUPO_ADD")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("IDGRADO", SqlDbType.VarChar).Value = idGrado;
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
			SqlCommand dbCommand = new SqlCommand("select a.*, b.* from Alumnos a, InfoAlumnos b where a.NumeroMatricula = b.NumeroMatricula and a.NumeroMatricula = '" + Alumno + "'")
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
			SqlCommand dbCommand = new SqlCommand("select NumeroMatricula, idAlumno, Apaterno, Amaterno, Nombres from Alumnos where idAlumno = '" + Alumno + "'")
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
		//	SqlCommand dbCommand = new SqlCommand("proc_RPT_ALUMNO")
		//	{
		//		CommandType = CommandType.StoredProcedure
		//	};
		//	dbCommand.Parameters.Add("MATRICULA", SqlDbType.VarChar).Value = sMatricula;
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
			SqlCommand dbCommand = new SqlCommand("proc_LISTA_GRADO")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("NIVEL", SqlDbType.VarChar).Value = Nivel;
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
			SqlCommand dbCommand = new SqlCommand("proc_ASIGNA_ALUMNO_GRUPO")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("IDALUMNO", SqlDbType.VarChar).Value = idAlumno;
			dbCommand.Parameters.Add("IDGRUPO", SqlDbType.VarChar).Value = grupo;
			dbCommand.Parameters.Add("IDCICLO", SqlDbType.VarChar).Value = ciclo;
			dbCommand.Parameters.Add("USUARIO", SqlDbType.VarChar).Value = user;
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
			SqlCommand dbCommand = new SqlCommand("select * from alumnos where idColegio=" + idColegio)
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
			SqlCommand dbCommand = new SqlCommand("proc_LISTA_PAGOS_ALUMNO")
			{
				CommandType = CommandType.StoredProcedure
			};
			dbCommand.Parameters.Add("IDALUMNO", SqlDbType.VarChar).Value = Alumno;
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
			SqlCommand dbCommand = new SqlCommand("select A.idAlumno, A.NumeroMatricula, A.APaterno, A.AMaterno , A.Nombres, G.DescripcionGrado, GR.NombreGrupo from Alumnos A, GRUPO GR, GRADO G where NumeroMatricula='" + Alumno + "' AND G.IDGrado = a.Grado and A.Grupo = gr.IDGrupo")
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
		//	SqlCommand dbCommand = new SqlCommand("proc_RPT_RECIBO")
		//	{
		//		CommandType = CommandType.StoredProcedure
		//	};
		//	dbCommand.Parameters.Add("IDALUMNO", SqlDbType.VarChar, 50).Value = sAlumno;
		//	if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
		//	{
		//		DataTable.TableName = "dtRecibo";
		//		dsRecibo.Tables.Add(DataTable);
		//		SqlCommand dbCommand2 = new SqlCommand("proc_RPT_RECIBO_ALUMNO")
		//		{
		//			CommandType = CommandType.StoredProcedure
		//		};
		//		dbCommand.Parameters.Add("IDALUMNO", SqlDbType.VarChar, 50).Value = sAlumno;
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
		//	SqlCommand dbCommand = new SqlCommand("proc_LISTA_DEUDORES")
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
		//	SqlCommand dbCommand = new SqlCommand("proc_RPT_CREDENCIAL")
		//	{
		//		CommandType = CommandType.StoredProcedure
		//	};
		//	dbCommand.Parameters.Add("MATRICULA", SqlDbType.VarChar, 300).Value = Matricula;
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

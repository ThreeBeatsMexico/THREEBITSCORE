using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.Common;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Security.Users;
using static ThreeBits.Data.Common.MySqlDataContext;

namespace ThreeBits.Services.Security.User
{
	public class UserServiceDA : MySqlDataContext, IUserServiceDA
	{
		private readonly ILogger _logger;

		private readonly IConfiguration _configuration;

		public UserServiceDA(ILogger<SecurityServiceDA> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
            _MySqlconnectionString = _configuration["ConnectionStrings:MySqlConnection"];
		}

		public UsuariosBE addUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, long App)
		{
			UsuariosBE UsuarioRes = new UsuariosBE();
			long IdUsuario = 0L;
			try
			{
				MySqlCommand dbCommand = new MySqlCommand("spFront_insUser")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = Usuario.IDAPLICACION;
				dbCommand.Parameters.Add("p_IDSEXO", MySqlDbType.Int32).Value = ((Usuario.IDSEXO > 0) ? new Int32?(Usuario.IDSEXO) : null);
				dbCommand.Parameters.Add("p_IDTIPOPERSONA", MySqlDbType.Int32).Value = ((Usuario.IDTIPOPERSONA > 0) ? new Int32?(Usuario.IDTIPOPERSONA) : null);
				dbCommand.Parameters.Add("p_IDESTADOCIVIL", MySqlDbType.Int32).Value = ((Usuario.IDESTADOCIVIL > 0) ? new Int32?(Usuario.IDESTADOCIVIL) : null);
				dbCommand.Parameters.Add("p_IDAREA", MySqlDbType.Int32).Value = ((Usuario.IDAREA > 0) ? new Int32?(Usuario.IDAREA) : null);
				dbCommand.Parameters.Add("p_IDTIPOUSUARIO", MySqlDbType.Int32).Value = ((Usuario.IDTIPOUSUARIO > 0) ? new Int32?(Usuario.IDTIPOUSUARIO) : null);
				dbCommand.Parameters.Add("p_IDUSUARIOAPP", MySqlDbType.VarChar).Value = Usuario.IDUSUARIOAPP;
				dbCommand.Parameters.Add("p_APATERNO", MySqlDbType.VarChar).Value = Usuario.APATERNO;
				dbCommand.Parameters.Add("p_AMATERNO", MySqlDbType.VarChar).Value = Usuario.AMATERNO;
				dbCommand.Parameters.Add("p_NOMBRE", MySqlDbType.VarChar).Value = Usuario.NOMBRE;
				dbCommand.Parameters.Add("p_FECHANACCONST", MySqlDbType.DateTime).Value = Usuario.FECHANACCONST;
				dbCommand.Parameters.Add("p_USUARIO", MySqlDbType.VarChar).Value = Usuario.USUARIO;
				dbCommand.Parameters.Add("p_PASSWORD", MySqlDbType.VarChar).Value = Usuario.PASSWORD;
				dbCommand.Parameters.Add("p_RUTAFOTOPERFIL", MySqlDbType.VarChar).Value = Usuario.RUTAFOTOPERFIL;
				dbCommand.Parameters.Add("p_FECHAALTA", MySqlDbType.DateTime).Value = DateTime.Now;
				dbCommand.Parameters.Add("p_ACTIVO", MySqlDbType.Bit).Value = Usuario.ACTIVO;
				dbCommand.Parameters.Add("p_IDUSERMODIFICA", MySqlDbType.Int64).Value = ((Reglas.IDUSRMODIF > 0) ? new long?(Reglas.IDUSRMODIF) : null);
				dbCommand.Parameters.Add("p_IDAPPMODIFICA", MySqlDbType.Int64).Value = App;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					{
						IEnumerator enumerator = DataTable.Rows.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								IdUsuario = (UsuarioRes.IDUSUARIO = long.Parse(((DataRow)enumerator.Current)["SCOPE_IDENTITY"].ToString()));
								UsuarioRes.IDUSUARIOAPP = Usuario.IDUSUARIOAPP.ToString();
							}
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
					foreach (DomicilioBE Dom in Domicilios)
					{
						MySqlCommand dbCommandUD = new MySqlCommand("spFront_insDomicilio")
						{
							CommandType = CommandType.StoredProcedure
						};
						dbCommandUD.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = IdUsuario;
						dbCommandUD.Parameters.Add("p_CALLE", MySqlDbType.VarChar).Value = Dom.CALLE;
						dbCommandUD.Parameters.Add("p_NUMEXT", MySqlDbType.VarChar).Value = Dom.NUMEXT;
						dbCommandUD.Parameters.Add("p_NUMINT", MySqlDbType.VarChar).Value = Dom.NUMINT;
						dbCommandUD.Parameters.Add("p_IDESTADO", MySqlDbType.Int32).Value = ((!string.IsNullOrEmpty(Dom.IDESTADO)) ? new Int32?(Int32.Parse(Dom.IDESTADO)) : null);
						dbCommandUD.Parameters.Add("p_ESTADO", MySqlDbType.VarChar).Value = Dom.ESTADO;
						dbCommandUD.Parameters.Add("p_IDMUN", MySqlDbType.Int32).Value = ((!string.IsNullOrEmpty(Dom.IDMUNICIPIO)) ? new Int32?(Int32.Parse(Dom.IDMUNICIPIO)) : null);
						dbCommandUD.Parameters.Add("p_MUNICIPIO", MySqlDbType.VarChar).Value = Dom.MUNICIPIO;
						dbCommandUD.Parameters.Add("p_IDCOLONIA", MySqlDbType.Int32).Value = ((!string.IsNullOrEmpty(Dom.IDCOLONIA)) ? new Int32?(Int32.Parse(Dom.IDCOLONIA)) : null);
						dbCommandUD.Parameters.Add("p_COLONIA", MySqlDbType.VarChar).Value = Dom.COLONIA;
						dbCommandUD.Parameters.Add("p_CP", MySqlDbType.VarChar).Value = Dom.CP;
						dbCommandUD.Parameters.Add("p_FECHAALTA", MySqlDbType.DateTime).Value = DateTime.Now;
						dbCommandUD.Parameters.Add("p_ACTIVO", MySqlDbType.Bit).Value = true;
						dbCommandUD.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = App;
						dbCommandUD.Parameters.Add("p_IDUSERMODIFICA", MySqlDbType.Int64).Value = ((Reglas.IDUSRMODIF > 0) ? new long?(Reglas.IDUSRMODIF) : null);
						dbCommandUD.Parameters.Add("p_IDAPPMODIFICA", MySqlDbType.Int64).Value = App;
						if (!ExecuteNonQuery(ref dbCommandUD, out var _, out var dbErrorUD))
						{
							throw new DbDataContextException(dbErrorUD);
						}
					}
					foreach (ContactoBE Contacto in Contactos)
					{
						MySqlCommand dbCommandIC = new MySqlCommand("spFront_insContacto")
						{
							CommandType = CommandType.StoredProcedure
						};
						dbCommandIC.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = IdUsuario;
						dbCommandIC.Parameters.Add("p_IDTIPOCONTACTO", MySqlDbType.Int32).Value = Contacto.IDTIPOCONTACTO;
						dbCommandIC.Parameters.Add("p_VALOR", MySqlDbType.VarChar).Value = Contacto.VALOR;
						dbCommandIC.Parameters.Add("p_FECHAALTA", MySqlDbType.DateTime).Value = DateTime.Now;
						dbCommandIC.Parameters.Add("p_ACTIVO", MySqlDbType.Bit).Value = true;
						dbCommandIC.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = App;
						dbCommandIC.Parameters.Add("p_IDUSERMODIFICA", MySqlDbType.Int64).Value = ((Reglas.IDUSRMODIF > 0) ? new long?(Reglas.IDUSRMODIF) : null);
						dbCommandIC.Parameters.Add("p_IDAPPMODIFICA", MySqlDbType.Int64).Value = App;
						if (!ExecuteNonQuery(ref dbCommandIC, out var _, out var dbErrorIC))
						{
							throw new DbDataContextException(dbErrorIC);
						}
					}
					foreach (RolesXUsuarioBE Rol2 in RolesXUsuario)
					{
						MySqlCommand dbCommandUXAP = new MySqlCommand("spFrontAddUsuarioXAplicacion")
						{
							CommandType = CommandType.StoredProcedure
						};
						dbCommandUXAP.Parameters.Add("p_IDUSRSXAPP", MySqlDbType.VarChar).Value = long.Parse(Rol2.IDAPLICACION);
						dbCommandUXAP.Parameters.Add("p_IDAPLICACION", MySqlDbType.VarChar).Value = IdUsuario;
						dbCommandUXAP.Parameters.Add("p_IDUSUARIO", MySqlDbType.VarChar).Value = true;
						if (!ExecuteNonQuery(ref dbCommandUXAP, out var _, out var dbErrorUXAP))
						{
							throw new DbDataContextException(dbErrorUXAP);
						}
					}
					foreach (RolesXUsuarioBE Rol in RolesXUsuario)
					{
						MySqlCommand dbCommandRXU = new MySqlCommand("spFront_insRolXUserApp")
						{
							CommandType = CommandType.StoredProcedure
						};
						dbCommandRXU.Parameters.Add("p_IDROL", MySqlDbType.Int64).Value = Rol.IDROL;
						dbCommandRXU.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = IdUsuario;
						dbCommandRXU.Parameters.Add("p_IDESTACIONXAPP", MySqlDbType.Int64).Value = ((Rol.IDESTACIONXAPP > 0) ? new long?(Rol.IDESTACIONXAPP) : null);
						dbCommandRXU.Parameters.Add("p_IDROLXUSUARIO", MySqlDbType.Int64).Value = ((Rol.IDROLXUSUARIO > 0) ? new long?(Rol.IDROLXUSUARIO) : null);
						dbCommandRXU.Parameters.Add("p_ACTIVO", MySqlDbType.Bit).Value = Rol.ACTIVO;
						if (!ExecuteNonQuery(ref dbCommandRXU, out var _, out var dbErrorRXU))
						{
							throw new DbDataContextException(dbErrorRXU);
						}
					}
					return UsuarioRes;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public DatosUsuarioBE GetUsuarioFull(ReglasBE Reglas, long App)
		{
			try
			{
				DatosUsuarioBE DatosUsuarioRES = new DatosUsuarioBE();
				UsuariosBE UsuarioRES = new UsuariosBE();
				MySqlCommand dbCommand = new MySqlCommand("spFront_getUsuario")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_TIPOBUSQUEDA", MySqlDbType.Int32).Value = Reglas.TIPOBUSQUEDA;
				dbCommand.Parameters.Add("p_USUARIO", MySqlDbType.VarChar).Value = Reglas.USUARIO;
				dbCommand.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = Reglas.IDAPP;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row4 in DataTable.Rows)
					{
						UsuarioRES.IDUSUARIO = Convert.ToInt64(row4["IDUSUARIO"]);
						UsuarioRES.IDAPLICACION = Convert.ToInt64(row4["IDAPLICACION"]);
						UsuarioRES.IDSEXO = Convert.ToInt32(row4["IDSEXO"]);
						UsuarioRES.IDTIPOPERSONA = Convert.ToInt32(row4["IDTIPOPERSONA"]);
						UsuarioRES.IDESTADOCIVIL = Convert.ToInt32(row4["IDESTADOCIVIL"]);
						UsuarioRES.IDAREA = Convert.ToInt32(row4["IDAREA"]);
						UsuarioRES.DESCAREA = row4["DESCAREA"].ToString();
						UsuarioRES.IDTIPOUSUARIO = Convert.ToInt32(row4["IDTIPOUSUARIO"]);
						UsuarioRES.DESCTIPOUSUARIO = row4["DESCIDTIPOUSUARIO"].ToString();
						UsuarioRES.IDUSUARIOAPP = row4["IDUSUARIOAPP"].ToString();
						UsuarioRES.APATERNO = row4["APATERNO"].ToString();
						UsuarioRES.AMATERNO = row4["AMATERNO"].ToString();
						UsuarioRES.NOMBRE = row4["NOMBRE"].ToString();
						UsuarioRES.FECHANACCONST = Convert.ToDateTime(row4["FECHANACCONST"]);
						UsuarioRES.USUARIO = row4["USUARIO"].ToString();
						UsuarioRES.PASSWORD = row4["PASSWORD"].ToString();
						UsuarioRES.RUTAFOTOPERFIL = row4["RUTAFOTOPERFIL"].ToString();
						UsuarioRES.FECHAALTA = Convert.ToDateTime(row4["FECHAALTA"]);
						UsuarioRES.ACTIVO = Convert.ToBoolean(row4["ACTIVO"]);
					}
					DatosUsuarioRES.Usuario = UsuarioRES;
					
					if (DatosUsuarioRES.Usuario.IDUSUARIO == 0)
					{
						return DatosUsuarioRES;
					}
					MySqlCommand dbCommandUD = new MySqlCommand("spFront_getDomicilios")
					{
						CommandType = CommandType.StoredProcedure
					};
					dbCommandUD.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = DatosUsuarioRES.Usuario.IDUSUARIO;
					if (ExecuteReader(ref dbCommandUD, out var DataTableUD, out var dbErrorUD))
					{
						List<DomicilioBE> lstDomicilios = new List<DomicilioBE>();
						foreach (DataRow row3 in DataTableUD.Rows)
						{
							DomicilioBE DomicilioRES = new DomicilioBE();
							DomicilioRES.IDDOMICILIO = Convert.ToInt64(row3["IDDOMICILIO"]);
							DomicilioRES.IDUSUARIO = Convert.ToInt32(row3["IDUSUARIO"]);
							DomicilioRES.CALLE = row3["CALLE"].ToString();
							DomicilioRES.NUMEXT = row3["NUMEXT"].ToString();
							DomicilioRES.NUMINT = row3["NUMINT"].ToString();
							DomicilioRES.IDESTADO = (string.IsNullOrEmpty(row3["IDESTADO"].ToString()) ? "0" : row3["IDESTADO"].ToString());
							DomicilioRES.ESTADO = row3["ESTADO"].ToString();
							DomicilioRES.IDMUNICIPIO = (string.IsNullOrEmpty(row3["IDMUN"].ToString()) ? "0" : row3["IDMUN"].ToString());
							DomicilioRES.MUNICIPIO = row3["MUNICIPIO"].ToString();
							DomicilioRES.IDCOLONIA = (string.IsNullOrEmpty(row3["IDCOLONIA"].ToString()) ? "0" : row3["IDCOLONIA"].ToString());
							DomicilioRES.COLONIA = row3["COLONIA"].ToString();
							DomicilioRES.CP = row3["CP"].ToString();
							DomicilioRES.FECHAALTA = Convert.ToDateTime(row3["FECHAALTA"]);
							DomicilioRES.ACTIVO = Convert.ToBoolean(row3["ACTIVO"]);
							lstDomicilios.Add(DomicilioRES);
						}
						DatosUsuarioRES.Domicilios = lstDomicilios;
						MySqlCommand dbCommandUC = new MySqlCommand("spFront_getContactos")
						{
							CommandType = CommandType.StoredProcedure
						};
						dbCommandUC.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = DatosUsuarioRES.Usuario.IDUSUARIO;
						if (ExecuteReader(ref dbCommandUC, out var DataTableUC, out var dbErrorUC))
						{
							List<ContactoBE> lstContactos = new List<ContactoBE>();
							foreach (DataRow row2 in DataTableUC.Rows)
							{
								ContactoBE ContactoRES = new ContactoBE();
								ContactoRES.IDCONTACTO = Convert.ToInt64(row2["IDCONTACTO"]);
								ContactoRES.IDUSUARIO = Convert.ToInt64(row2["IDUSUARIO"]);
								ContactoRES.IDTIPOCONTACTO = Convert.ToInt32(row2["IDTIPOCONTACTO"]);
								ContactoRES.TIPOCONTACTO = row2["TIPOCONTACTO"].ToString();
								ContactoRES.VALOR = row2["VALOR"].ToString();
								ContactoRES.FECHAALTA = Convert.ToDateTime(row2["FECHAALTA"]);
								ContactoRES.ACTIVO = Convert.ToBoolean(row2["ACTIVO"]);
								lstContactos.Add(ContactoRES);
							}
							DatosUsuarioRES.Contactos = lstContactos;
							MySqlCommand dbCommandRXU = new MySqlCommand("spFront_getRolesXUserApp")
							{
								CommandType = CommandType.StoredProcedure
							};
							dbCommandRXU.Parameters.Add("p_TIPOBUSQUEDA", MySqlDbType.Int32).Value = Reglas.TIPOBUSQUEDA;
							dbCommandRXU.Parameters.Add("p_USUARIO", MySqlDbType.VarChar).Value = Reglas.USUARIO;
							dbCommandRXU.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = Reglas.IDAPP;
							if (ExecuteReader(ref dbCommandRXU, out var DataTableRXU, out var dbErrorRXU))
							{
								List<RolesXUsuarioBE> lstRoles = new List<RolesXUsuarioBE>();
								foreach (DataRow row in DataTableRXU.Rows)
								{
									RolesXUsuarioBE RolesXUsuario = new RolesXUsuarioBE();
									RolesXUsuario.IDROLXUSUARIO = Convert.ToInt64(row["IDROLXUSUARIO"]);
									RolesXUsuario.IDROL = Convert.ToInt64(row["IDROL"]);
									RolesXUsuario.DESCROL = row["DESCROL"].ToString();
									RolesXUsuario.IDUSUARIO = Convert.ToInt64(row["IDUSUARIO"]);
									RolesXUsuario.IDESTACIONXAPP = Convert.ToInt64(row["IDESTACIONXAPP"]);
									RolesXUsuario.IDAPLICACION = row["IDAPLICACION"].ToString();
									RolesXUsuario.APLICACION = row["DescripcionAplicacion"].ToString();
									RolesXUsuario.ACTIVO = Convert.ToBoolean(row["ACTIVO"]);
									lstRoles.Add(RolesXUsuario);
								}
								DatosUsuarioRES.RolesXUsuario = lstRoles;
								return DatosUsuarioRES;
							}
							throw new DbDataContextException(dbErrorRXU);
						}
						throw new DbDataContextException(dbErrorUC);
					}
					throw new DbDataContextException(dbErrorUD);
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", Reglas.IDAPP.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<UsuariosBE> GetUsuarios(UsuariosBE item, long App)
		{
			List<UsuariosBE> lstUsuarios = new List<UsuariosBE>();
			try
			{
				new DatosUsuarioBE();
				MySqlCommand dbCommand = new MySqlCommand("spFrontGetUsuarios")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IdAplicacion", MySqlDbType.VarChar).Value = Int32.Parse(item.IDAPLICACION.ToString());
				dbCommand.Parameters.Add("p_Nombre", MySqlDbType.VarChar).Value = item.NOMBRE;
				dbCommand.Parameters.Add("p_AMaterno", MySqlDbType.VarChar).Value = item.AMATERNO;
				dbCommand.Parameters.Add("p_APaterno", MySqlDbType.VarChar).Value = item.APATERNO;
				dbCommand.Parameters.Add("p_Usuario", MySqlDbType.VarChar).Value = item.IDUSUARIOAPP;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						UsuariosBE itemLector = new UsuariosBE();
						itemLector.IDUSUARIO = Convert.ToInt64(row["IDUSUARIO"]);
						itemLector.DESCAREA = row["AREA"].ToString();
						itemLector.APATERNO = row["APATERNO"].ToString();
						itemLector.AMATERNO = row["AMATERNO"].ToString();
						itemLector.NOMBRE = row["NOMBRE"].ToString();
						itemLector.FECHANACCONST = Convert.ToDateTime(row["FECHANACCONST"]);
						itemLector.USUARIO = row["USUARIO"].ToString();
						itemLector.ACTIVO = bool.Parse(string.IsNullOrEmpty(row["ACTIVO"].ToString()) ? "false" : "true");
						lstUsuarios.Add(itemLector);
					}
					return lstUsuarios;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<UsuariosBE> GetUsuario(UsuariosBE item, long App)
		{
			List<UsuariosBE> lstUsuarios = new List<UsuariosBE>();
			try
			{
				new DatosUsuarioBE();
				MySqlCommand dbCommand = new MySqlCommand("spFrontGetUsuario")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IdUsuario", MySqlDbType.VarChar).Value = item.IDUSUARIO.ToString();
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						UsuariosBE itemLector = new UsuariosBE();
						itemLector.IDUSUARIO = Convert.ToInt64(row["IDUSUARIO"]);
						itemLector.IDSEXO = Convert.ToInt32(row["IDSEXO"]);
						itemLector.IDTIPOPERSONA = Convert.ToInt32(row["IDTIPOPERSONA"]);
						itemLector.IDESTADOCIVIL = Convert.ToInt32(row["IDESTADOCIVIL"]);
						itemLector.IDAREA = Convert.ToInt32(row["IDAREA"]);
						itemLector.IDTIPOUSUARIO = Convert.ToInt32(row["IDTIPOUSUARIO"]);
						itemLector.APATERNO = row["APATERNO"].ToString();
						itemLector.AMATERNO = row["AMATERNO"].ToString();
						itemLector.NOMBRE = row["NOMBRE"].ToString();
						itemLector.FECHANACCONST = Convert.ToDateTime(row["FECHANACCONST"]);
						itemLector.USUARIO = row["USUARIO"].ToString();
						itemLector.PASSWORD = row["PASSWORD"].ToString();
						itemLector.RUTAFOTOPERFIL = row["RUTAFOTOPERFIL"].ToString();
						itemLector.FECHAALTA = DateTime.Parse(row["FECHAALTA"].ToString());
						itemLector.ACTIVO = bool.Parse(row["ACTIVO"].ToString());
						lstUsuarios.Add(itemLector);
					}
					return lstUsuarios;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool actDeactivateUsuario(ReglasBE Reglas, long App)
		{
			try
			{
				bool Respuesta = true;
				MySqlCommand dbCommand = new MySqlCommand("spFront_actDeactUsuario")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_TIPOUSUARIOIN", MySqlDbType.Int64).Value = Reglas.TIPOBUSQUEDA;
				dbCommand.Parameters.Add("p_ACTDEACTIVATE", MySqlDbType.Int64).Value = Reglas.ACTIVO;
				dbCommand.Parameters.Add("p_USUARIOIN", MySqlDbType.Int64).Value = Reglas.USUARIO;
				dbCommand.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = Reglas.IDAPP;
				dbCommand.Parameters.Add("p_IDUSERMODIFICA", MySqlDbType.Int64).Value = Reglas.IDUSRMODIF;
				dbCommand.Parameters.Add("p_IDAPPMODIFICA", MySqlDbType.Int64).Value = App;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool updateUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, long App)
		{
			new UsuariosBE();
			bool bFlag = true;
			try
			{
				MySqlCommand dbCommand = new MySqlCommand("spFront_updUsuario")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = Usuario.IDUSUARIO;
				dbCommand.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = App;
				dbCommand.Parameters.Add("p_IDSEXO", MySqlDbType.Int32).Value = ((Usuario.IDSEXO > 0) ? new Int32?(Usuario.IDSEXO) : null);
				dbCommand.Parameters.Add("p_IDTIPOPERSONA", MySqlDbType.Int32).Value = ((Usuario.IDTIPOPERSONA > 0) ? new Int32?(Usuario.IDTIPOPERSONA) : null);
				dbCommand.Parameters.Add("p_IDESTADOCIVIL", MySqlDbType.Int32).Value = ((Usuario.IDESTADOCIVIL > 0) ? new Int32?(Usuario.IDESTADOCIVIL) : null);
				dbCommand.Parameters.Add("p_IDAREA", MySqlDbType.Int32).Value = ((Usuario.IDAREA > 0) ? new Int32?(Usuario.IDAREA) : null);
				dbCommand.Parameters.Add("p_IDTIPOUSUARIO", MySqlDbType.Int32).Value = ((Usuario.IDTIPOUSUARIO > 0) ? new Int32?(Usuario.IDTIPOUSUARIO) : null);
				dbCommand.Parameters.Add("p_IDUSUARIOAPP", MySqlDbType.VarChar).Value = Usuario.IDUSUARIOAPP;
				dbCommand.Parameters.Add("p_APATERNO", MySqlDbType.VarChar).Value = Usuario.APATERNO;
				dbCommand.Parameters.Add("p_AMATERNO", MySqlDbType.VarChar).Value = Usuario.AMATERNO;
				dbCommand.Parameters.Add("p_NOMBRE", MySqlDbType.VarChar).Value = Usuario.NOMBRE;
				dbCommand.Parameters.Add("p_FECHANACCONST", MySqlDbType.DateTime).Value = Usuario.FECHANACCONST;
				dbCommand.Parameters.Add("p_USUARIO", MySqlDbType.VarChar).Value = Usuario.USUARIO;
				dbCommand.Parameters.Add("p_PASSWORD", MySqlDbType.VarChar).Value = Usuario.PASSWORD;
				dbCommand.Parameters.Add("p_RUTAFOTOPERFIL", MySqlDbType.VarChar).Value = Usuario.RUTAFOTOPERFIL;
				dbCommand.Parameters.Add("p_ACTIVO", MySqlDbType.Bit).Value = Usuario.ACTIVO;
				dbCommand.Parameters.Add("p_IDUSERMODIFICA", MySqlDbType.Int64).Value = ((Reglas.IDUSRMODIF > 0) ? new long?(Reglas.IDUSRMODIF) : null);
				dbCommand.Parameters.Add("p_IDAPPMODIFICA", MySqlDbType.Int64).Value = App;
				if (!ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					throw new DbDataContextException(dbError);
				}
				bFlag = ((rowsAffected > 0) ? true : false);
				if (Domicilios != null)
				{
					foreach (DomicilioBE Dom in Domicilios)
					{
						if (Dom.IDDOMICILIO > 0)
						{
							MySqlCommand dbCommandUD = new MySqlCommand("spFront_updDomicilio")
							{
								CommandType = CommandType.StoredProcedure
							};
							dbCommandUD.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = Usuario.IDUSUARIO;
							dbCommandUD.Parameters.Add("p_IDDOMICILIO", MySqlDbType.Int64).Value = Dom.IDDOMICILIO;
							dbCommandUD.Parameters.Add("p_CALLE", MySqlDbType.VarChar).Value = Dom.CALLE;
							dbCommandUD.Parameters.Add("p_NUMEXT", MySqlDbType.VarChar).Value = Dom.NUMEXT;
							dbCommandUD.Parameters.Add("p_NUMINT", MySqlDbType.VarChar).Value = Dom.NUMINT;
							dbCommandUD.Parameters.Add("p_IDESTADO", MySqlDbType.Int32).Value = ((Int32.Parse(Dom.IDESTADO) > 0) ? new Int32?(Int32.Parse(Dom.IDESTADO)) : null);
							dbCommandUD.Parameters.Add("p_ESTADO", MySqlDbType.VarChar).Value = Dom.ESTADO;
							dbCommandUD.Parameters.Add("p_IDMUN", MySqlDbType.Int32).Value = ((Int32.Parse(Dom.IDMUNICIPIO) > 0) ? new Int32?(Int32.Parse(Dom.IDMUNICIPIO)) : null);
							dbCommandUD.Parameters.Add("p_MUNICIPIO", MySqlDbType.VarChar).Value = Dom.MUNICIPIO;
							dbCommandUD.Parameters.Add("p_IDCOLONIA", MySqlDbType.Int32).Value = ((Int32.Parse(Dom.IDCOLONIA) > 0) ? new Int32?(Int32.Parse(Dom.IDCOLONIA)) : null);
							dbCommandUD.Parameters.Add("p_COLONIA", MySqlDbType.VarChar).Value = Dom.COLONIA;
							dbCommandUD.Parameters.Add("p_CP", MySqlDbType.VarChar).Value = Dom.CP;
							dbCommandUD.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = App;
							dbCommandUD.Parameters.Add("p_IDUSERMODIFICA", MySqlDbType.Int64).Value = ((Reglas.IDUSRMODIF > 0) ? new long?(Reglas.IDUSRMODIF) : null);
							dbCommandUD.Parameters.Add("p_IDAPPMODIFICA", MySqlDbType.Int64).Value = App;
							if (!ExecuteNonQuery(ref dbCommandUD, out var _, out var dbErrorUD))
							{
								throw new DbDataContextException(dbErrorUD);
							}
							continue;
						}
						MySqlCommand dbCommandID = new MySqlCommand("spFront_insDomicilio")
						{
							CommandType = CommandType.StoredProcedure
						};
						dbCommandID.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = Usuario.IDUSUARIO;
						dbCommandID.Parameters.Add("p_CALLE", MySqlDbType.VarChar).Value = Dom.CALLE;
						dbCommandID.Parameters.Add("p_NUMEXT", MySqlDbType.VarChar).Value = Dom.NUMEXT;
						dbCommandID.Parameters.Add("p_NUMINT", MySqlDbType.VarChar).Value = Dom.NUMINT;
						dbCommandID.Parameters.Add("p_IDESTADO", MySqlDbType.Int32).Value = ((Int32.Parse(Dom.IDESTADO) > 0) ? new Int32?(Int32.Parse(Dom.IDESTADO)) : null);
						dbCommandID.Parameters.Add("p_ESTADO", MySqlDbType.VarChar).Value = Dom.ESTADO;
						dbCommandID.Parameters.Add("p_IDMUN", MySqlDbType.Int32).Value = ((Int32.Parse(Dom.IDMUNICIPIO) > 0) ? new Int32?(Int32.Parse(Dom.IDMUNICIPIO)) : null);
						dbCommandID.Parameters.Add("p_MUNICIPIO", MySqlDbType.VarChar).Value = Dom.MUNICIPIO;
						dbCommandID.Parameters.Add("p_IDCOLONIA", MySqlDbType.Int32).Value = ((Int32.Parse(Dom.IDCOLONIA) > 0) ? new Int32?(Int32.Parse(Dom.IDCOLONIA)) : null);
						dbCommandID.Parameters.Add("p_COLONIA", MySqlDbType.VarChar).Value = Dom.COLONIA;
						dbCommandID.Parameters.Add("p_CP", MySqlDbType.VarChar).Value = Dom.CP;
						dbCommandID.Parameters.Add("p_FECHAALTA", MySqlDbType.DateTime).Value = DateTime.Now;
						dbCommandID.Parameters.Add("p_ACTIVO", MySqlDbType.Bit).Value = true;
						dbCommandID.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = App;
						dbCommandID.Parameters.Add("p_IDUSERMODIFICA", MySqlDbType.Int64).Value = ((Reglas.IDUSRMODIF > 0) ? new long?(Reglas.IDUSRMODIF) : null);
						dbCommandID.Parameters.Add("p_IDAPPMODIFICA", MySqlDbType.Int64).Value = App;
						if (!ExecuteNonQuery(ref dbCommandID, out var _, out var dbErrorID))
						{
							throw new DbDataContextException(dbErrorID);
						}
					}
				}
				if (Contactos != null)
				{
					foreach (ContactoBE Contacto in Contactos)
					{
						if (Contacto.IDCONTACTO > 0)
						{
							MySqlCommand dbCommandUC = new MySqlCommand("spFront_updContacto")
							{
								CommandType = CommandType.StoredProcedure
							};
							dbCommandUC.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = Usuario.IDUSUARIO;
							dbCommandUC.Parameters.Add("p_IDCONTACTO", MySqlDbType.Int64).Value = Contacto.IDCONTACTO;
							dbCommandUC.Parameters.Add("p_IDTIPOCONTACTO", MySqlDbType.Int32).Value = Contacto.IDTIPOCONTACTO;
							dbCommandUC.Parameters.Add("p_VALOR", MySqlDbType.VarChar).Value = Contacto.VALOR;
							dbCommandUC.Parameters.Add("p_ACTIVO", MySqlDbType.Bit).Value = Contacto.ACTIVO;
							dbCommandUC.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = App;
							dbCommandUC.Parameters.Add("p_IDUSERMODIFICA", MySqlDbType.Int64).Value = ((Reglas.IDUSRMODIF > 0) ? new long?(Reglas.IDUSRMODIF) : null);
							dbCommandUC.Parameters.Add("p_IDAPPMODIFICA", MySqlDbType.Int64).Value = App;
							if (!ExecuteNonQuery(ref dbCommandUC, out var _, out var dbErrorUC))
							{
								throw new DbDataContextException(dbErrorUC);
							}
						}
						else
						{
							MySqlCommand dbCommandIC = new MySqlCommand("spFront_insContacto")
							{
								CommandType = CommandType.StoredProcedure
							};
							dbCommandIC.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = Usuario.IDUSUARIO;
							dbCommandIC.Parameters.Add("p_IDTIPOCONTACTO", MySqlDbType.Int32).Value = Contacto.IDTIPOCONTACTO;
							dbCommandIC.Parameters.Add("p_VALOR", MySqlDbType.VarChar).Value = Contacto.VALOR;
							dbCommandIC.Parameters.Add("p_FECHAALTA", MySqlDbType.DateTime).Value = DateTime.Now;
							dbCommandIC.Parameters.Add("p_ACTIVO", MySqlDbType.Bit).Value = true;
							dbCommandIC.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = App;
							dbCommandIC.Parameters.Add("p_IDUSERMODIFICA", MySqlDbType.Int64).Value = ((Reglas.IDUSRMODIF > 0) ? new long?(Reglas.IDUSRMODIF) : null);
							dbCommandIC.Parameters.Add("p_IDAPPMODIFICA", MySqlDbType.Int64).Value = App;
							if (!ExecuteNonQuery(ref dbCommandIC, out var _, out var dbErrorIC))
							{
								throw new DbDataContextException(dbErrorIC);
							}
						}
					}
				}
				if (Usuario.IDAPLICACION == 0L)
				{
					foreach (RolesXUsuarioBE Rol2 in RolesXUsuario)
					{
						MySqlCommand dbCommandUXAP = new MySqlCommand("spFrontAddUsuarioXAplicacion")
						{
							CommandType = CommandType.StoredProcedure
						};
						dbCommandUXAP.Parameters.Add("p_IDUSRSXAPP", MySqlDbType.VarChar).Value = long.Parse(Rol2.IDAPLICACION);
						dbCommandUXAP.Parameters.Add("p_IDAPLICACION", MySqlDbType.VarChar).Value = Usuario.IDUSUARIO;
						dbCommandUXAP.Parameters.Add("p_IDUSUARIO", MySqlDbType.VarChar).Value = true;
						if (!ExecuteNonQuery(ref dbCommandUXAP, out var _, out var dbErrorUXAP))
						{
							throw new DbDataContextException(dbErrorUXAP);
						}
					}
				}
				if (RolesXUsuario != null)
				{
					foreach (RolesXUsuarioBE Rol in RolesXUsuario)
					{
						MySqlCommand dbCommandRXU = new MySqlCommand("spFront_insRolXUserApp")
						{
							CommandType = CommandType.StoredProcedure
						};
						dbCommandRXU.Parameters.Add("p_IDROL", MySqlDbType.Int64).Value = Rol.IDROL;
						dbCommandRXU.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = Usuario.IDUSUARIO;
						dbCommandRXU.Parameters.Add("p_IDESTACIONXAPP", MySqlDbType.Int64).Value = ((Rol.IDESTACIONXAPP > 0) ? new long?(Rol.IDESTACIONXAPP) : null);
						dbCommandRXU.Parameters.Add("p_IDROLXUSUARIO", MySqlDbType.Int64).Value = ((Rol.IDROLXUSUARIO > 0) ? new long?(Rol.IDROLXUSUARIO) : null);
						dbCommandRXU.Parameters.Add("p_ACTIVO", MySqlDbType.Bit).Value = Rol.ACTIVO;
						if (!ExecuteNonQuery(ref dbCommandRXU, out var _, out var dbErrorRXU))
						{
							throw new DbDataContextException(dbErrorRXU);
						}
					}
				}
				return bFlag;
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool checkUsrXApp(ReglasBE Reglas, long App)
		{
			try
			{
				new DatosUsuarioBE();
				bool bFlag = false;
				MySqlCommand dbCommand = new MySqlCommand("spFront_checkUsrXApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_TIPOBUSQUEDA", MySqlDbType.Int32).Value = Reglas.TIPOBUSQUEDA;
				dbCommand.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = Reglas.IDAPP;
				dbCommand.Parameters.Add("p_USUARIO", MySqlDbType.VarChar).Value = Reglas.USUARIO;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					{
						IEnumerator enumerator = DataTable.Rows.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								_ = (DataRow)enumerator.Current;
								bFlag = true;
							}
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
					return bFlag;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool checkUsr(ReglasBE Reglas)
		{
			try
			{
				new DatosUsuarioBE();
				bool bFlag = false;
				MySqlCommand dbCommand = new MySqlCommand("sp_checkUsr")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_TIPOBUSQUEDA", MySqlDbType.Int32).Value = Reglas.TIPOBUSQUEDA;
				dbCommand.Parameters.Add("p_USUARIO", MySqlDbType.VarChar).Value = Reglas.USUARIO;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					{
						IEnumerator enumerator = DataTable.Rows.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								_ = (DataRow)enumerator.Current;
								bFlag = true;
							}
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
					return bFlag;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", Reglas.IDAPP.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<UsuarioXAppBE> getAppXUsuario(ReglasBE Reglas, long App)
		{
			try
			{
				List<UsuarioXAppBE> ListaApps = new List<UsuarioXAppBE>();
				MySqlCommand dbCommand = new MySqlCommand("spFront_getAppsXUsuario")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_TIPOBUSQUEDA", MySqlDbType.Int64).Value = Reglas.TIPOBUSQUEDA;
				dbCommand.Parameters.Add("p_USUARIO", MySqlDbType.Int64).Value = Reglas.USUARIO;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						UsuarioXAppBE AppItem = new UsuarioXAppBE();
						AppItem.IDAPLICACION = row["IDAPLICACION"].ToString();
						AppItem.DESCRIPCION = row["DESCRIPCION"].ToString();
						AppItem.URLINICIO = row["URLINICIO"].ToString();
						AppItem.ACTIVO = row["ACTIVO"].ToString();
						AppItem.IDUSRSXAPP = row["IDUSRSXAPP"].ToString();
						ListaApps.Add(AppItem);
					}
					return ListaApps;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<EstacionesXAppBE> getEstacionesXApp(ReglasBE Reglas, long App)
		{
			try
			{
				List<EstacionesXAppBE> ListaEstaciones = new List<EstacionesXAppBE>();
				MySqlCommand dbCommand = new MySqlCommand("spFront_getEstacionesXApps")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = Reglas.IDAPP;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						EstacionesXAppBE EstacionesItem = new EstacionesXAppBE();
						EstacionesItem.IDESTACIONXAPP = Convert.ToInt64(row["IDESTACIONXAPP"]);
						EstacionesItem.IDAPLICACION = Convert.ToInt64(row["IDAPLICACION"]);
						EstacionesItem.IDESTACION = Convert.ToInt32(row["IDESTACION"]);
						EstacionesItem.ACTIVO = Convert.ToBoolean(row["ACTIVO"]);
						ListaEstaciones.Add(EstacionesItem);
					}
					return ListaEstaciones;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool addRolesXUsuario(ReglasBE Reglas, List<RolesXUsuarioBE> RolesXUsuario, long App)
		{
			try
			{
				bool bFlag = true;
				foreach (RolesXUsuarioBE Rol in RolesXUsuario)
				{
					MySqlCommand dbCommand = new MySqlCommand("spFront_insRolesXUsuario")
					{
						CommandType = CommandType.StoredProcedure
					};
					dbCommand.Parameters.Add("p_IDROL", MySqlDbType.Int64).Value = Rol.IDROL;
					dbCommand.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = Rol.IDUSUARIO;
					dbCommand.Parameters.Add("p_IDESTACIONXAPP", MySqlDbType.Int64).Value = ((Rol.IDESTACIONXAPP > 0) ? new long?(Rol.IDESTACIONXAPP) : null);
					if (!ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
					{
						throw new DbDataContextException(dbError);
					}
					bFlag = ((rowsAffected > 0) ? true : false);
				}
				return bFlag;
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<RolesXUsuarioBE> GetRolesVsUser(ReglasBE Reglas, long App)
		{
			try
			{
				List<RolesXUsuarioBE> RolesVSUsuarios = new List<RolesXUsuarioBE>();
				MySqlCommand dbCommand = new MySqlCommand("spFrontGetRolesVSUsuario")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IDUSUARIO", MySqlDbType.VarChar).Value = Reglas.USUARIO;
				dbCommand.Parameters.Add("p_IDAPLICAION", MySqlDbType.VarChar).Value = Reglas.IDAPP.ToString();
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						RolesXUsuarioBE RolesXUsuario = new RolesXUsuarioBE();
						RolesXUsuario.IDROL = Convert.ToInt64(row["IDROL"]);
						RolesXUsuario.DESCROL = row["DESCRIPCION"].ToString();
						RolesXUsuario.IDAPLICACION = row["IDAPLICACION"].ToString();
						RolesXUsuario.APLICACION = row["APLICACION"].ToString();
						RolesXUsuario.IDROLXUSUARIO = Convert.ToInt64(row["IDROLXUSUARIO"]);
						RolesXUsuario.ACTIVO = ((Convert.ToInt32(row["ROLASIGNADO"]) != 0) ? true : false);
						RolesVSUsuarios.Add(RolesXUsuario);
					}
					return RolesVSUsuarios;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool addUsuarioXAplicacion(ReglasBE Reglas, List<UsuarioXAppBE> lstUSuarioXApp, long App)
		{
			try
			{
				bool bFlag = true;
				foreach (UsuarioXAppBE item in lstUSuarioXApp)
				{
					MySqlCommand dbCommand = new MySqlCommand("spFront_addUsuarioXAplicacion")
					{
						CommandType = CommandType.StoredProcedure
					};
					dbCommand.Parameters.Add("p_IDUSRSXAPP", MySqlDbType.Int64).Value = item.IDUSRSXAPP;
					dbCommand.Parameters.Add("p_IDAPLICACION", MySqlDbType.Int64).Value = item.IDAPLICACION;
					dbCommand.Parameters.Add("p_IDUSUARIO", MySqlDbType.Int64).Value = item.IDUSUARIO;
					dbCommand.Parameters.Add("p_ACTIVO", MySqlDbType.Int64).Value = item.ACTIVO;
					if (!ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
					{
						throw new DbDataContextException(dbError);
					}
					bFlag = ((rowsAffected > 0) ? true : false);
				}
				return bFlag;
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<RolesBE> getRolesXApp(ReglasBE Reglas, long App)
		{
			try
			{
				List<RolesBE> RolesXApp = new List<RolesBE>();
				MySqlCommand dbCommand = new MySqlCommand("spFront_getRolesXApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IDAPLICAION", MySqlDbType.Int64).Value = Reglas.IDAPP;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						RolesBE RolXApp = new RolesBE();
						RolXApp.IDROL = Convert.ToInt64(row["IDROL"].ToString());
						RolXApp.IDAPLICACION = Convert.ToInt64(row["IDAPLICACION"].ToString());
						RolXApp.DESCRIPCION = row["DESCRIPCION"].ToString();
						RolXApp.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
						RolesXApp.Add(RolXApp);
					}
					return RolesXApp;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<CatalogosBE> getCatSelection(Int32 IdCatGeneral, Int32 IdSubCatalogo, long App)
		{
			try
			{
				List<CatalogosBE> ListaCatalogo = new List<CatalogosBE>();
				new CatalogosBE();
				MySqlCommand dbCommand = new MySqlCommand("spFrontgetCatGenerales")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IDAPLICAION", MySqlDbType.Int32).Value = IdCatGeneral;
				Cat_GralsBE CatGrasl = new Cat_GralsBE();
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						CatGrasl.IDCATGRAL = Convert.ToInt64(row["IDCATGRAL"]);
						CatGrasl.NOMBRETABLA = row["NOMBRETABLA"].ToString();
						CatGrasl.IDTABLA = row["IDTABLA"].ToString();
						CatGrasl.DESCRIPCIONTABLA = row["DESCRIPCIONTABLA"].ToString();
						CatGrasl.IDFILTRO = row["IDFILTRO"].ToString();
					}
					StringBuilder sComando = new StringBuilder(string.Empty);
					sComando.Append("SELECT CONVERT(VARCHAR(250),");
					sComando.Append(CatGrasl.IDTABLA);
					sComando.Append(") AS ID,");
					sComando.Append("CONVERT(VARCHAR(250),");
					sComando.Append(CatGrasl.DESCRIPCIONTABLA);
					sComando.Append(")");
					sComando.Append(" AS DESCRIPCION");
					sComando.Append(" FROM ");
					sComando.Append(CatGrasl.NOMBRETABLA);
					if (!string.IsNullOrEmpty(CatGrasl.IDFILTRO) && IdSubCatalogo != 0)
					{
						sComando.Append(" WHERE ");
						sComando.Append(CatGrasl.IDFILTRO);
						sComando.Append("='");
						sComando.Append(IdSubCatalogo);
						sComando.Append("' AND ACTIVO = 1 ");
					}
					else
					{
						sComando.Append(" WHERE ACTIVO = 1 ");
					}
					new List<CatalogosBE>();
					MySqlCommand dbCommandText = new MySqlCommand(sComando.ToString())
					{
						CommandType = CommandType.Text
					};
					if (ExecuteReader(ref dbCommandText, out var DataTableText, out var dbErrorText))
					{
						foreach (DataRow rowT in DataTableText.Rows)
						{
							CatalogosBE item = new CatalogosBE();
							item.ID = rowT["ID"].ToString();
							item.DESCRIPCION = rowT["DESCRIPCION"].ToString().ToUpper();
							ListaCatalogo.Add(item);
						}
						List<CatalogosBE> list = (from x in ListaCatalogo
												  orderby x.DESCRIPCION, x.DESCRIPCION
												  select x).ToList();
						list.Insert(0, new CatalogosBE
						{
							ID = "0",
							DESCRIPCION = "[SELECCIONE UNA OPCIÓN]"
						});
						return list;
					}
					throw new DbDataContextException(dbErrorText);
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public bool updateRol(ReglasBE Reglas, RolesXUsuarioBE RolXUsuario, long App)
		{
			try
			{
				bool Respuesta = true;
				MySqlCommand dbCommand = new MySqlCommand("spFront_updRol")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IDROLXUSUARIO", MySqlDbType.Int64).Value = RolXUsuario.IDROLXUSUARIO;
				dbCommand.Parameters.Add("p_IDROL", MySqlDbType.Int64).Value = RolXUsuario.IDROL;
				dbCommand.Parameters.Add("p_IDESTACIONXAPP", MySqlDbType.Int64).Value = RolXUsuario.IDESTACIONXAPP;
				if (ExecuteNonQuery(ref dbCommand, out var rowsAffected, out var dbError))
				{
					if (rowsAffected > 0)
					{
						return true;
					}
					return false;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public List<DatosUsuarioBE> getUsuariosXRol(long IdRol, long App)
		{
			try
			{
				List<DatosUsuarioBE> DatosUsuarioRES = new List<DatosUsuarioBE>();
				MySqlCommand dbCommand = new MySqlCommand("sp_getUsuariosXIdRol")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_IdRol", MySqlDbType.Int64).Value = IdRol;
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					foreach (DataRow row in DataTable.Rows)
					{
						DatosUsuarioBE UsuarioRES = new DatosUsuarioBE();
						UsuarioRES.Usuario.IDUSUARIO = Convert.ToInt64(row["IDUSUARIO"].ToString());
						UsuarioRES.Usuario.IDSEXO = Convert.ToInt32(row["IDSEXO"].ToString());
						UsuarioRES.Usuario.IDTIPOPERSONA = Convert.ToInt32(row["IDTIPOPERSONA"].ToString());
						UsuarioRES.Usuario.IDESTADOCIVIL = Convert.ToInt32(row["IDESTADOCIVIL"].ToString());
						UsuarioRES.Usuario.IDAREA = Convert.ToInt32(row["IDAREA"].ToString());
						UsuarioRES.Usuario.IDTIPOUSUARIO = Convert.ToInt32(row["IDTIPOUSUARIO"].ToString());
						UsuarioRES.Usuario.IDUSUARIOAPP = row["IDUSUARIOAPP"].ToString();
						UsuarioRES.Usuario.APATERNO = row["APATERNO"].ToString();
						UsuarioRES.Usuario.AMATERNO = row["AMATERNO"].ToString();
						UsuarioRES.Usuario.NOMBRE = row["NOMBRE"].ToString();
						UsuarioRES.Usuario.FECHANACCONST = Convert.ToDateTime(row["FECHANACCONST"].ToString());
						UsuarioRES.Usuario.USUARIO = row["USUARIO"].ToString();
						UsuarioRES.Usuario.PASSWORD = row["PASSWORD"].ToString();
						UsuarioRES.Usuario.RUTAFOTOPERFIL = row["RUTAFOTOPERFIL"].ToString();
						UsuarioRES.Usuario.FECHAALTA = Convert.ToDateTime(row["FECHAALTA"].ToString());
						UsuarioRES.Usuario.ACTIVO = Convert.ToBoolean(row["ACTIVO"].ToString());
						if (!string.IsNullOrEmpty(row["EMAIL"].ToString()))
						{
							ContactoBE ContactoRes = new ContactoBE();
							ContactoRes.IDTIPOCONTACTO = 3;
							ContactoRes.VALOR = row["EMAIL"].ToString();
							UsuarioRES.Contactos.Add(ContactoRes);
						}
						DatosUsuarioRES.Add(UsuarioRES);
					}
					return DatosUsuarioRES;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public string getUsrIdApp(long App)
		{
			try
			{
				new DatosUsuarioBE();
				string IdUsrApp = string.Empty;
				MySqlCommand dbCommand = new MySqlCommand("sp_setIdUsrApp")
				{
					CommandType = CommandType.StoredProcedure
				};
				if (ExecuteReader(ref dbCommand, out var DataTable, out var dbError))
				{
					{
						IEnumerator enumerator = DataTable.Rows.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								IdUsrApp = ((DataRow)enumerator.Current)["USUARIO"].ToString();
							}
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
					return IdUsrApp;
				}
				throw new DbDataContextException(dbError);
			}
			catch (Exception ex)
			{
				StackTrace st = new StackTrace(true);
				insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
				throw new Exception(ex.Message);
			}
		}

		public void insErrorDB(string MessageErr, StackTrace st, string user, string sApp)
		{
			try
			{
				if (MessageErr.Length > 445)
				{
					MessageErr = MessageErr.Substring(0, 445);
				}
				string strHostname = Dns.GetHostName();
				string sIp = Dns.GetHostEntry(strHostname).AddressList.Where((IPAddress n) => n.AddressFamily == AddressFamily.InterNetwork).First().ToString();
				StringBuilder strStackTrace = new StringBuilder();
				StackFrame[] frames = st.GetFrames();
				Int32 num = 0;
				if (num < frames.Length)
				{
					StackFrame f = frames[num];
					strStackTrace.Append(f.ToString());
				}
				if (strStackTrace.Length > 490)
				{
					string sStackTrace = strStackTrace.ToString();
					strStackTrace.Clear();
					strStackTrace.Append(sStackTrace.Substring(0, 490));
				}
				if (sIp.Length > 39)
				{
					sIp = sIp.Substring(0, 39);
				}
				if (strHostname.Length > 148)
				{
					strHostname = strHostname.Substring(0, 148);
				}
				MySqlCommand dbCommand = new MySqlCommand("sp_insLogError")
				{
					CommandType = CommandType.StoredProcedure
				};
				dbCommand.Parameters.Add("p_idApp", MySqlDbType.Int64).Value = long.Parse(sApp);
				dbCommand.Parameters.Add("p_MENSAJE", MySqlDbType.VarChar).Value = MessageErr;
				dbCommand.Parameters.Add("p_HOSTNAME", MySqlDbType.VarChar).Value = strHostname;
				dbCommand.Parameters.Add("p_IP", MySqlDbType.VarChar).Value = sIp;
				dbCommand.Parameters.Add("p_STACKTRACE", MySqlDbType.VarChar).Value = strStackTrace.ToString();
				dbCommand.Parameters.Add("p_DTFECHAERROR", MySqlDbType.DateTime).Value = DateTime.Now;
				dbCommand.Parameters.Add("p_VCHUSUARIO", MySqlDbType.VarChar).Value = user;
				if (!ExecuteNonQuery(ref dbCommand, out var _, out var dbError))
				{
					throw new DbDataContextException(dbError);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}

}

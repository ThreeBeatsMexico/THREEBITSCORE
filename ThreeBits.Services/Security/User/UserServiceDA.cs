using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.Common;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Security.Users;
using static ThreeBits.Data.Common.SqlDataContext;

namespace ThreeBits.Services.Security.User
{
    public class UserServiceDA : SqlDataContext, IUserServiceDA
    {

        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        //  private readonly ISecurityCommonDA _securityCommon;

        public UserServiceDA(ILogger<SecurityServiceDA> logger,

            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            // _securityCommon = securityCommonDA;
        }




        public UsuariosBE addUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, Int64 App)
        {
            UsuariosBE UsuarioRes = new UsuariosBE();
            Int64 IdUsuario = 0;
            try
            {

                ////Insertamos al usuario
                var dbCommand = new SqlCommand("spFront_insUser")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = Usuario.IDAPLICACION;
                dbCommand.Parameters.Add("@IDSEXO", SqlDbType.Int).Value = (Usuario.IDSEXO > 0 ? (Int32?)Usuario.IDSEXO : null);
                dbCommand.Parameters.Add("@IDTIPOPERSONA", SqlDbType.Int).Value = (Usuario.IDTIPOPERSONA > 0 ? (Int32?)Usuario.IDTIPOPERSONA : null);
                dbCommand.Parameters.Add("@IDESTADOCIVIL", SqlDbType.Int).Value = (Usuario.IDESTADOCIVIL > 0 ? (Int32?)Usuario.IDESTADOCIVIL : null);
                dbCommand.Parameters.Add("@IDAREA", SqlDbType.Int).Value = (Usuario.IDAREA > 0 ? (Int32?)Usuario.IDAREA : null);
                dbCommand.Parameters.Add("@IDTIPOUSUARIO", SqlDbType.Int).Value = (Usuario.IDTIPOUSUARIO > 0 ? (Int32?)Usuario.IDTIPOUSUARIO : null);
                dbCommand.Parameters.Add("@IDUSUARIOAPP", SqlDbType.VarChar).Value = Usuario.IDUSUARIOAPP;
                dbCommand.Parameters.Add("@APATERNO", SqlDbType.VarChar).Value = Usuario.APATERNO;
                dbCommand.Parameters.Add("@AMATERNO", SqlDbType.VarChar).Value = Usuario.AMATERNO;
                dbCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = Usuario.NOMBRE;
                dbCommand.Parameters.Add("@FECHANACCONST", SqlDbType.DateTime).Value = Usuario.FECHANACCONST;
                dbCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = Usuario.USUARIO;
                dbCommand.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Usuario.PASSWORD;
                dbCommand.Parameters.Add("@RUTAFOTOPERFIL", SqlDbType.VarChar).Value = Usuario.RUTAFOTOPERFIL;
                dbCommand.Parameters.Add("@FECHAALTA", SqlDbType.DateTime).Value = DateTime.Now;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Usuario.ACTIVO;
                dbCommand.Parameters.Add("@IDUSERMODIFICA", SqlDbType.BigInt).Value = (Reglas.IDUSRMODIF > 0 ? (Int64?)Reglas.IDUSRMODIF : null);
                dbCommand.Parameters.Add("@IDAPPMODIFICA", SqlDbType.BigInt).Value = App;
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        IdUsuario = Int64.Parse(row["SCOPE_IDENTITY"].ToString());
                        UsuarioRes.IDUSUARIO = IdUsuario;
                        UsuarioRes.IDUSUARIOAPP = Usuario.IDUSUARIOAPP.ToString();
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);
                    ////Insertamos sus Domicilios
                    foreach (DomicilioBE Dom in Domicilios)
                    {

                    var dbCommandUD = new SqlCommand("spFront_insDomicilio")
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    dbCommandUD.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = IdUsuario;
                    dbCommandUD.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = Dom.CALLE;
                    dbCommandUD.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = Dom.NUMEXT;
                    dbCommandUD.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = Dom.NUMINT;
                    dbCommandUD.Parameters.Add("@IDESTADO", SqlDbType.Int).Value = (!string.IsNullOrEmpty(Dom.IDESTADO) ? (Int32?)Int32.Parse(Dom.IDESTADO) : null);
                    dbCommandUD.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = Dom.ESTADO;
                    dbCommandUD.Parameters.Add("@IDMUN", SqlDbType.Int).Value = (!string.IsNullOrEmpty(Dom.IDMUNICIPIO) ? (Int32?)Int32.Parse(Dom.IDMUNICIPIO) : null);
                    dbCommandUD.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = Dom.MUNICIPIO;
                    dbCommandUD.Parameters.Add("@IDCOLONIA", SqlDbType.Int).Value = (!string.IsNullOrEmpty(Dom.IDCOLONIA) ? (Int32?)Int32.Parse(Dom.IDCOLONIA) : null);
                    dbCommandUD.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = Dom.COLONIA;
                    dbCommandUD.Parameters.Add("@CP", SqlDbType.VarChar).Value = Dom.CP;
                    dbCommandUD.Parameters.Add("@FECHAALTA", SqlDbType.DateTime).Value = DateTime.Now;
                    dbCommandUD.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = true;
                    dbCommandUD.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
                    dbCommandUD.Parameters.Add("@IDUSERMODIFICA", SqlDbType.BigInt).Value = (Reglas.IDUSRMODIF > 0 ? (Int64?)Reglas.IDUSRMODIF : null);
                    dbCommandUD.Parameters.Add("@IDAPPMODIFICA", SqlDbType.BigInt).Value = App;

                    if (ExecuteNonQuery(ref dbCommandUD, out int rowsAffectedUD, out string dbErrorUD))
                    {
                    }
                    else throw new DbDataContextException(dbErrorUD);
                    }

                    ////Insertamos sus Contactos
                    foreach (ContactoBE Contacto in Contactos)
                    {
                    var dbCommandIC = new SqlCommand("spFront_insContacto")
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    dbCommandIC.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = IdUsuario;
                    dbCommandIC.Parameters.Add("@IDTIPOCONTACTO", SqlDbType.Int).Value = Contacto.IDTIPOCONTACTO;
                    dbCommandIC.Parameters.Add("@VALOR", SqlDbType.VarChar).Value = Contacto.VALOR;
                    dbCommandIC.Parameters.Add("@FECHAALTA", SqlDbType.DateTime).Value = DateTime.Now;
                    dbCommandIC.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = true;
                    dbCommandIC.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
                    dbCommandIC.Parameters.Add("@IDUSERMODIFICA", SqlDbType.BigInt).Value = (Reglas.IDUSRMODIF > 0 ? (Int64?)Reglas.IDUSRMODIF : null);
                    dbCommandIC.Parameters.Add("@IDAPPMODIFICA", SqlDbType.BigInt).Value = App;

                    if (ExecuteNonQuery(ref dbCommandIC, out int rowsAffectedIC, out string dbErrorIC))
                    {
                    }
                    else throw new DbDataContextException(dbErrorIC);
                  
                    }

                    foreach (var Rol in RolesXUsuario)
                    {
                    var dbCommandUXAP = new SqlCommand("spFrontAddUsuarioXAplicacion")
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    dbCommandUXAP.Parameters.Add("@IDUSRSXAPP", SqlDbType.NVarChar).Value = long.Parse(Rol.IDAPLICACION);
                    dbCommandUXAP.Parameters.Add("@IDAPLICACION", SqlDbType.NVarChar).Value = IdUsuario;
                    dbCommandUXAP.Parameters.Add("@IDUSUARIO", SqlDbType.NVarChar).Value = true;

                    if (ExecuteNonQuery(ref dbCommandUXAP, out int rowsAffectedUXAP, out string dbErrorUXAP))
                    {
                    }
                    else throw new DbDataContextException(dbErrorUXAP);
                   
                    }

                    ////Insertamos sus Roles con estaciones en caso de tenerlas
                    foreach (RolesXUsuarioBE Rol in RolesXUsuario)
                    {
                    var dbCommandRXU = new SqlCommand("spFront_insRolXUserApp")
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    dbCommandRXU.Parameters.Add("@IDROL", SqlDbType.BigInt).Value = Rol.IDROL;
                    dbCommandRXU.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = IdUsuario;
                    dbCommandRXU.Parameters.Add("@IDESTACIONXAPP", SqlDbType.BigInt).Value = (Rol.IDESTACIONXAPP > 0 ? (Int64?)Rol.IDESTACIONXAPP : null);
                    dbCommandRXU.Parameters.Add("@IDROLXUSUARIO", SqlDbType.BigInt).Value = (Rol.IDROLXUSUARIO > 0 ? (Int64?)Rol.IDROLXUSUARIO : null);
                    dbCommandRXU.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Rol.ACTIVO;
                    if (ExecuteNonQuery(ref dbCommandRXU, out int rowsAffectedRXU, out string dbErrorRXU))
                    {
                    }
                    else throw new DbDataContextException(dbErrorRXU);
                   
                    }

                   
                
                return UsuarioRes;
            }
            catch (Exception ex)
            {
               
                StackTrace st = new StackTrace(true);
                
                insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
           
        }

        public DatosUsuarioBE GetUsuarioFull(ReglasBE Reglas, Int64 App)
        {
            
            try
            {
                DatosUsuarioBE DatosUsuarioRES = new DatosUsuarioBE();
                UsuariosBE UsuarioRES = new UsuariosBE();
                var dbCommand = new SqlCommand("spFront_getUsuario")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@TIPOBUSQUEDA", SqlDbType.Int).Value = Reglas.TIPOBUSQUEDA;
                dbCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = Reglas.USUARIO;
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = Reglas.IDAPP; 
                //agregar filtro para tipousuario
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    
                    foreach (DataRow row in DataTable.Rows)
                    {
                        // UsuariosBE UsuarioRES = new UsuariosBE();
                        UsuarioRES.IDUSUARIO = Convert.ToInt64(row["IDUSUARIO"]);
                        UsuarioRES.IDAPLICACION = Convert.ToInt64(row["IDAPLICACION"]);
                        UsuarioRES.IDSEXO = Convert.ToInt32(row["IDSEXO"]);
                        UsuarioRES.IDTIPOPERSONA = Convert.ToInt32(row["IDTIPOPERSONA"]);
                        UsuarioRES.IDESTADOCIVIL = Convert.ToInt32(row["IDESTADOCIVIL"]);
                        UsuarioRES.IDAREA = Convert.ToInt32(row["IDAREA"]);
                        UsuarioRES.DESCAREA = row["DESCAREA"].ToString();
                        UsuarioRES.IDTIPOUSUARIO = Convert.ToInt32(row["IDTIPOUSUARIO"]);
                        UsuarioRES.DESCTIPOUSUARIO = row["DESCIDTIPOUSUARIO"].ToString();
                        UsuarioRES.IDUSUARIOAPP = row["IDUSUARIOAPP"].ToString();
                        UsuarioRES.APATERNO = row["APATERNO"].ToString();
                        UsuarioRES.AMATERNO = row["AMATERNO"].ToString();
                        UsuarioRES.NOMBRE = row["NOMBRE"].ToString();
                        UsuarioRES.FECHANACCONST = Convert.ToDateTime(row["FECHANACCONST"]);
                        UsuarioRES.USUARIO = row["USUARIO"].ToString();
                        UsuarioRES.PASSWORD = row["PASSWORD"].ToString();
                        UsuarioRES.RUTAFOTOPERFIL = row["RUTAFOTOPERFIL"].ToString();
                        UsuarioRES.FECHAALTA = Convert.ToDateTime(row["FECHAALTA"]);
                        UsuarioRES.ACTIVO = Convert.ToBoolean(row["ACTIVO"]);
                       //  DatosUsuarioRES.Usuario = UsuarioRES;
                    }
                    DatosUsuarioRES.Usuario = UsuarioRES;
                }
                else throw new DbDataContextException(dbError);
                if (DatosUsuarioRES.Usuario.IDUSUARIO == null || DatosUsuarioRES.Usuario.IDUSUARIO == 0)
                    return DatosUsuarioRES;



                var dbCommandUD = new SqlCommand("spFront_getDomicilios")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommandUD.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = DatosUsuarioRES.Usuario.IDUSUARIO;
                if (ExecuteReader(ref dbCommandUD, out DataTable DataTableUD, out string dbErrorUD))
                {

                    List<DomicilioBE> lstDomicilios = new List<DomicilioBE>();
                    foreach (DataRow row in DataTableUD.Rows)
                    {
                        DomicilioBE DomicilioRES = new DomicilioBE();
                        DomicilioRES.IDDOMICILIO = Convert.ToInt64(row["IDDOMICILIO"]);
                        DomicilioRES.IDUSUARIO = Convert.ToInt32(row["IDUSUARIO"]);
                        DomicilioRES.CALLE = row["CALLE"].ToString();
                        DomicilioRES.NUMEXT = row["NUMEXT"].ToString();
                        DomicilioRES.NUMINT = row["NUMINT"].ToString();
                        DomicilioRES.IDESTADO = string.IsNullOrEmpty(row["IDESTADO"].ToString()) ? "0" : row["IDESTADO"].ToString();
                        DomicilioRES.ESTADO = row["ESTADO"].ToString();
                        DomicilioRES.IDMUNICIPIO = string.IsNullOrEmpty(row["IDMUN"].ToString()) ? "0" : row["IDMUN"].ToString();
                        DomicilioRES.MUNICIPIO = row["MUNICIPIO"].ToString();
                        DomicilioRES.IDCOLONIA = string.IsNullOrEmpty(row["IDCOLONIA"].ToString()) ? "0" : row["IDCOLONIA"].ToString();
                        DomicilioRES.COLONIA = row["COLONIA"].ToString();
                        DomicilioRES.CP = row["CP"].ToString();
                        DomicilioRES.FECHAALTA = Convert.ToDateTime(row["FECHAALTA"]);
                        DomicilioRES.ACTIVO = Convert.ToBoolean(row["ACTIVO"]);
                        lstDomicilios.Add(DomicilioRES);
                    }
                    DatosUsuarioRES.Domicilios = lstDomicilios;
                }
                else throw new DbDataContextException(dbErrorUD);


                var dbCommandUC = new SqlCommand("spFront_getContactos")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommandUC.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = DatosUsuarioRES.Usuario.IDUSUARIO;
                if (ExecuteReader(ref dbCommandUC, out DataTable DataTableUC, out string dbErrorUC))
                {
                    List<ContactoBE> lstContactos = new List<ContactoBE>();
                    foreach (DataRow row in DataTableUC.Rows)
                    {
                        ContactoBE ContactoRES = new ContactoBE();
                        ContactoRES.IDCONTACTO = Convert.ToInt64(row["IDCONTACTO"]);
                        ContactoRES.IDUSUARIO = Convert.ToInt64(row["IDUSUARIO"]);
                        ContactoRES.IDTIPOCONTACTO = Convert.ToInt32(row["IDTIPOCONTACTO"]);
                        ContactoRES.TIPOCONTACTO = row["TIPOCONTACTO"].ToString();
                        ContactoRES.VALOR = row["VALOR"].ToString();
                        ContactoRES.FECHAALTA = Convert.ToDateTime(row["FECHAALTA"]);
                        ContactoRES.ACTIVO = Convert.ToBoolean(row["ACTIVO"]);
                        lstContactos.Add(ContactoRES);
                    }
                    DatosUsuarioRES.Contactos = lstContactos;
                }
                else throw new DbDataContextException(dbErrorUC);


                var dbCommandRXU = new SqlCommand("spFront_getRolesXUserApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommandRXU.Parameters.Add("@TIPOBUSQUEDA", SqlDbType.Int).Value = Reglas.TIPOBUSQUEDA;
                dbCommandRXU.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = Reglas.USUARIO;
                dbCommandRXU.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = Reglas.IDAPP;
                if (ExecuteReader(ref dbCommandRXU, out DataTable DataTableRXU, out string dbErrorRXU))
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
                }
                else throw new DbDataContextException(dbErrorRXU);
               

              

                return DatosUsuarioRES;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
            
        }

        public List<UsuariosBE> GetUsuarios(UsuariosBE item, Int64 App)
        {
            
            List<UsuariosBE> lstUsuarios = new List<UsuariosBE>();
            try
            {

                DatosUsuarioBE DatosUsuarioRES = new DatosUsuarioBE();
                var dbCommand = new SqlCommand("spFrontGetUsuarios")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IdAplicacion", SqlDbType.NVarChar).Value = int.Parse(item.IDAPLICACION.ToString());
                dbCommand.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = item.NOMBRE;
                dbCommand.Parameters.Add("@AMaterno", SqlDbType.NVarChar).Value = item.AMATERNO;
                dbCommand.Parameters.Add("@APaterno", SqlDbType.NVarChar).Value = item.APATERNO;
                dbCommand.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = item.IDUSUARIOAPP;



                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        UsuariosBE itemLector = new UsuariosBE();
                        itemLector.IDUSUARIO = Convert.ToInt64(row["IDUSUARIO"]);

                        //itemLector.IDAPLICACION = Lector.IDAPLICACION;
                        itemLector.DESCAREA = row["AREA"].ToString();
                        itemLector.APATERNO = row["APATERNO"].ToString();
                        itemLector.AMATERNO = row["AMATERNO"].ToString();
                        itemLector.NOMBRE = row["NOMBRE"].ToString();
                        itemLector.FECHANACCONST = Convert.ToDateTime(row["FECHANACCONST"]);
                        itemLector.USUARIO = row["USUARIO"].ToString();
                        itemLector.ACTIVO = bool.Parse(string.IsNullOrEmpty(row["ACTIVO"].ToString()) ? "false" : "true");

                        lstUsuarios.Add(itemLector);
                    }
                }
                else throw new DbDataContextException(dbError);

               
               
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
           
            return lstUsuarios;
        }

        public List<UsuariosBE> GetUsuario(UsuariosBE item, Int64 App)
        {
            
            List<UsuariosBE> lstUsuarios = new List<UsuariosBE>();
            try
            {

                DatosUsuarioBE DatosUsuarioRES = new DatosUsuarioBE();
                var dbCommand = new SqlCommand("spFrontGetUsuario")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IdUsuario", SqlDbType.NVarChar).Value = item.IDUSUARIO.ToString();



                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
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
                }
                else throw new DbDataContextException(dbError);
              
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
           

            return lstUsuarios;
        }

        public bool actDeactivateUsuario(ReglasBE Reglas, Int64 App)
        {
            try
            {
               

                bool Respuesta = true;
                var dbCommand = new SqlCommand("spFront_actDeactUsuario")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@TIPOUSUARIOIN", SqlDbType.BigInt).Value = Reglas.TIPOBUSQUEDA;
                dbCommand.Parameters.Add("@ACTDEACTIVATE", SqlDbType.BigInt).Value = Reglas.ACTIVO;
                dbCommand.Parameters.Add("@USUARIOIN", SqlDbType.BigInt).Value = Reglas.USUARIO;
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = Reglas.IDAPP;
                dbCommand.Parameters.Add("@IDUSERMODIFICA", SqlDbType.BigInt).Value = Reglas.IDUSRMODIF;
                dbCommand.Parameters.Add("@IDAPPMODIFICA", SqlDbType.BigInt).Value = App;
                
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                    {
                        Respuesta = true;
                    }
                    else
                    {
                        Respuesta = false;
                    }

                }
                else throw new DbDataContextException(dbError);               
                return Respuesta;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public bool updateUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, Int64 App)
        {
            
          
            UsuariosBE UsuarioRes = new UsuariosBE();
            bool bFlag = true;
            try
            {

                ////Actualizamos al usuario
                ///
                var dbCommand = new SqlCommand("spFront_updUsuario")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = Usuario.IDUSUARIO;
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
                dbCommand.Parameters.Add("@IDSEXO", SqlDbType.Int).Value = (Usuario.IDSEXO > 0 ? (Int32?)Usuario.IDSEXO : null);
                dbCommand.Parameters.Add("@IDTIPOPERSONA", SqlDbType.Int).Value = (Usuario.IDTIPOPERSONA > 0 ? (Int32?)Usuario.IDTIPOPERSONA : null);
                dbCommand.Parameters.Add("@IDESTADOCIVIL", SqlDbType.Int).Value = (Usuario.IDESTADOCIVIL > 0 ? (Int32?)Usuario.IDESTADOCIVIL : null);
                dbCommand.Parameters.Add("@IDAREA", SqlDbType.Int).Value = (Usuario.IDAREA > 0 ? (Int32?)Usuario.IDAREA : null);
                dbCommand.Parameters.Add("@IDTIPOUSUARIO", SqlDbType.Int).Value = (Usuario.IDTIPOUSUARIO > 0 ? (Int32?)Usuario.IDTIPOUSUARIO : null);
                dbCommand.Parameters.Add("@IDUSUARIOAPP", SqlDbType.VarChar).Value = Usuario.IDUSUARIOAPP;
                dbCommand.Parameters.Add("@APATERNO", SqlDbType.VarChar).Value = Usuario.APATERNO;
                dbCommand.Parameters.Add("@AMATERNO", SqlDbType.VarChar).Value = Usuario.AMATERNO;
                dbCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = Usuario.NOMBRE;
                dbCommand.Parameters.Add("@FECHANACCONST", SqlDbType.DateTime).Value = Usuario.FECHANACCONST;
                dbCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = Usuario.USUARIO;
                dbCommand.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = Usuario.PASSWORD;
                dbCommand.Parameters.Add("@RUTAFOTOPERFIL", SqlDbType.VarChar).Value = Usuario.RUTAFOTOPERFIL;
                dbCommand.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Usuario.ACTIVO;
                dbCommand.Parameters.Add("@IDUSERMODIFICA", SqlDbType.BigInt).Value = (Reglas.IDUSRMODIF > 0 ? (Int64?)Reglas.IDUSRMODIF : null);
                dbCommand.Parameters.Add("@IDAPPMODIFICA", SqlDbType.BigInt).Value = App;

                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                    {
                        bFlag = true;
                    }
                    else
                    {
                        bFlag = false;
                    }

                }
                else throw new DbDataContextException(dbError);


                ////Insertamos sus Domicilios
                if (Domicilios != null)
                {
                    foreach (DomicilioBE Dom in Domicilios)
                    {
                        if (Dom.IDDOMICILIO > 0)
                        {
                            var dbCommandUD = new SqlCommand("spFront_updDomicilio")
                            {
                                CommandType = CommandType.StoredProcedure
                            };

                            dbCommandUD.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = Usuario.IDUSUARIO;
                            dbCommandUD.Parameters.Add("@IDDOMICILIO", SqlDbType.BigInt).Value = Dom.IDDOMICILIO;
                            dbCommandUD.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = Dom.CALLE;
                            dbCommandUD.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = Dom.NUMEXT;
                            dbCommandUD.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = Dom.NUMINT;
                            dbCommandUD.Parameters.Add("@IDESTADO", SqlDbType.Int).Value = (Int32.Parse(Dom.IDESTADO) > 0 ? (Int32?)Int32.Parse(Dom.IDESTADO) : null);
                            dbCommandUD.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = Dom.ESTADO;
                            dbCommandUD.Parameters.Add("@IDMUN", SqlDbType.Int).Value = (Int32.Parse(Dom.IDMUNICIPIO) > 0 ? (Int32?)Int32.Parse(Dom.IDMUNICIPIO) : null);
                            dbCommandUD.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = Dom.MUNICIPIO;
                            dbCommandUD.Parameters.Add("@IDCOLONIA", SqlDbType.Int).Value = (Int32.Parse(Dom.IDCOLONIA) > 0 ? (Int32?)Int32.Parse(Dom.IDCOLONIA) : null);
                            dbCommandUD.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = Dom.COLONIA;
                            dbCommandUD.Parameters.Add("@CP", SqlDbType.VarChar).Value = Dom.CP;
                            dbCommandUD.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
                            dbCommandUD.Parameters.Add("@IDUSERMODIFICA", SqlDbType.BigInt).Value = (Reglas.IDUSRMODIF > 0 ? (Int64?)Reglas.IDUSRMODIF : null);
                            dbCommandUD.Parameters.Add("@IDAPPMODIFICA", SqlDbType.BigInt).Value = App;

                            if (ExecuteNonQuery(ref dbCommandUD, out int rowsAffectedUD, out string dbErrorUD))
                            {
                            }
                            else throw new DbDataContextException(dbErrorUD);
                        }

                        else
                        {
                            var dbCommandID = new SqlCommand("spFront_insDomicilio")
                            {
                                CommandType = CommandType.StoredProcedure
                            };

                            dbCommandID.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = Usuario.IDUSUARIO;
                            dbCommandID.Parameters.Add("@CALLE", SqlDbType.VarChar).Value = Dom.CALLE;
                            dbCommandID.Parameters.Add("@NUMEXT", SqlDbType.VarChar).Value = Dom.NUMEXT;
                            dbCommandID.Parameters.Add("@NUMINT", SqlDbType.VarChar).Value = Dom.NUMINT;
                            dbCommandID.Parameters.Add("@IDESTADO", SqlDbType.Int).Value = (Int32.Parse(Dom.IDESTADO) > 0 ? (Int32?)Int32.Parse(Dom.IDESTADO) : null);
                            dbCommandID.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = Dom.ESTADO;
                            dbCommandID.Parameters.Add("@IDMUN", SqlDbType.Int).Value = (Int32.Parse(Dom.IDMUNICIPIO) > 0 ? (Int32?)Int32.Parse(Dom.IDMUNICIPIO) : null);
                            dbCommandID.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = Dom.MUNICIPIO;
                            dbCommandID.Parameters.Add("@IDCOLONIA", SqlDbType.Int).Value = (Int32.Parse(Dom.IDCOLONIA) > 0 ? (Int32?)Int32.Parse(Dom.IDCOLONIA) : null);
                            dbCommandID.Parameters.Add("@COLONIA", SqlDbType.VarChar).Value = Dom.COLONIA;
                            dbCommandID.Parameters.Add("@CP", SqlDbType.VarChar).Value = Dom.CP;
                            dbCommandID.Parameters.Add("@FECHAALTA", SqlDbType.DateTime).Value = DateTime.Now;
                            dbCommandID.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = true;
                            dbCommandID.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
                            dbCommandID.Parameters.Add("@IDUSERMODIFICA", SqlDbType.BigInt).Value = (Reglas.IDUSRMODIF > 0 ? (Int64?)Reglas.IDUSRMODIF : null);
                            dbCommandID.Parameters.Add("@IDAPPMODIFICA", SqlDbType.BigInt).Value = App;

                            if (ExecuteNonQuery(ref dbCommandID, out int rowsAffectedID, out string dbErrorID))
                            {
                            }
                            else throw new DbDataContextException(dbErrorID);

                        }
                    }
                }

                    ////Insertamos sus Contactos
                    if (Contactos != null)
                    {
                        foreach (ContactoBE Contacto in Contactos)
                        {
                            if (Contacto.IDCONTACTO > 0)
                            {
                                var dbCommandUC = new SqlCommand("spFront_updContacto")
                                {
                                    CommandType = CommandType.StoredProcedure
                                };

                                dbCommandUC.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = Usuario.IDUSUARIO;
                                dbCommandUC.Parameters.Add("@IDCONTACTO", SqlDbType.BigInt).Value = Contacto.IDCONTACTO;
                                dbCommandUC.Parameters.Add("@IDTIPOCONTACTO", SqlDbType.Int).Value = Contacto.IDTIPOCONTACTO;
                                dbCommandUC.Parameters.Add("@VALOR", SqlDbType.VarChar).Value = Contacto.VALOR;
                                dbCommandUC.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Contacto.ACTIVO;
                                dbCommandUC.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
                                dbCommandUC.Parameters.Add("@IDUSERMODIFICA", SqlDbType.BigInt).Value = (Reglas.IDUSRMODIF > 0 ? (Int64?)Reglas.IDUSRMODIF : null);
                                dbCommandUC.Parameters.Add("@IDAPPMODIFICA", SqlDbType.BigInt).Value = App;

                                if (ExecuteNonQuery(ref dbCommandUC, out int rowsAffectedUC, out string dbErrorUC))
                                {
                                }
                                else throw new DbDataContextException(dbErrorUC);

                            }
                            else
                            {
                                var dbCommandIC = new SqlCommand("spFront_insContacto")
                                {
                                    CommandType = CommandType.StoredProcedure
                                };

                                dbCommandIC.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = Usuario.IDUSUARIO;
                                dbCommandIC.Parameters.Add("@IDTIPOCONTACTO", SqlDbType.Int).Value = Contacto.IDTIPOCONTACTO;
                                dbCommandIC.Parameters.Add("@VALOR", SqlDbType.VarChar).Value = Contacto.VALOR;
                                dbCommandIC.Parameters.Add("@FECHAALTA", SqlDbType.DateTime).Value = DateTime.Now;
                                dbCommandIC.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = true;
                                dbCommandIC.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = App;
                                dbCommandIC.Parameters.Add("@IDUSERMODIFICA", SqlDbType.BigInt).Value = (Reglas.IDUSRMODIF > 0 ? (Int64?)Reglas.IDUSRMODIF : null);
                                dbCommandIC.Parameters.Add("@IDAPPMODIFICA", SqlDbType.BigInt).Value = App;

                                if (ExecuteNonQuery(ref dbCommandIC, out int rowsAffectedIC, out string dbErrorIC))
                                {
                                }
                                else throw new DbDataContextException(dbErrorIC);

                            }

                        }
                    }

                    ////Insertamos Aplicaciones X Usuario
                    if (Usuario.IDAPLICACION == 0)
                    {
                        foreach (var Rol in RolesXUsuario)
                        {
                            var dbCommandUXAP = new SqlCommand("spFrontAddUsuarioXAplicacion")
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            dbCommandUXAP.Parameters.Add("@IDUSRSXAPP", SqlDbType.NVarChar).Value = long.Parse(Rol.IDAPLICACION);
                            dbCommandUXAP.Parameters.Add("@IDAPLICACION", SqlDbType.NVarChar).Value = Usuario.IDUSUARIO;
                            dbCommandUXAP.Parameters.Add("@IDUSUARIO", SqlDbType.NVarChar).Value = true;

                            if (ExecuteNonQuery(ref dbCommandUXAP, out int rowsAffectedUXAP, out string dbErrorUXAP))
                            {
                            }
                            else throw new DbDataContextException(dbErrorUXAP);
                        }

                    }


                    if (RolesXUsuario != null)
                    {
                        foreach (RolesXUsuarioBE Rol in RolesXUsuario)
                        {
                            var dbCommandRXU = new SqlCommand("spFront_insRolXUserApp")
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            dbCommandRXU.Parameters.Add("@IDROL", SqlDbType.BigInt).Value = Rol.IDROL;
                            dbCommandRXU.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = Usuario.IDUSUARIO;
                            dbCommandRXU.Parameters.Add("@IDESTACIONXAPP", SqlDbType.BigInt).Value = (Rol.IDESTACIONXAPP > 0 ? (Int64?)Rol.IDESTACIONXAPP : null);
                            dbCommandRXU.Parameters.Add("@IDROLXUSUARIO", SqlDbType.BigInt).Value = (Rol.IDROLXUSUARIO > 0 ? (Int64?)Rol.IDROLXUSUARIO : null);
                            dbCommandRXU.Parameters.Add("@ACTIVO", SqlDbType.Bit).Value = Rol.ACTIVO;
                            if (ExecuteNonQuery(ref dbCommandRXU, out int rowsAffectedRXU, out string dbErrorRXU))
                            {
                            }
                            else throw new DbDataContextException(dbErrorRXU);

                            //var dbCommandUXA = new SqlCommand("spFront_addUsuarioXAplicacion")
                            //{
                            //    CommandType = CommandType.StoredProcedure
                            //};
                            //dbCommandUXA.Parameters.Add("@IDUSRSXAPP", SqlDbType.NVarChar).Value = "";
                            //dbCommandUXA.Parameters.Add("@IDAPLICACION", SqlDbType.NVarChar).Value = Rol.IDAPLICACION;
                            //dbCommandUXA.Parameters.Add("@IDUSUARIO", SqlDbType.NVarChar).Value = Usuario.IDUSUARIO.ToString();
                            //dbCommandUXA.Parameters.Add("@ACTIVO", SqlDbType.NVarChar).Value = "1";
                            //if (ExecuteNonQuery(ref dbCommandUXA, out int rowsAffectedUXA, out string dbErrorUXA))
                            //{
                            //}
                            //else throw new DbDataContextException(dbErrorUXA);
                            //}
                        }

                        //Verificar Actualizacion de Apliacion X Usuario
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

        public bool checkUsrXApp(ReglasBE Reglas, Int64 App)
        {
            try
            {
                
                DatosUsuarioBE DatosUsuarioRES = new DatosUsuarioBE();
                bool bFlag = false;
                var dbCommand = new SqlCommand("spFront_checkUsrXApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@TIPOBUSQUEDA", SqlDbType.Int).Value = Reglas.TIPOBUSQUEDA;
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = Reglas.IDAPP;
                dbCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = Reglas.USUARIO;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        bFlag = true;
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);
                return bFlag;
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
                
                DatosUsuarioBE DatosUsuarioRES = new DatosUsuarioBE();
                bool bFlag = false;
                var dbCommand = new SqlCommand("sp_checkUsr")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@TIPOBUSQUEDA", SqlDbType.Int).Value = Reglas.TIPOBUSQUEDA;
                dbCommand.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = Reglas.USUARIO;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        bFlag = true;
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);
               
                return bFlag;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", Reglas.IDAPP.ToString());
                throw new Exception(ex.Message);
            }
        }


        public List<UsuarioXAppBE> getAppXUsuario(ReglasBE Reglas, Int64 App)
        {
            try
            {
                
                List<UsuarioXAppBE> ListaApps = new List<UsuarioXAppBE>();
                var dbCommand = new SqlCommand("spFront_getAppsXUsuario")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@TIPOBUSQUEDA", SqlDbType.BigInt).Value = Reglas.TIPOBUSQUEDA;
                dbCommand.Parameters.Add("@USUARIO", SqlDbType.BigInt).Value = Reglas.USUARIO;


                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
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
                }
                else throw new DbDataContextException(dbError);              
                return ListaApps;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public List<EstacionesXAppBE> getEstacionesXApp(ReglasBE Reglas, Int64 App)
        {
            try
            {
                
                List<EstacionesXAppBE> ListaEstaciones = new List<EstacionesXAppBE>();

                var dbCommand = new SqlCommand("spFront_getEstacionesXApps")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = Reglas.IDAPP;
               

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
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

                }
                else throw new DbDataContextException(dbError);
                return ListaEstaciones;
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
                    var dbCommand = new SqlCommand("spFront_insRolesXUsuario")
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    dbCommand.Parameters.Add("@IDROL", SqlDbType.BigInt).Value = Rol.IDROL;
                    dbCommand.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = Rol.IDUSUARIO;
                    dbCommand.Parameters.Add("@IDESTACIONXAPP", SqlDbType.BigInt).Value = (Rol.IDESTACIONXAPP > 0 ? (Int64?)Rol.IDESTACIONXAPP : null);
                    

                    if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                    {
                        if (rowsAffected > 0)
                        {
                            bFlag = true;
                        }
                        else
                        {
                            bFlag = false;
                        }

                    }
                    else throw new DbDataContextException(dbError);
                    
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

        public List<RolesXUsuarioBE> GetRolesVsUser(ReglasBE Reglas, Int64 App)
        {
            try
            {
                
                List<RolesXUsuarioBE> RolesVSUsuarios = new List<RolesXUsuarioBE>();
                var dbCommand = new SqlCommand("spFrontGetRolesVSUsuario")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDUSUARIO", SqlDbType.NVarChar).Value = Reglas.USUARIO;
                dbCommand.Parameters.Add("@IDAPLICAION", SqlDbType.NVarChar).Value = Reglas.IDAPP.ToString();

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        RolesXUsuarioBE RolesXUsuario = new RolesXUsuarioBE();

                        RolesXUsuario.IDROL = Convert.ToInt64(row["IDROL"]);
                        RolesXUsuario.DESCROL = row["DESCRIPCION"].ToString();
                        RolesXUsuario.IDAPLICACION = row["IDAPLICACION"].ToString();
                        RolesXUsuario.APLICACION = row["APLICACION"].ToString();
                        RolesXUsuario.IDROLXUSUARIO = Convert.ToInt64(row["IDROLXUSUARIO"]);
                        RolesXUsuario.ACTIVO = (Convert.ToInt32(row["ROLASIGNADO"]) ==  0) ? false : true;


                        RolesVSUsuarios.Add(RolesXUsuario);

                    }

                }
                else throw new DbDataContextException(dbError);
               
                return RolesVSUsuarios;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public bool addUsuarioXAplicacion(ReglasBE Reglas, List<UsuarioXAppBE> lstUSuarioXApp, Int64 App)
        {
            try
            {
                
                bool bFlag = true;

                foreach (UsuarioXAppBE item in lstUSuarioXApp)
                {

                    var dbCommand = new SqlCommand("spFront_addUsuarioXAplicacion")
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    dbCommand.Parameters.Add("@IDUSRSXAPP", SqlDbType.BigInt).Value = item.IDUSRSXAPP;
                    dbCommand.Parameters.Add("@IDAPLICACION", SqlDbType.BigInt).Value = item.IDAPLICACION;
                    dbCommand.Parameters.Add("@IDUSUARIO", SqlDbType.BigInt).Value = item.IDUSUARIO;
                    dbCommand.Parameters.Add("@ACTIVO", SqlDbType.BigInt).Value = item.ACTIVO;

                    if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                    {
                        if (rowsAffected > 0)
                        {
                            bFlag = true;
                        }
                        else
                        {
                            bFlag = false;
                        }

                    }
                    else throw new DbDataContextException(dbError);
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

        public List<RolesBE> getRolesXApp(ReglasBE Reglas, Int64 App)
        {
            try
            {
                
                List<RolesBE> RolesXApp = new List<RolesBE>();
                var dbCommand = new SqlCommand("spFront_getRolesXApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDAPLICAION", SqlDbType.BigInt).Value = Reglas.IDAPP;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
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
                   
                }
                else throw new DbDataContextException(dbError);
                return RolesXApp;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
        }

        public List<CatalogosBE> getCatSelection(int IdCatGeneral, int IdSubCatalogo, Int64 App)
        {
            try
            {
                

                List<CatalogosBE> ListaCatalogo = new List<CatalogosBE>();
                CatalogosBE items = new CatalogosBE();

                var dbCommand = new SqlCommand("spFront_getCatGenerales")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDAPLICAION", SqlDbType.Int).Value = IdCatGeneral;
                Cat_GralsBE CatGrasl = new Cat_GralsBE();
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                   
                    foreach (DataRow row in DataTable.Rows)
                    {
                       
                        CatGrasl.IDCATGRAL = Convert.ToInt64(row["IDCATGRAL"]);
                        CatGrasl.NOMBRETABLA = row["NOMBRETABLA"].ToString();
                        CatGrasl.IDTABLA = row["IDTABLA"].ToString(); 
                        CatGrasl.DESCRIPCIONTABLA = row["DESCRIPCIONTABLA"].ToString(); 
                        CatGrasl.IDFILTRO = row["IDFILTRO"].ToString();

                    }

                }
                else throw new DbDataContextException(dbError);              


                ////Obtenemos finalmente el catalogo

                StringBuilder sComando = new StringBuilder(string.Empty);
                sComando.Append("SELECT CONVERT(VARCHAR(250),");
                sComando.Append(CatGrasl.IDTABLA); sComando.Append(") AS ID,");
                sComando.Append("CONVERT(VARCHAR(250),");
                sComando.Append(CatGrasl.DESCRIPCIONTABLA); sComando.Append(")");
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
                else sComando.Append(" WHERE ACTIVO = 1 ");



                List<CatalogosBE> ListCatalogo = new List<CatalogosBE>();
                var dbCommandText = new SqlCommand(sComando.ToString())
                {
                    CommandType = CommandType.Text
                };

                if (ExecuteReader(ref dbCommandText, out DataTable DataTableText, out string dbErrorText))
                {
                    foreach (DataRow rowT in DataTableText.Rows)
                    {
                        CatalogosBE item = new CatalogosBE();
                        item.ID = rowT["ID"].ToString();
                        item.DESCRIPCION = rowT["DESCRIPCION"].ToString().ToUpper();
                        ListaCatalogo.Add(item);
                    }

                }
                else throw new DbDataContextException(dbErrorText);
                List<CatalogosBE> ListaGrlSort = ListaCatalogo.OrderBy(x => x.DESCRIPCION).ThenBy(x => x.DESCRIPCION).ToList();
                CatalogosBE lista = new CatalogosBE();
                lista.ID = "0";
                lista.DESCRIPCION = "[SELECCIONE UNA OPCIÓN]";
                ListaGrlSort.Insert(0, lista);

                return ListaGrlSort;
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
                var dbCommand = new SqlCommand("spFront_updRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IDROLXUSUARIO", SqlDbType.BigInt).Value = RolXUsuario.IDROLXUSUARIO;
                dbCommand.Parameters.Add("@IDROL", SqlDbType.BigInt).Value = RolXUsuario.IDROL;
                dbCommand.Parameters.Add("@IDESTACIONXAPP", SqlDbType.BigInt).Value = RolXUsuario.IDESTACIONXAPP;

                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                    if (rowsAffected > 0)
                    {
                        Respuesta = true;
                    }
                    else
                    {
                        Respuesta = false;
                    }

                }
                else throw new DbDataContextException(dbError);
                return Respuesta;
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
                var dbCommand = new SqlCommand("sp_getUsuariosXIdRol")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@IdRol", SqlDbType.BigInt).Value = IdRol;

                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
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
                   
                }
                else throw new DbDataContextException(dbError);
               
                return DatosUsuarioRES;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(true);
                
                insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
                throw new Exception(ex.Message);
            }
          
        }     

        public string getUsrIdApp(Int64 App)
        {
            try
            {
                
                DatosUsuarioBE DatosUsuarioRES = new DatosUsuarioBE();
                string IdUsrApp = string.Empty;


                var dbCommand = new SqlCommand("sp_setIdUsrApp")
                {
                    CommandType = CommandType.StoredProcedure
                };
                if (ExecuteReader(ref dbCommand, out DataTable DataTable, out string dbError))
                {
                    foreach (DataRow row in DataTable.Rows)
                    {
                        IdUsrApp = row["USUARIO"].ToString();
                        break;
                    }
                }
                else throw new DbDataContextException(dbError);
                return IdUsrApp;
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
                if (MessageErr.Length > 445) MessageErr = MessageErr.Substring(0, 445);
                //Obtiene el hostname
                String strHostname = Dns.GetHostName();
                IPHostEntry myself = Dns.GetHostEntry(strHostname);

                ////Obtiene la Ip del usuario que genero el error
                System.Net.IPAddress ip = myself.AddressList.Where(n => n.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
                string sIp = ip.ToString();

                StringBuilder strStackTrace = new StringBuilder();
                foreach (StackFrame f in st.GetFrames())
                {
                    strStackTrace.Append(f.ToString());
                    break;
                }

                //if (MessageErr.Length > 490) MessageErr = MessageErr.Substring(0, 448);

                if (strStackTrace.Length > 490)// Validamos la longitud del stack
                {
                    string sStackTrace = strStackTrace.ToString();
                    strStackTrace.Clear();
                    strStackTrace.Append(sStackTrace.Substring(0, 490));
                }

                if (sIp.Length > 39) sIp = sIp.Substring(0, 39);
                if (strHostname.Length > 148) strHostname = strHostname.Substring(0, 148);

                //Inserta en la tabla del log de errores


                var dbCommand = new SqlCommand("sp_insLogError")
                {
                    CommandType = CommandType.StoredProcedure
                };
                dbCommand.Parameters.Add("@idApp", SqlDbType.BigInt).Value = Int64.Parse(sApp);
                dbCommand.Parameters.Add("@MENSAJE", SqlDbType.VarChar).Value = MessageErr;
                dbCommand.Parameters.Add("@HOSTNAME", SqlDbType.VarChar).Value = strHostname;
                dbCommand.Parameters.Add("@IP", SqlDbType.VarChar).Value = sIp;
                dbCommand.Parameters.Add("@STACKTRACE", SqlDbType.VarChar).Value = strStackTrace.ToString();
                dbCommand.Parameters.Add("@DTFECHAERROR", SqlDbType.DateTime).Value = DateTime.Now;
                dbCommand.Parameters.Add("@VCHUSUARIO", SqlDbType.VarChar).Value = user;
                if (ExecuteNonQuery(ref dbCommand, out int rowsAffected, out string dbError))
                {
                }
                else throw new DbDataContextException(dbError);



            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




    }
}

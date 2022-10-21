using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.Common;
using ThreeBits.Data.Security;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.User;

namespace ThreeBits.Data.User
{
    public class UsersDA : SqlDataContext
    {
       
    

        //public DatosUsuarioBE GetUsuarioFull(ReglasBE Reglas, Int64 App)
        //{
        //    //linqSeguridadLatinoDataContext dboSegLatino = new linqSeguridadLatinoDataContext();
        //    try
        //    {
        //        DatosUsuarioBE DatosUsuarioRES = new DatosUsuarioBE();

        //        var Cliente = GetDynamicResult(" exec spFront_getUsuario @TIPOBUSQUEDA, @USUARIO, @IDAPP", new SqlParameter("@TIPOBUSQUEDA", Reglas.TIPOBUSQUEDA), new SqlParameter("@USUARIO", Reglas.USUARIO), new SqlParameter("@IDAPP", Reglas.IDAPP));

        //       // var Cliente =  dboSegLatino.spFront_getUsuario(Reglas.TIPOBUSQUEDA, Reglas.USUARIO, Reglas.IDAPP);
        //        if (!string.IsNullOrEmpty(Reglas.TIPOUSUARIO.ToString()))
        //        {
        //            Cliente.Where(x => x.IDTIPOUSUARIO == Reglas.TIPOUSUARIO);
        //        }


        //        foreach (var s in Cliente)
        //        {
        //            UsuariosBE UsuarioRES = new UsuariosBE();
        //            UsuarioRES.IDUSUARIO = s.IDUSUARIO;
        //            UsuarioRES.IDAPLICACION = s.IDAPLICACION;
        //            UsuarioRES.IDSEXO = s.IDSEXO ?? 0;
        //            UsuarioRES.IDTIPOPERSONA = s.IDTIPOPERSONA ?? 0;
        //            UsuarioRES.IDESTADOCIVIL = s.IDESTADOCIVIL ?? 0;
        //            UsuarioRES.IDAREA = s.IDAREA ?? 0;
        //            UsuarioRES.DESCAREA = s.DESCAREA;
        //            UsuarioRES.IDTIPOUSUARIO = s.IDTIPOUSUARIO ?? 0;
        //            UsuarioRES.DESCTIPOUSUARIO = s.DESCIDTIPOUSUARIO;
        //            UsuarioRES.IDUSUARIOAPP = s.IDUSUARIOAPP;
        //            UsuarioRES.APATERNO = s.APATERNO;
        //            UsuarioRES.AMATERNO = s.AMATERNO;
        //            UsuarioRES.NOMBRE = s.NOMBRE;
        //            UsuarioRES.FECHANACCONST = s.FECHANACCONST;
        //            UsuarioRES.USUARIO = s.USUARIO;
        //            UsuarioRES.PASSWORD = s.PASSWORD;
        //            UsuarioRES.RUTAFOTOPERFIL = s.RUTAFOTOPERFIL;
        //            UsuarioRES.FECHAALTA = s.FECHAALTA ?? DateTime.Now;
        //            UsuarioRES.ACTIVO = s.ACTIVO ?? false;
        //            DatosUsuarioRES.Usuario = UsuarioRES;
        //        }
        //        if (DatosUsuarioRES.Usuario.IDUSUARIO == 0) throw new Exception("EL USUARIO NO HA SIDO DADO DE ALTO O NO TIENE PERMISOS");

        //      //  var Domicilios = dboSegLatino.spFront_getDomicilios(DatosUsuarioRES.Usuario.IDUSUARIO);
        //        var Domicilios = GetDynamicResult(" exec spFront_getDomicilios @IDUSUARIO", new SqlParameter("@IDUSUARIO", DatosUsuarioRES.Usuario.IDUSUARIO));
        //        foreach (var s in Domicilios)
        //        {
        //            DomicilioBE DomicilioRES = new DomicilioBE();
        //            DomicilioRES.IDDOMICILIO = s.IDDOMICILIO;
        //            DomicilioRES.IDUSUARIO = s.IDUSUARIO ?? 0;
        //            DomicilioRES.CALLE = s.CALLE;
        //            DomicilioRES.NUMEXT = s.NUMEXT;
        //            DomicilioRES.NUMINT = s.NUMINT;
        //            DomicilioRES.IDESTADO = string.IsNullOrEmpty(s.IDESTADO.ToString()) ? "0" : s.IDESTADO.ToString();
        //            //DomicilioRES.IDESTADO = (s.IDESTADO ?? 0).ToString();
        //            DomicilioRES.ESTADO = s.ESTADO;
        //            DomicilioRES.IDMUNICIPIO = string.IsNullOrEmpty(s.IDMUN.ToString()) ? "0" : s.IDMUN.ToString();
        //            //DomicilioRES.IDMUNICIPIO = (s.IDMUN ?? 0).ToString();
        //            DomicilioRES.MUNICIPIO = s.MUNICIPIO;
        //            DomicilioRES.IDCOLONIA = string.IsNullOrEmpty(s.IDCOLONIA.ToString()) ? "0" : s.IDCOLONIA.ToString();
        //            //DomicilioRES.IDCOLONIA = (s.IDCOLONIA ?? 0).ToString();
        //            DomicilioRES.COLONIA = s.COLONIA;
        //            DomicilioRES.CP = s.CP;
        //            DomicilioRES.FECHAALTA = s.FECHAALTA ?? DateTime.Now;
        //            DomicilioRES.ACTIVO = s.ACTIVO ?? false;
        //            DatosUsuarioRES.Domicilios.Add(DomicilioRES);
        //        }

        //       // var Contactos = dboSegLatino.spFront_getContactos(DatosUsuarioRES.Usuario.IDUSUARIO);
        //        var Contactos = GetDynamicResult(" exec spFront_getContactos @IDUSUARIO", new SqlParameter("@IDUSUARIO", DatosUsuarioRES.Usuario.IDUSUARIO));
        //        foreach (var s in Contactos)
        //        {
        //            ContactoBE ContactoRES = new ContactoBE();
        //            ContactoRES.IDCONTACTO = s.IDCONTACTO;
        //            ContactoRES.IDUSUARIO = s.IDUSUARIO ?? 0;
        //            ContactoRES.IDTIPOCONTACTO = s.IDTIPOCONTACTO ?? 0;
        //            ContactoRES.TIPOCONTACTO = s.TIPOCONTACTO;
        //            ContactoRES.VALOR = s.VALOR;
        //            ContactoRES.FECHAALTA = s.FECHAALTA ?? DateTime.Now;
        //            ContactoRES.ACTIVO = s.ACTIVO ?? false;
        //            DatosUsuarioRES.Contactos.Add(ContactoRES);
        //        }

        //       // var Roles = dboSegLatino.spFront_getRolesXUserApp(Reglas.TIPOBUSQUEDA, Reglas.USUARIO, Reglas.IDAPP);
        //        var Roles = GetDynamicResult(" exec spFront_getRolesXUserApp @TIPOBUSQUEDA,@USUARIO,@IDAPP", new SqlParameter("@TIPOBUSQUEDA", Reglas.TIPOBUSQUEDA), new SqlParameter("@USUARIO", Reglas.USUARIO), new SqlParameter("@IDAPP", Reglas.IDAPP));
        //        ////DatosUsuarioRES.RolesXUsuario = Utilidades<ROLESXUSUARIO, RolesXUsuarioBE>.Transformar(dboSegLatino.spFront_getRolesXUserApp(Reglas.TIPOBUSQUEDA, Reglas.USUARIO, Reglas.IDAPP));

        //        foreach (var Rol in Roles)
        //        {
        //            RolesXUsuarioBE RolesXUsuario = new RolesXUsuarioBE();
        //            RolesXUsuario.IDROLXUSUARIO = Rol.IDROLXUSUARIO;
        //            RolesXUsuario.IDROL = Rol.IDROL ?? 0;
        //            RolesXUsuario.DESCROL = Rol.DESCROL;
        //            RolesXUsuario.IDUSUARIO = Rol.IDUSUARIO ?? 0;
        //            RolesXUsuario.IDESTACIONXAPP = Rol.IDESTACIONXAPP ?? 0;
        //            RolesXUsuario.IDAPLICACION = Rol.IDAPLICACION.ToString();
        //            RolesXUsuario.APLICACION = Rol.DescripcionAplicacion.ToString();
        //            RolesXUsuario.ACTIVO = Rol.ACTIVO ?? false;
        //            DatosUsuarioRES.RolesXUsuario.Add(RolesXUsuario);
        //        }

        //        return DatosUsuarioRES;
        //    }
        //    catch (Exception ex)
        //    {
        //        StackTrace st = new StackTrace(true);
        //        //CommonDA ComunDA = new CommonDA();
        //        //ComunDA.insErrorDB("Error: " + ex.Message + " En El Metodo: " + MethodBase.GetCurrentMethod().Name, st, "", App.ToString());
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
               
        //    }
        //}




    }
}

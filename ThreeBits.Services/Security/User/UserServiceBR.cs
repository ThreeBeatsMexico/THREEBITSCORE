using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.User;
using ThreeBits.Interfaces.Security.Users;

namespace ThreeBits.Services.Security.Security
{
    public class UserServiceBR : _BaseService, IUserServiceBR
    {
        private readonly ILogger _logger;
        private readonly IUserServiceDA _userServiceDA;
       
       

        public UserServiceBR(ILogger<SecurityServiceBR> logger, IUserServiceDA userServiceDA)
        {
            _logger = logger;
            _userServiceDA = userServiceDA;
            
           
        }



        public UsuariosBE addUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, Int64 App)
        {
            UsuariosBE UsuarioRes = new UsuariosBE();
            try
            {
                ////Validamos las cadenas....

                ////Checamos la existencia del usuario
                ReglasBE ReglasInt = new ReglasBE();
                
                //ReglasInt.USUARIO = Reglas.IDUSUARIOAPP;
                //ReglasInt.TIPOBUSQUEDA = Reglas.TIPOBUSQUEDA;
                //ReglasInt.IDAPP = Usuario.IDAPLICACION;
                bool bExistUsr = checkUsrXApp(Reglas, App);
                if (bExistUsr) throw new Exception("El usuario ya se encuentra agregado.");

                ////Validamos la existencia de los roles 
                //List<RolesBE> RolesXApp = getRolesXApp(Reglas, App);
                //bool bFlagExist = false;

                //foreach (RolesXUsuarioBE s in RolesXUsuario)
                //{
                //    bFlagExist = false;
                //    foreach (RolesBE RolXApp in RolesXApp)
                //    {
                //        if (s.IDROL == RolXApp.IDROL)
                //        {
                //            bFlagExist = true;
                //            break;
                //        }
                //    }
                //    if (!bFlagExist) throw new Exception("El rol " + s.IDROL.ToString() + " no pertenece a la aplicación o no existe.");
                //}
                
                UsuarioRes = _userServiceDA.addUsuario(Reglas, Usuario, Domicilios, Contactos, RolesXUsuario, App);

                return UsuarioRes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool actDeactivateUsuario(ReglasBE Reglas, Int64 App)
        {
            bool Respuesta = new bool();
            try
            {
                
                Respuesta = _userServiceDA.actDeactivateUsuario(Reglas, App);
                return Respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updateUsuario(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, Int64 App)
        {
            try
            {
                
                bool bResultado = false;
                bResultado = _userServiceDA.updateUsuario(Reglas, Usuario, Domicilios, Contactos, RolesXUsuario, App);
                return bResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool addRolesXUsuario(ReglasBE Reglas, List<RolesXUsuarioBE> RolesXUsuario, long App)
        {
            try
            {
                

                bool bExistUsr = checkUsrXApp(Reglas, App);
                if (!bExistUsr) throw new Exception("El usuario no pertenece a la aplicación o no existe.");

                ////Validamos la existencia de los roles 
                List<RolesBE> RolesXApp = _userServiceDA.getRolesXApp(Reglas, App);
                bool bFlagExist = false;

                foreach (RolesXUsuarioBE s in RolesXUsuario)
                {
                    bFlagExist = false;
                    foreach (RolesBE RolXApp in RolesXApp)
                    {
                        if (s.IDROL == RolXApp.IDROL)
                        {
                            bFlagExist = true;
                            break;
                        }
                    }
                    if (!bFlagExist) throw new Exception("El rol " + s.IDROL.ToString() + " no pertenece a la aplicación o no existe.");
                }

                return _userServiceDA.addRolesXUsuario(Reglas, RolesXUsuario, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool addUsuarioXAplicacion(ReglasBE Reglas, List<UsuarioXAppBE> lstUSuarioXApp, Int64 App)
        {
            try
            {
                
                bool bFlag = false;

                bFlag = _userServiceDA.addUsuarioXAplicacion(Reglas, lstUSuarioXApp, App);

                return bFlag;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DatosUsuarioBE getUsuarioFull(ReglasBE Reglas, Int64 App)
        {
            DatosUsuarioBE DatosUsuario = new DatosUsuarioBE();
            try
            {
                
                DatosUsuario = _userServiceDA.GetUsuarioFull(Reglas, App);
                return DatosUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UsuariosBE> GetUsuarios(UsuariosBE item, Int64 App)
        {
            List<UsuariosBE> lstUsuario = new List<UsuariosBE>();
            

            lstUsuario = _userServiceDA.GetUsuarios(item, App);

            return lstUsuario;
        }

        public List<UsuariosBE> GetUsuario(UsuariosBE item, Int64 App)
        {
            List<UsuariosBE> Usuarios = new List<UsuariosBE>();
            

            Usuarios = _userServiceDA.GetUsuario(item, App);

            return Usuarios;
        }

        public List<RolesXUsuarioBE> GetRolesVsUser(ReglasBE Reglas, Int64 App)
        {
            List<RolesXUsuarioBE> RolesVSUsuarios = new List<RolesXUsuarioBE>();
            

            RolesVSUsuarios = _userServiceDA.GetRolesVsUser(Reglas, App);

            return RolesVSUsuarios;
        }

        public List<RolesBE> getRolesXApp(ReglasBE Reglas, Int64 App)
        {
            try
            {
                
                return _userServiceDA.getRolesXApp(Reglas, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool checkUsrXApp(ReglasBE Reglas, Int64 App)
        {
            try
            {
                
                return _userServiceDA.checkUsrXApp(Reglas, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool checkUsr(ReglasBE Reglas)
        {
            try
            {
                
                return _userServiceDA.checkUsr(Reglas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UsuarioXAppBE> getAppXUsuario(ReglasBE Reglas, Int64 App)
        {
            try
            {
                
                return _userServiceDA.getAppXUsuario(Reglas, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<EstacionesXAppBE> getEstacionesXApp(ReglasBE Reglas, Int64 App)
        {
            try
            {
                
                return _userServiceDA.getEstacionesXApp(Reglas, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<RelacionTipoUsuarioBE> getRelTipoUsuario(ReglasBE Reglas, Int64 App)
        {
            List<RelacionTipoUsuarioBE> lstResultado = new List<RelacionTipoUsuarioBE>();
            try
            {
                
                //return _userServiceDA.getRelTipoUsuario(Reglas, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstResultado;
        }

        public List<CatalogosBE> getCatSelection(int IdCatGeneral, int IdSubCatalogo, Int64 App)
        {
            try
            {
                
                return _userServiceDA.getCatSelection(IdCatGeneral, IdSubCatalogo, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool updateRol(ReglasBE Reglas, RolesXUsuarioBE RolXUsuario, long App)
        {
            try
            {
                ////Validamos la existencia de los roles 
                List<RolesBE> RolesXApp = getRolesXApp(Reglas, App);
                bool bFlagExist = false;

                bFlagExist = false;
                foreach (RolesBE RolXApp in RolesXApp)
                {
                    if (RolXUsuario.IDROL == RolXApp.IDROL)
                    {
                        bFlagExist = true;
                        break;
                    }
                }
                if (!bFlagExist) throw new Exception("El rol " + RolXUsuario.IDROL.ToString() + " no pertenece a la aplicación o no existe.");

                
                return _userServiceDA.updateRol(Reglas, RolXUsuario, App);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<DatosUsuarioBE> getUsuariosXRol(long IdRol, long App)
        {
            List<DatosUsuarioBE> DatosUsuario = new List<DatosUsuarioBE>();
            try
            {
                
                DatosUsuario = _userServiceDA.getUsuariosXRol(IdRol, App);
                return DatosUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public List<UsuariosBE> getAgentPromsXOfi(string Tipo, string Oficina, long App)
        //{
        //    List<UsuariosBE> Usuarios = new List<UsuariosBE>();
        //    try
        //    {
                
        //        Usuarios = _userServiceDA.getAgentPromsXOfi(Tipo, Oficina, App);
        //        return Usuarios;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public UsuariosBE addUserAut(ReglasBE Reglas, UsuariosBE Usuario, List<DomicilioBE> Domicilios, List<ContactoBE> Contactos, List<RolesXUsuarioBE> RolesXUsuario, long App)
        {
            UsuariosBE UsuarioRes = new UsuariosBE();
            try
            {

                
                bool bExistUsr = true;
                ////Checamos la existencia del usuario
                ReglasBE ReglasInt = new ReglasBE();
                ReglasInt.USUARIO = Usuario.USUARIO;
                ReglasInt.TIPOBUSQUEDA = 3;
                ReglasInt.IDAPP = Usuario.IDAPLICACION;
                bExistUsr = checkUsr(ReglasInt);
                if (bExistUsr) throw new Exception("El correo para la cuenta ya ha sido utilizado con anterioridad.");

                ////Validamos la existencia de los roles 
                List<RolesBE> RolesXApp = getRolesXApp(Reglas, App);
                bool bFlagExist = false;
                foreach (RolesXUsuarioBE s in RolesXUsuario)
                {
                    bFlagExist = false;
                    foreach (RolesBE RolXApp in RolesXApp)
                    {
                        if (s.IDROL == RolXApp.IDROL)
                        {
                            bFlagExist = true;
                            break;
                        }
                    }
                    if (!bFlagExist) throw new Exception("El rol " + s.IDROL.ToString() + " no pertenece a la aplicación o no existe.");
                }

                ////Obtenemos el numero consecutivo de IDUSARIOAPP y se procede a asignarlo
                bExistUsr = true;
                for (int i = 1; i < 5; i++)
                {
                    Usuario.IDUSUARIOAPP = getUsrIdApp(Usuario.IDAPLICACION);
                    ////Checamos la existencia del usuario
                    ReglasInt.USUARIO = Usuario.IDUSUARIOAPP;
                    ReglasInt.TIPOBUSQUEDA = 2;
                    bExistUsr = checkUsr(ReglasInt);
                    if (!bExistUsr) break;
                }
                if (bExistUsr) throw new Exception("El numero de usuario ya se encuentra asignado, intentelo mas tarde.");
                UsuarioRes = _userServiceDA.addUsuario(Reglas, Usuario, Domicilios, Contactos, RolesXUsuario, App);

                return UsuarioRes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string getUsrIdApp(Int64 IDAPLICACION)
        {
            try
            {
                
                return _userServiceDA.getUsrIdApp(IDAPLICACION);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

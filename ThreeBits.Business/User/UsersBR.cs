using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Data.User;
using ThreeBits.Entities.Common;
using ThreeBits.Entities.User;

namespace ThreeBits.Business.User
{
    public class UsersBR
    {
        public DatosUsuarioBE getUsuarioFull(ReglasBE Reglas, Int64 App)
        {
            DatosUsuarioBE DatosUsuario = new DatosUsuarioBE();
            try
            {
                UsersDA usuarioDA = new UsersDA();
               // DatosUsuario = usuarioDA.GetUsuarioFull(Reglas, App);
                return DatosUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

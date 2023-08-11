using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ThreeBits.Entities.Common;

namespace ThreeBits.Entities.User
{
  
    public class DatosUsuarioBE
    {
        private UsuariosBE oUsuarios;
        public UsuariosBE Usuario
        {
            get { return oUsuarios; }
            set { oUsuarios = value; }

        }

        private List<DomicilioBE> oDomicilios;
        public List<DomicilioBE> Domicilios
        {
            get { return oDomicilios; }
            set { oDomicilios = value; }

        }

        private List<ContactoBE> oContactos;
        public List<ContactoBE> Contactos
        {
            get { return oContactos; }
            set { oContactos = value; }

        }

        private List<RolesXUsuarioBE> oRolesXUsuario;
        public List<RolesXUsuarioBE> RolesXUsuario
        {
            get { return oRolesXUsuario; }
            set { oRolesXUsuario = value; }

        }             
        
       // public List<UsuariosBE> Usuarios = new List<UsuariosBE>();
        
      
        private ReglasBE oReglas;
        public ReglasBE Reglas
        {
            get { return oReglas; }
            set { oReglas = value; }

        }

        private long lApp;
        public long App
        {
            get { return lApp; }
            set { lApp = value; }
        }
        
    }
}

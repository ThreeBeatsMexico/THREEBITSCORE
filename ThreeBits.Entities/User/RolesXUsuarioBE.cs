using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.User
{
    
    public class RolesXUsuarioBE
    {
        private Int64 iIDROLXUSUARIO;
        
        public Int64 IDROLXUSUARIO
        {
            get { return iIDROLXUSUARIO; }
            set { iIDROLXUSUARIO = value; }
        }

        private Int64 iIDROL;
        
        public Int64 IDROL
        {
            get { return iIDROL; }
            set { iIDROL = value; }
        }

        private String sROL;
        
        public String ROL
        {
            get { return sROL; }
            set { sROL = value; }
        }

        private String sDESCROL;
        
        public String DESCROL
        {
            get { return sDESCROL; }
            set { sDESCROL = value; }
        }

        private Int64 iIDUSUARIO;
        
        public Int64 IDUSUARIO
        {
            get { return iIDUSUARIO; }
            set { iIDUSUARIO = value; }
        }

        private Int64 iIDESTACIONXAPP;
        
        public Int64 IDESTACIONXAPP
        {
            get { return iIDESTACIONXAPP; }
            set { iIDESTACIONXAPP = value; }
        }

        private bool bACTIVO;
        
        public bool ACTIVO
        {
            get { return bACTIVO; }
            set { bACTIVO = value; }
        }

        private string sIdAplicacion;
        
        public string IDAPLICACION
        {
            get { return sIdAplicacion; }
            set { sIdAplicacion = value; }
        }

        private string sAplicacion;
        
        public string APLICACION
        {
            get { return sAplicacion; }
            set { sAplicacion = value; }
        }

        
        public string RowIndex { get; set; }
    }
}

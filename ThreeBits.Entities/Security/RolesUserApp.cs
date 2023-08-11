using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.Security
{
    public class RolesUserApp
    {
        private int iIDROL;

        public int IDROL
        {
            get { return iIDROL; }
            set { iIDROL = value; }
        }



        private Int64 iIDUSUARIO;

        public Int64 IDUSUARIO
        {
            get { return iIDUSUARIO; }
            set { iIDUSUARIO = value; }
        }

        private String sDESCRIPCION;

        public String DESCRIPCION
        {
            get { return sDESCRIPCION; }
            set { sDESCRIPCION = value; }
        }



        private bool bACTIVO;

        public bool ACTIVO
        {
            get { return bACTIVO; }
            set { bACTIVO = value; }
        }


    }
}

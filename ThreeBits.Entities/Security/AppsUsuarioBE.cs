using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.Security
{
    public class AppsUsuarioBE
    {
        private Int64 iIDAPLICACION;

        public Int64 IDAPLICACION
        {
            get { return iIDAPLICACION; }
            set { iIDAPLICACION = value; }
        }

        private int iIDROL;

        public int IDROL
        {
            get { return iIDROL; }
            set { iIDROL = value; }
        }


        private String sDESCRIPCION;

        public String DESCRIPCION
        {
            get { return sDESCRIPCION; }
            set { sDESCRIPCION = value; }
        }
    }
}

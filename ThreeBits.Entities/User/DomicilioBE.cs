using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.User
{
   
    public class DomicilioBE
    {
        //Propiedades de Domicilio:
        private Int64 iIDDOMICILIO;
        
        public Int64 IDDOMICILIO
        {
            get { return iIDDOMICILIO; }
            set { iIDDOMICILIO = value; }
        }

        private Int64 iIDUSUARIO;
        
        public Int64 IDUSUARIO
        {
            get { return iIDUSUARIO; }
            set { iIDUSUARIO = value; }
        }

        private String sCALLE;
        
        public String CALLE
        {
            get { return sCALLE; }
            set { sCALLE = value; }
        }

        private String sNUMEXT;
        
        public String NUMEXT
        {
            get { return sNUMEXT; }
            set { sNUMEXT = value; }
        }

        private String sNUMINT;
        
        public String NUMINT
        {
            get { return sNUMINT; }
            set { sNUMINT = value; }
        }

        private string iDESTADO;
        
        public string IDESTADO
        {
            get { return iDESTADO; }
            set { iDESTADO = value; }
        }

        private String sESTADO;
        
        public String ESTADO
        {
            get { return sESTADO; }
            set { sESTADO = value; }
        }

        private string iIDMUNICIPIO;
        
        public string IDMUNICIPIO
        {
            get { return iIDMUNICIPIO; }
            set { iIDMUNICIPIO = value; }
        }

        private string sMUNICIPIO;
        
        public string MUNICIPIO
        {
            get { return sMUNICIPIO; }
            set { sMUNICIPIO = value; }
        }

        private string iIDCOLONIA;
        
        public string IDCOLONIA
        {
            get { return iIDCOLONIA; }
            set { iIDCOLONIA = value; }
        }

        private String sCOLONIA;
        
        public String COLONIA
        {
            get { return sCOLONIA; }
            set { sCOLONIA = value; }
        }

        private String sCP;
        
        public String CP
        {
            get { return sCP; }
            set { sCP = value; }
        }

        private DateTime dtFECHAALTA;
        
        public DateTime FECHAALTA
        {
            get { return dtFECHAALTA; }
            set { dtFECHAALTA = value; }
        }

        private bool bACTIVO;
        
        public bool ACTIVO
        {
            get { return bACTIVO; }
            set { bACTIVO = value; }
        }


        
        public string RowIndex { get; set; }
        
        public bool Actualizado { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.User
{
    
    public class UsuariosBE
    {
        private Int64 iIDUSUARIO;
        
        public Int64 IDUSUARIO
        {
            get { return iIDUSUARIO; }
            set { iIDUSUARIO = value; }
        }

        private Int64 iIDAPLICACION;
        
        public Int64 IDAPLICACION
        {
            get { return iIDAPLICACION; }
            set { iIDAPLICACION = value; }
        }

        private Int32 iIDSEXO;
        
        public Int32 IDSEXO
        {
            get { return iIDSEXO; }
            set { iIDSEXO = value; }
        }

        private Int32 iIDTIPOPERSONA;
        
        public Int32 IDTIPOPERSONA
        {
            get { return iIDTIPOPERSONA; }
            set { iIDTIPOPERSONA = value; }
        }

        private Int32 iIDESTADOCIVIL;
        
        public Int32 IDESTADOCIVIL
        {
            get { return iIDESTADOCIVIL; }
            set { iIDESTADOCIVIL = value; }
        }

        private Int32 iIDAREA;
        
        public Int32 IDAREA
        {
            get { return iIDAREA; }
            set { iIDAREA = value; }
        }

        private String sDESCAREA;
        
        public String DESCAREA
        {
            get { return sDESCAREA; }
            set { sDESCAREA = value; }
        }

        private Int32 iIDTIPOUSUARIO;
        
        public Int32 IDTIPOUSUARIO
        {
            get { return iIDTIPOUSUARIO; }
            set { iIDTIPOUSUARIO = value; }
        }

        private String sDESCTIPOUSUARIO;
        
        public String DESCTIPOUSUARIO
        {
            get { return sDESCTIPOUSUARIO; }
            set { sDESCTIPOUSUARIO = value; }
        }

        private String sIDUSUARIOAPP;
        
        public String IDUSUARIOAPP
        {
            get { return sIDUSUARIOAPP; }
            set { sIDUSUARIOAPP = value; }
        }

        private String sAPATERNO;
        
        public String APATERNO
        {
            get { return sAPATERNO; }
            set { sAPATERNO = value; }
        }

        private String sAMATERNO;
        
        public String AMATERNO
        {
            get { return sAMATERNO; }
            set { sAMATERNO = value; }
        }

        private String sNOMBRE;
        
        public String NOMBRE
        {
            get { return sNOMBRE; }
            set { sNOMBRE = value; }
        }

        private DateTime? dtFECHANACCONST;
        
        public DateTime? FECHANACCONST
        {
            get { return dtFECHANACCONST; }
            set { dtFECHANACCONST = value; }
        }

        private String sUSUARIO;
        
        public String USUARIO
        {
            get { return sUSUARIO; }
            set { sUSUARIO = value; }
        }

        private String sPASSWORD;
        
        public String PASSWORD
        {
            get { return sPASSWORD; }
            set { sPASSWORD = value; }
        }

        private String sRUTAFOTOPERFIL;
        
        public String RUTAFOTOPERFIL
        {
            get { return sRUTAFOTOPERFIL; }
            set { sRUTAFOTOPERFIL = value; }
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ThreeBits.Entities.User
{
   
    public class ContactoBE
    {
        //Propiedades de Domicilio:
        private Int64 iIDCONTACTO;
        
        public Int64 IDCONTACTO
        {
            get { return iIDCONTACTO; }
            set { iIDCONTACTO = value; }
        }

        private Int64 iIDUSUARIO;
        
        public Int64 IDUSUARIO
        {
            get { return iIDUSUARIO; }
            set { iIDUSUARIO = value; }
        }

        private Int32 iIDTIPOCONTACTO;
        
        public Int32 IDTIPOCONTACTO
        {
            get { return iIDTIPOCONTACTO; }
            set { iIDTIPOCONTACTO = value; }
        }

        private string sTIPOCONTACTO;
        
        public string TIPOCONTACTO
        {
            get { return sTIPOCONTACTO; }
            set { sTIPOCONTACTO = value; }
        }


        private String sVALOR;
        
        public String VALOR
        {
            get { return sVALOR; }
            set { sVALOR = value; }
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

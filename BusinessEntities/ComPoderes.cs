using System;
using System.Runtime.InteropServices;
using System.Text;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.BusinessEntities
{
    [Serializable]
    [Guid("7B739F4C-E44B-40C5-9814-A63568657001")]
    
    public class ComPoderes
    {

        private object _ApoSecApoderados;
        [ComMapping("APO_SEC_APODERADOS")]
        public object ApoSecApoderados
        {
            get { return _ApoSecApoderados; }
            set { _ApoSecApoderados = value; }
        }

         private object _ApoPersIdentificador1;
        [ComMapping("APO_PERS_IDENTIFICADOR_1")]
        public object ApoPersIdentificador1
        {
            get { return _ApoPersIdentificador1; }
            set { _ApoPersIdentificador1 = value; }
        }

        private object _ApoPersIdentificador2;
        [ComMapping("APO_PERS_IDENTIFICADOR_2")]
        public object ApoPersIdentificador2
        {
            get { return _ApoPersIdentificador2; }
            set { _ApoPersIdentificador2 = value; }
        }

        private object _ApoCodVinculo;
        [ComMapping("APO_COD_VINCULO")]
        public object ApoCodVinculo
        {
            get { return _ApoCodVinculo; }
            set { _ApoCodVinculo = value; }
        }

         private object _ApoComentarios;
        [ComMapping("APO_COMENTARIOS")]
        public object ApoComentarios
        {
            get { return _ApoComentarios; }
            set { _ApoComentarios = value; }
        }

         private object _ApoFechaPerDesde;
        [ComMapping("APO_FECHA_PER_DESDE")]
        public object ApoFechaPerDesde
        {
            get { return _ApoFechaPerDesde; }
            set { _ApoFechaPerDesde = value; }
        }

        private object _ApoFechaPerHasta;
        [ComMapping("APO_FECHA_PER_HASTA")]
        public object ApoFechaPerHasta
        {
            get { return _ApoFechaPerHasta; }
            set { _ApoFechaPerHasta = value; }
        }

        private object _ApoFechaRenRev;
        [ComMapping("APO_FECHA_REN_REV")]
        public object ApoFechaRenRev
        {
            get { return _ApoFechaRenRev; }
            set { _ApoFechaRenRev = value; }
        }
         
         private object _ApoCodFacultad;
        [ComMapping("APO_COD_FACULTAD")]
        public object ApoCodFacultad
        {
            get { return _ApoCodFacultad; }
            set { _ApoCodFacultad = value; }
        }
    
         private object _ApoSuep;
        [ComMapping("APO_SUEP")]
        public object ApoSuep
        {
            get { return _ApoSuep; }
            set { _ApoSuep = value; }
        }

         private object _ApoCodPoder;
        [ComMapping("APO_COD_PODER")]
        public object ApoCodPoder
        {
            get { return _ApoCodPoder; }
            set { _ApoCodPoder = value; }
        }

        private object _ApoCurTipoCuratela;
        [ComMapping("CUR_TIPO_CURATELA")]
        public object ApoCurTipoCuratela
        {
            get { return _ApoCurTipoCuratela; }
            set { _ApoCurTipoCuratela = value; }
        }

    }
}

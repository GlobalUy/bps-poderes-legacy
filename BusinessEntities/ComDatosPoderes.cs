using System;
using System.Runtime.InteropServices;
using System.Text;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.BusinessEntities
{
    [Serializable]
    [Guid("55A4FECE-3F5E-415D-A7FE-D5BBB51A9D3F")]

    public class ComDatosPoderes
    {

        private string _codPaisEmisorCurador;
        [ComMapping("COD_PAIS_EMISOR_CURADOR")]
        public string CodPaisEmisorCurador
        {
            get { return _codPaisEmisorCurador; }
            set { _codPaisEmisorCurador = value; }
        }

       
        [ComMapping("COD_TIPO_DOCUMENTO_CURADOR")]
        public string CodTipoDocumentoCurador { get; set; }

        [ComMapping("NRO_DOCUMENTO_CURADOR")]
        public string  NroDocumentoCurador { get; set; }

        [ComMapping("PERS_CURADOR")]
        public string PersCurador { get; set; }

        [ComMapping("NOMBRE_CURADOR")]
        public string NombreCurador { get; set; }

        [ComMapping("APELLIDO_CURADOR")]
        public string ApellidoCurador { get; set; }

        [ComMapping("COD_PAIS_EMISOR_INCAPAZ")]
        public string CodPaisEmisorIncapaz { get; set; }

        [ComMapping("COD_TIPO_DOCUMENTO_INCAPAZ")]
        public string CodTipoDocumentoIncapaz { get; set; }

        [ComMapping("NRO_DOCUMENTO_INCAPAZ")]
        public string NroDocumentoIncapaz { get; set; }

        [ComMapping("PERS_INCAPAZ")]
        public string PersIncapaz { get; set; }

        [ComMapping("NOMBRE_INCAPAZ")]
        public string NombreIncapaz { get; set; }

        [ComMapping("APELLIDO_INCAPAZ")]
        public string ApellidoIncapaz { get; set; }

        [ComMapping("COD_PODER")]
        public string CodPoder { get; set; }

        [ComMapping("ESTADO")]
        public string Estado { get; set; }

        [ComMapping("COD_PAIS_EMISOR_APODERADO")]
        public string CodPaisEmisorApoderado { get; set; }

        [ComMapping("COD_TIPO_DOCUMENTO_APODERADO")]
        public string CodTipoDocumentoApoderado { get; set; }

        [ComMapping("NRO_DOCUMENTO_APODERADO")]
        public string NroDocumentoApoderado { get; set; }

        [ComMapping("PERS_APODERADO")]
        public string PersApoderado { get; set; }

        [ComMapping("NOMBRE_APODERADO")]
        public string NombreApoderado { get; set; }

        [ComMapping("APELLIDO_APODERADO")]
        public string ApellidoApoderado { get; set; }

    }
}

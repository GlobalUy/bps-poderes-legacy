using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;


namespace Bull.PRES.Poderes.Facades
{
    [Serializable]
    [Guid("2CF446A9-7D25-406B-BCCF-1149D58E2F2F"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class ResultPoderPersonaControlCant
    {
       

        public ResultPoderPersonaControlCant()
        {
            ErroresNegocio = new List<GestionPoderes.ErrorNegocio>();
        }

        public List<GestionPoderes.ErrorNegocio> ErroresNegocio { get; set; }



        private int _secApoderados;
        [DataMember]
        public int SecApoderados
        {
            get { return _secApoderados; }
            set { _secApoderados = value; }
        }

        private DateTime _fechaVigDesde;
        [DataMember]
        public DateTime FechaVigDesde
        {
            get { return _fechaVigDesde; }
            set { _fechaVigDesde = value; }
        }

        private int _persIdentificador_1;
        [DataMember]
        public int PersIdentificador_1
        {
            get { return _persIdentificador_1; }
            set { _persIdentificador_1 = value; }
        }


        private int _codPoder;
        [DataMember]
        public int CodPoder
        {
            get { return _codPoder; }
            set { _codPoder = value; }
        }


        private string _estado;
        [DataMember]
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private int? _codVinculo;
        [DataMember]
        public int? CodVinculo
        {
            get { return _codVinculo; }
            set { _codVinculo = value; }
        }


        private int? _codFacultad;
        [DataMember]
        public int? CodFacultad
        {
            get { return _codFacultad; }
            set { _codFacultad = value; }
        }

        private string _comentarios;
        [DataMember]
        public string Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }


        private DateTime _fechaPerDesde;
        [DataMember]
        public DateTime FechaPerDesde
        {
            get { return _fechaPerDesde; }
            set { _fechaPerDesde = value; }
        }


        private DateTime? _fechaPerHasta;
        [DataMember]
        public DateTime? FechaPerHasta
        {
            get { return _fechaPerHasta; }
            set { _fechaPerHasta = value; }
        }


        private DateTime? _fechaRenRev;
        [DataMember]
        public DateTime? FechaRenRev
        {
            get { return _fechaRenRev; }
            set { _fechaRenRev = value; }
        }


        private DateTime _fechaVigHasta;
        private List<ApplicationFramework.Services.ErrorNegocio> colErrorNegocio;

        [DataMember]
        public DateTime FechaVigHasta
        {
            get { return _fechaVigHasta; }
            set { _fechaVigHasta = value; }
        }

    }
}
 
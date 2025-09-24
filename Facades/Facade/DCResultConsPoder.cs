using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;

using Bull.Seguridad.BusinessEntity;
using Bull.Comunes.Facades;
using Bull.ApplicationFramework.Diagnostics;
using System.Runtime.Serialization;

namespace Bull.PRES.Poderes.Facades
{
    [Serializable]
    [Guid("B59C12BB-0588-48A7-BB19-6F6A36AB0DA0"), ClassInterface(ClassInterfaceType.AutoDual)]
    [DataContract(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001")]
    public class DCResultConsPoder
    {
        private int? _codFacultad;
        [DataMember]
        public int? CodFacultad
        {
            get { return _codFacultad; }
            set { _codFacultad = value; }
        }


        private string _codPoder;
        [DataMember]
        public string CodPoder
        {
            get { return _codPoder; }
            set { _codPoder = value; }
        }


        private string _descFacultad;
        [DataMember]
        public string DescFacultad
        {
            get { return _descFacultad; }
            set { _descFacultad = value; }
        }


        private string _descTipoPoder;
        [DataMember]
        public string DescTipoPoder
        {
            get { return _descTipoPoder; }
            set { _descTipoPoder = value; }
        }
    }
}

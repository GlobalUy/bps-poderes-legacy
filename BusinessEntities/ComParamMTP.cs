using System;
using System.Runtime.InteropServices;
using System.Text;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.BusinessEntities
{

    [Serializable]
    [Guid("1257445C-28BC-4465-97DA-BA587B292102")]
    public class ComParamMTP
    {


        private object _lineaGen;
        [ComMapping("LINEAGEN")]
        public object LineaGen
        {
            get { return _lineaGen; }
            set { _lineaGen = value; }
        }

        private string _uact;
        [ComMapping("UACT")]
        public string Uact
        {
            get { return _uact; }
            set { _uact = value; }
        }

        private DateTime? _fechaOpera;
        [ComMapping("FECHAOPERA")]
        public DateTime? FechaOpera
        {
            get { return _fechaOpera; }
            set { _fechaOpera = value; }
        }

        private int _debug;
        [ComMapping("DEBUG")]
        public int Debug
        {
            get { return _debug; }
            set { _debug = value; }
        }

    }
}

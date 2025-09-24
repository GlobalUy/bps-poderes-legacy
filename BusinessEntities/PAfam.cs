// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 24/08/2011 12:11:01 p.m.
//
// Development platform was: Bull Guidance Package Version: 1.1.4
//
// ==============================================================================



using System;
using System.Runtime.InteropServices;
using System.Text;
using Bull.ApplicationFramework;

namespace Bull.PRES.Poderes.BusinessEntities
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [Guid("208bb4d1-09cf-41de-afab-20096deb5358")]
    public class PAfam
    {


        private string _comentarios;
        [ComMapping("COMENTARIOS")]
        public string Comentarios
        {
            get { return _comentarios; }
            set { _comentarios = value; }
        }


        private DateTime? _fechaRenovacion;
        [ComMapping("FECHA_RENOVACION")]
        public DateTime? FechaRenovacion
        {
            get { return _fechaRenovacion; }
            set { _fechaRenovacion = value; }
        }


        private DateTime _fechaPerDesde;
        [ComMapping("FECHA_PER_DESDE")]
        public DateTime FechaPerDesde
        {
            get { return _fechaPerDesde; }
            set { _fechaPerDesde = value; }
        }

        private DateTime? _fechaPerHasta;
        [ComMapping("FECHA_PER_HASTA")]
        public DateTime? FechaPerHasta
        {
            get { return _fechaPerHasta; }
            set { _fechaPerHasta = value; }
        }

        private int _zona;
        [ComMapping("ZONA")]
        public int Zona
        {
            get { return _zona; }
            set { _zona = value; }
        }

    }
}


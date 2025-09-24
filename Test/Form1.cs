using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bull.PRES.Poderes.Facades;
using Bull.Seguridad.BusinessEntity;
using Bull.ApplicationFramework.WebServices;

namespace test
{
    public partial class Form1 : Form
    {
        Contexto co = null;
        public Form1()
        {
            InitializeComponent();
            co = new Contexto(0, "0011382", DateTime.Now, 8, int.MinValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////SistemaPoderes sis = new SistemaPoderes();
            ////List<DCResultConsPoder> p = sis.ObtListaPoderes(co, "julio", 1, 12, 16);
            //ServiceFacade sf = new ServiceFacade();
            //ParamObtListaPoderes p = new ParamObtListaPoderes();
            //ContextoWS c = new ContextoWS();

            //c.FechaOpera = co.FechaOpera;
            //c.UsuarioActual = co.UsuarioActual;

            //p.CobroAFAM = "S";
            //p.ContextoWS = c;
            //p.PersIdApoderado = 2884425;
            //p.PersIdPoderdante = 1290347;
            //p.TipoFacultades = 1;
            //var rs = sf.ObtListaPoderes(p);
            
        }
    }
}

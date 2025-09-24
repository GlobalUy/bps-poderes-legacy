using Bull.Seguridad.BusinessEntity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using XmlGridViewSample;

namespace zTest
{
    public partial class Form1 : Form
    {
        public Form1()
        { InitializeComponent(); }

        private Contexto ObtContexto()
        {
            Contexto co = new Contexto("BPSRING", DateTime.Now, 0);
            co.CodViaIngreso = 1;
            if (this.cboDebug.Text.Trim().Length > 0)
            { co.Debug = Convert.ToInt32(this.cboDebug.Text.Trim()); }
            return co;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblInicio.Text = "00:00:00";
                this.lblFin.Text = "00:00:00";
                this.lblTiempoConsumido.Text = "00:00:00";
                InicializoXML();
                this.txtError.Text = "";

                this.lblInicio.Text = DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss");

                Contexto co = ObtContexto();

                object server = null;
                string salidaXML;

                // ********************************************************************************************************************************************
                // CODIGO DE EJEMPLO PARA INVOCAR LA SOLUCION
                // ********************************************************************************************************************************************
                server = Interaction.CreateObject("Bull.PRES.Poderes.Facades.SistemaPoderes", this.cboServidor.Text);
                Bull.PRES.Poderes.Facades.SistemaPoderes root = null;
                root = (Bull.PRES.Poderes.Facades.SistemaPoderes)server;

                //Bull.PRES.Poderes.Facades.Persona retorno = root.ObtContextoPersona(Convert.ToInt32(1234), "", DateTime.Now, co);
                //salidaXML = GetXMLFromObject(retorno);
                //CargoXML(salidaXML);
                // ********************************************************************************************************************************************

                this.lblFin.Text = DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss");

                TimeSpan ts = Convert.ToDateTime(this.lblFin.Text) - Convert.ToDateTime(this.lblInicio.Text);
                this.lblTiempoConsumido.Text = ts.ToString();
            }
            catch (Exception ex)
            {
                CargoError(ex.Message);
                this.lblFin.Text = DateTime.Now.TimeOfDay.ToString("hh\\:mm\\:ss");
                TimeSpan ts = Convert.ToDateTime(this.lblFin.Text) - Convert.ToDateTime(this.lblInicio.Text);
                this.lblTiempoConsumido.Text = ts.ToString();
            }
        }

        private void CargoError(string error)
        { this.txtError.Text = error; }

        private void CargoXML(string valor)
        {
            valor = valor.Substring(39);
            xmlGridView1.Visible = true;
            string[] lines = { valor.Replace("'", "\"") };

            System.IO.File.WriteAllLines(@"C:\test.xml", lines);
            xmlGridView1.DataFilePath = @"C:\test.xml";

            xmlGridView1.DataSetTableIndex = Convert.ToInt32(1);
            xmlGridView1.ViewMode = XmlGridView.VIEW_MODE.XML;
        }

        private void InicializoXML()
        { xmlGridView1.Visible = false; }

        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception)
            { }
            finally
            {
                sw.Close();
                if (tw != null)
                { tw.Close(); }
            }
            return sw.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        { this.Close(); }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
        }
    }
}
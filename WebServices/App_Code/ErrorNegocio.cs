using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ErrorNegocio
/// </summary>
public class ErrorNegocio
{
    public ErrorNegocio()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string _Codigo;

    public string Codigo
    {
        get { return _Codigo; }
        set { _Codigo = value; }
    }
    private string _Descripcion;

    public string Descripcion
    {
        get { return _Descripcion; }
        set { _Descripcion = value; }
    }
    private int _Severidad;

    public int Severidad
    {
        get { return _Severidad; }
        set { _Severidad = value; }
    }
}

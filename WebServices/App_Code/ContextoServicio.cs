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
/// Summary description for ContextoServicio
/// </summary>
public class ContextoServicio
{
    public ContextoServicio()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private string _UsuarioActual;
    public string UsuarioActual
    {
        get { return _UsuarioActual; }
        set { _UsuarioActual = value; }
    }
    
    private int _CodRol;
    public int CodRol
    {
        get { return _CodRol; }
        set { _CodRol = value; }
    }

    private int _CodAgencia;
    public int CodAgencia
    {
        get { return _CodAgencia; }
        set { _CodAgencia = value; }
    }


    private int _CodSistema;
    public int CodSistema
    {
        get { return _CodSistema; }
        set { _CodSistema = value; }
    }
}

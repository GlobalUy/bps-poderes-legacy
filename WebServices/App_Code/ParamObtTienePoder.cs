#region Declaraciones Using
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Bull.Seguridad.BusinessEntity;
using Bull.ApplicationFramework.WebServices;

#endregion 

/// <summary>
/// Summary description for paramObtApoderados
/// </summary>
public class ParamObtTienePoder
{

    #region Constructor
    public ParamObtTienePoder()
    {

    }
    #endregion 

    private int persIdentificadorPoderDante;
    public int PersIdentificadorPoderDante
    {
        get { return persIdentificadorPoderDante; }
        set { persIdentificadorPoderDante = value; }
    }

    private int? persIdentificadorApoderado;
    public int? PersIdentificadorApoderado
    {
        get { return persIdentificadorApoderado; }
        set { persIdentificadorApoderado = value; }
    }

    private int _codGrupo;
    public int CodGrupo
    {
        get { return _codGrupo; }
        set { _codGrupo = value; }
    }


    private ContextoWS ctxWS;
    public ContextoWS CtxWS
    {
        get { return ctxWS; }
        set { ctxWS = value; }
    }
}

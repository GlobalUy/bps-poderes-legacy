#region Declaraciones "using"

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

#endregion

/// <summary>
/// Summary description for ParamObtHabilitacionCobro 
/// </summary>
public class ParamObtHabilitacionCobro 
{
    #region Constructor
    public ParamObtHabilitacionCobro()
    {
        this.Apoderado = new DatoPersona();
        this.Poderdante = new DatoPersona();
    }
    #endregion

    
    private DatoPersona _poderdante;		
    public DatoPersona Poderdante
	{
        get { return _poderdante; }
        set { _poderdante = value; }
	}

    private DatoPersona _apoderado;
    public DatoPersona Apoderado
    {
        get { return _apoderado; }
        set { _apoderado = value; }
    }

    private ContextoServicio _contextoServicio;		
	public ContextoServicio ContextoServicio
	{
		get { return _contextoServicio; }
		set { _contextoServicio = value; }
	}
}

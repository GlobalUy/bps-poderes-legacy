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
/// Summary description for ParamObtHabilitacionCobroSinApo
/// </summary>
public class ParamObtHabilitacionCobroSinApo
{
    public ParamObtHabilitacionCobroSinApo()
    {
        this.Poderdante = new DatoPersona();
    }

   private DatoPersona _poderdante;		
    public DatoPersona Poderdante
	{
        get { return _poderdante; }
        set { _poderdante = value; }
	}

    private ContextoServicio _contextoServicio;		
	public ContextoServicio ContextoServicio
	{
		get { return _contextoServicio; }
		set { _contextoServicio = value; }
	}


}

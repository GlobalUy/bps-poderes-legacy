using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
/// <summary>
/// Summary description for ResultObtHabilitacionCobro
/// </summary>
public class ResultObtHabilitacionCobro
{
    public ResultObtHabilitacionCobro()
    {
        this.ColErrorNegocio = new List<ErrorNegocio>();
    }

    private string _CobroMixto;

    public string CobroMixto
    {
        get { return _CobroMixto; }
        set { _CobroMixto = value; }
    }
    private string _CobroSoloApoderado;

    public string CobroSoloApoderado
    {
        get { return _CobroSoloApoderado; }
        set { _CobroSoloApoderado = value; }
    }
    private string _AutorizaCobroAFAM;

    public string AutorizaCobroAFAM
    {
        get { return _AutorizaCobroAFAM; }
        set { _AutorizaCobroAFAM = value; }
    }
    private List<ErrorNegocio> _ColErrorNegocio;

    public List<ErrorNegocio> ColErrorNegocio
    {
        get { return _ColErrorNegocio; }
        set { _ColErrorNegocio = value; }
    }
		
}

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
/// Summary description for ResultObtHabilitacionCobroSinApo
/// </summary>
public class ResultObtHabilitacionCobroSinApo
{
    public ResultObtHabilitacionCobroSinApo()
    {
        this.ColErrorNegocio = new List<ErrorNegocio>();
    }

    private string _CobroSoloApoderado;

    public string CobroSoloApoderado
    {
        get { return _CobroSoloApoderado; }
        set { _CobroSoloApoderado = value; }
    }
   
    private List<ErrorNegocio> _ColErrorNegocio;

    public List<ErrorNegocio> ColErrorNegocio
    {
        get { return _ColErrorNegocio; }
        set { _ColErrorNegocio = value; }
    }
}

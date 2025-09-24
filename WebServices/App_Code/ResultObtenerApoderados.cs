#region Declaraciones "using"

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

#endregion

/// <summary>
/// Summary description for resultObtenerApoderados
/// </summary>
public class ResultObtListaApoderados
{
    #region Constructor
    public ResultObtListaApoderados()
    {
        _lstApoderado = new List<DatoApoderado>();
    }
    #endregion

    private List<DatoApoderado> _lstApoderado;

    public List<DatoApoderado> ColDatoApoderado
    {
        get { return _lstApoderado; }
        set { _lstApoderado = value; }
    }
}

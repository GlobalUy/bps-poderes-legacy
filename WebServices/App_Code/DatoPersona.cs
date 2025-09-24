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
#endregion 

/// <summary>
/// Summary description for resultPersona
/// </summary>
public class DatoPersona
{
    #region Constructor
    public DatoPersona()
    {

    }
    #endregion 

    private int _CodPaisEmisor;
    public int CodPaisEmisor
    {
        get { return _CodPaisEmisor; }
        set { _CodPaisEmisor = value; }
    }
    private string _TipoDocumento;

    public string TipoDocumento
    {
        get { return _TipoDocumento; }
        set { _TipoDocumento = value; }
    }

    private string _NroDocumento;

    public string NroDocumento
    {
        get { return _NroDocumento; }
        set { _NroDocumento = value; }
    }
    
}

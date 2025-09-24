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
/// Summary description for ResultObtTienePoder
/// </summary>
public class ResultObtTienePoder
{
    public ResultObtTienePoder()
    {
    }
    
    private string _resultado;
    public string Resultado
    {
        get { return _resultado; }
        set { _resultado = value; }
    }
    
}

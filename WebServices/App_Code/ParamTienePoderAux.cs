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


/// <summary>
/// Summary description for ParamTienePoderAux
/// </summary>
public class ParamTienePoderAux
{
    public ParamTienePoderAux()
    {
        //
        // TODO: Add constructor logic here
        //
    }
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


    private Contexto _CO;
    public Contexto CO
    {
        get { return _CO; }
        set { _CO = value; }
    }

}

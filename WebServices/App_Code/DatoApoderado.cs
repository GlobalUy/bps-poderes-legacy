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
/// Summary description for resultApoderado
/// </summary>
public class DatoApoderado
{
    #region Constructor
    public DatoApoderado()
    {
        this.Apoderado = new DatoPersona();
        this.PoderDante = new DatoPersona();
    }
    #endregion

    
    private string _descTipo;		
    public string DescTipo
	{
        get { return _descTipo; }
        set { _descTipo = value; }
	}

    private string _Tipo;
    public string Tipo
    {
        get { return _Tipo; }
        set { _Tipo = value; }
    }

    private int? _codFacultad;		
	public int? CodFacultad
	{
		get { return _codFacultad; }
		set { _codFacultad = value; }
	}


    private string _descFacultad;		
    public string DescFacultad
	{
        get { return _descFacultad; }
        set { _descFacultad = value; }
	}

    private string _afam;
    public string Afam
    {
        get { return _afam; }
        set { _afam = value; }
    }

    private string _instituto;		
    public string Instituto
	{
        get { return _instituto; }
        set { _instituto = value; }
	}		
	
	private DatoPersona _poderDante;
    public DatoPersona PoderDante
    {
        get { return _poderDante; }
        set { _poderDante = value; }
    }

    private DatoPersona _apoderado;
    public DatoPersona Apoderado
    {
        get { return _apoderado; }
        set { _apoderado = value; }
    }


}

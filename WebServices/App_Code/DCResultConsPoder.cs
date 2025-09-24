using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for DCResultConsPoder
/// </summary>

public class DCResultConsPoder
{
    private int? _codFacultad;
    public int? CodFacultad
    {
        get { return _codFacultad; }
        set { _codFacultad = value; }
    }


    private string _codPoder;
    public string CodPoder
    {
        get { return _codPoder; }
        set { _codPoder = value; }
    }


    private string _descFacultad;
    public string DescFacultad
    {
        get { return _descFacultad; }
        set { _descFacultad = value; }
    }


    private string _descTipoPoder;
    public string DescTipoPoder
    {
        get { return _descTipoPoder; }
        set { _descTipoPoder = value; }
    }
}

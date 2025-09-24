// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 24/08/2011 04:35:56 p.m.
//
// Development platform was: Bull Guidance Package 
//
// ==============================================================================

using System;
using Bull.ApplicationFramework.WebServices;

public class ParamObtListaPoderes
{


    private string _cobroAFAM;
    public string CobroAFAM
    {
        get { return _cobroAFAM; }
        set { _cobroAFAM = value; }
    }

    private ContextoWS _contextoWS;
    public ContextoWS ContextoWS
    {
        get { return _contextoWS; }
        set { _contextoWS = value; }
    }

    private int _persIdApoderado;
    public int PersIdApoderado
    {
        get { return _persIdApoderado; }
        set { _persIdApoderado = value; }
    }

    private int _persIdPoderdante;
    public int PersIdPoderdante
    {
        get { return _persIdPoderdante; }
        set { _persIdPoderdante = value; }
    }

    private int _tipoFacultades;
    public int TipoFacultades
    {
        get { return _tipoFacultades; }
        set { _tipoFacultades = value; }
    }
}



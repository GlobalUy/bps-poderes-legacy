// ===============================================================================
// Disclaimer: this class was created by DOMPRES\rrumbo on 24/08/2011 04:35:55 p.m.
//
// Development platform was: Bull Guidance Package 
//
// ==============================================================================

using System;
using System.Collections.Generic;

public class ResultObtListaPoderes
{
    public ResultObtListaPoderes()
    {

    }

    private List<Bull.ApplicationFramework.Services.ErrorNegocio> colErrorNegocio;

    public List<Bull.ApplicationFramework.Services.ErrorNegocio> ColErrorNegocio
    {
        get { return colErrorNegocio; }
        set { colErrorNegocio = value; }
    }

    private List<DCResultConsPoder> colPoderes;
    public List<DCResultConsPoder> ColPoderes
    {
        get { return colPoderes; }
        set { colPoderes = value; }
    }

}



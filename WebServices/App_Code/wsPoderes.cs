#region Declaraciones Using
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Linq;

using Bull.ApplicationFramework.WebServices;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Seguridad.BusinessEntity;
using Bull.PRES.Poderes.Facades;
using System.Collections.Generic;
using Bull.ApplicationFramework.WebServices;

#endregion

//[WebService(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes", Description = "WebService para la publicación de funcionalidades poderes. Responsable de Desarrollo: BULL")]
//[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

[WebServiceBindingAttribute(ConformsTo = System.Web.Services.WsiProfiles.None, EmitConformanceClaims = false)]
[WebServiceAttribute(Name = "wsPoderes", Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes/v001", Description = "WebService para la publicación de funcionalidades poderes. Responsable de Desarrollo: BULL")]
[SoapDocumentServiceAttribute(Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Default)]

public class wsPoderes : System.Web.Services.WebService
{
    #region Constructor
    public wsPoderes()
    {
    }
    #endregion

    #region Privados

    private ResultObtTienePoder ObtTienePoder(ParamTienePoderAux paramTienePoderAux)
    {
        //Contexto contexto = WebServicesProvider.MapContextoWsToContexto(paramObtTienePoder.CtxWS);

        using (ISistemaPoderes sistema = new SistemaPoderes())
        {
            //El Resultado es String(1), S/N
            List<DCApoderado> lstDcApoderado = sistema.ObtApoderados(paramTienePoderAux.PersIdentificadorPoderDante,
                                                                     paramTienePoderAux.PersIdentificadorApoderado,
                                                                     paramTienePoderAux.CodGrupo,
                                                                     paramTienePoderAux.CO);

            ResultObtTienePoder retTienePoder = new ResultObtTienePoder();
            if (lstDcApoderado.Count == 0)
            {
                retTienePoder.Resultado = "N";
            }
            else
            {
                retTienePoder.Resultado = "S";
            }


            return retTienePoder;
        }
    }

    #endregion

    #region Métodos Web

    //[WebMethod(Description = "Método que permite obtener dadas 2 personas, si tienen o no un poder. Responsable de Desarrollo: BULL")]
    [System.Web.Services.WebMethodAttribute()]
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bps.gub.uy/Prestaciones/wsPoderes/ObtHabilitacionCobroSinApo", OneWay = false, Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Default)]
    [return: System.Xml.Serialization.XmlElementAttribute(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes", ElementName = "ResultObtHabilitacionCobroSinApo")]
    public ResultObtHabilitacionCobroSinApo ObtHabilitacionCobroSinApo(ParamObtHabilitacionCobroSinApo ParamObtHabilitacionCobroSinApo)
    {
        Contexto contexto = new Contexto(ParamObtHabilitacionCobroSinApo.ContextoServicio.UsuarioActual, DateTime.Now, 0);
        ResultObtHabilitacionCobroSinApo result = new ResultObtHabilitacionCobroSinApo();

        //Llamar a fachada de persona para obterner los persId de la personas
        DCPersona poderdante = new DCPersona();
        using (ISistemaPoderes sistema = new SistemaPoderes())
        {
            //Llamada para el PoderDante
            poderdante = sistema.ObtDatosPersonaPorDocumento(ParamObtHabilitacionCobroSinApo.Poderdante.CodPaisEmisor,
                                                            ParamObtHabilitacionCobroSinApo.Poderdante.TipoDocumento,
                                                            ParamObtHabilitacionCobroSinApo.Poderdante.NroDocumento,
                                                            contexto);
        }

        //Cargo los errores en caso de que alguno de los doc NO exista
        ErrorNegocio err = null;
        if (poderdante.PersIdentificador == int.MinValue)
        {
            err = new ErrorNegocio();
            err.Codigo = "1701";
            err.Descripcion = "Poderdante: Persona inexistente";
            err.Severidad = 1;
            result.ColErrorNegocio.Add(err);
        }

        //Invocar al WS de poderes para los grupos 1, 2, 3
        if (result.ColErrorNegocio.Count == 0)
        {
            ContextoWS coWS = new ContextoWS();
            ParamTienePoderAux param = new ParamTienePoderAux();
            param.PersIdentificadorApoderado = null;
            param.PersIdentificadorPoderDante = poderdante.PersIdentificador;
            param.CodGrupo = 2;
            param.CO = contexto;
            result.CobroSoloApoderado = this.ObtTienePoder(param).Resultado;
            return result;
        }
        else
            return result;
    }



    //[WebMethod(Description = "Método que permite obtener dada una persona, si tiene poder o no. Responsable de Desarrollo: BULL",MessageName = "Retorno")]

    [System.Web.Services.WebMethodAttribute()]
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bps.gub.uy/Prestaciones/wsPoderes/ObtHabilitacionCobro", OneWay = false, Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Default)]
    [return: System.Xml.Serialization.XmlElementAttribute(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes", ElementName = "ResultObtHabilitacionCobro")]
    public ResultObtHabilitacionCobro ObtHabilitacionCobro(ParamObtHabilitacionCobro ParamObtHabilitacionCobro)
    {
        Contexto contexto = new Contexto(ParamObtHabilitacionCobro.ContextoServicio.UsuarioActual, DateTime.Now, 0);
        ResultObtHabilitacionCobro ResultObtHabilitacionCobro = new ResultObtHabilitacionCobro();

        //Llamar a fachada de persona para obterner los persId de la personas
        DCPersona apoderado = new DCPersona();
        DCPersona poderdante = new DCPersona();
        using (ISistemaPoderes sistema = new SistemaPoderes())
        {
            //Llamada para el Apoderado
            apoderado = sistema.ObtDatosPersonaPorDocumento(ParamObtHabilitacionCobro.Apoderado.CodPaisEmisor,
                                                            ParamObtHabilitacionCobro.Apoderado.TipoDocumento,
                                                            ParamObtHabilitacionCobro.Apoderado.NroDocumento,
                                                            contexto);
            //Llamada para el PoderDante
            poderdante = sistema.ObtDatosPersonaPorDocumento(ParamObtHabilitacionCobro.Poderdante.CodPaisEmisor,
                                                            ParamObtHabilitacionCobro.Poderdante.TipoDocumento,
                                                            ParamObtHabilitacionCobro.Poderdante.NroDocumento,
                                                            contexto);
        }

        //Cargo los errores en caso de que alguno de los doc NO exista
        ErrorNegocio err = null;
        if (poderdante.PersIdentificador == int.MinValue)
        {
            err = new ErrorNegocio();
            err.Codigo = "1701";
            err.Descripcion = "Poderdante: Persona inexistente";
            err.Severidad = 1;
            ResultObtHabilitacionCobro.ColErrorNegocio.Add(err);
        }

        if (apoderado.PersIdentificador == int.MinValue)
        {
            err = new ErrorNegocio();
            err.Codigo = "1701";
            err.Descripcion = "Apoderado: Persona inexistente";
            err.Severidad = 1;
            ResultObtHabilitacionCobro.ColErrorNegocio.Add(err);
        }


        //Invocar al WS de poderes para los grupos 1, 2, 3
        if (ResultObtHabilitacionCobro.ColErrorNegocio.Count == 0)
        {
            ContextoWS coWS = new ContextoWS();
            ParamTienePoderAux param = new ParamTienePoderAux();
            param.PersIdentificadorApoderado = apoderado.PersIdentificador;
            param.PersIdentificadorPoderDante = poderdante.PersIdentificador;
            param.CodGrupo = 1;
            param.CO = contexto;
            ResultObtHabilitacionCobro.CobroMixto = this.ObtTienePoder(param).Resultado;

            param = new ParamTienePoderAux();
            param.PersIdentificadorApoderado = apoderado.PersIdentificador;
            param.PersIdentificadorPoderDante = poderdante.PersIdentificador;
            param.CodGrupo = 2;
            param.CO = contexto;
            ResultObtHabilitacionCobro.CobroSoloApoderado = this.ObtTienePoder(param).Resultado;

            param = new ParamTienePoderAux();
            param.PersIdentificadorApoderado = apoderado.PersIdentificador;
            param.PersIdentificadorPoderDante = poderdante.PersIdentificador;
            param.CodGrupo = 3;
            param.CO = contexto;
            ResultObtHabilitacionCobro.AutorizaCobroAFAM = this.ObtTienePoder(param).Resultado;

            return ResultObtHabilitacionCobro;
        }
        else
            return ResultObtHabilitacionCobro;
    }
    #endregion


    [WebMethod(Description = "Método que permite obtener los apoderados por Grupo. Responsable de Desarrollo: BULL")]
    public ResultObtTienePoder ObtTienePoder(ParamObtTienePoder paramObtTienePoder)
    {
        Contexto contexto = WebServicesProvider.MapContextoWsToContexto(paramObtTienePoder.CtxWS);

        using (ISistemaPoderes sistema = new SistemaPoderes())
        {
            //El Resultado es String(1), S/N
            List<DCApoderado> lstDcApoderado = sistema.ObtApoderados(paramObtTienePoder.PersIdentificadorPoderDante,
                                                                     paramObtTienePoder.PersIdentificadorApoderado,
                                                                     paramObtTienePoder.CodGrupo,
                                                                     contexto);

            ResultObtTienePoder retTienePoder = new ResultObtTienePoder();
            if (lstDcApoderado.Count == 0)
            {
                retTienePoder.Resultado = "N";
            }
            else
            {
                retTienePoder.Resultado = "S";
            }


            return retTienePoder;
        }
    }

    //[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bps.gub.uy/Prestaciones/wsPoderes/ObtListaPoderes", OneWay = false, Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Default)]
    //[return: System.Xml.Serialization.XmlElementAttribute(Namespace = "http://bps.gub.uy/Prestaciones/wsPoderes", ElementName = "ResultObtListaPoderes")]
    [WebMethod(Description = "Método que permite obtener la lista de Poderes de la persona. Responsable de Desarrollo: BULL")]
    public ResultObtListaPoderes ObtListaPoderes(ParamObtListaPoderes paramObtListaPoderes)
    {
        if  (paramObtListaPoderes.ContextoWS.FechaOpera < Convert.ToDateTime ("01/01/1900"))
        {
            throw new System.ArgumentException("El valor de la fecha de operacion no es valido", "paramObtListaPoderes.ContextoWS.FechaOpera");
        }
       
        Contexto contexto = WebServicesProvider.MapContextoWsToContexto(paramObtListaPoderes.ContextoWS);

        ResultObtListaPoderes result = new ResultObtListaPoderes();
        result.ColErrorNegocio = new List<Bull.ApplicationFramework.Services.ErrorNegocio>();
        //Crear los objetos personas para opoderado y poderdante
        //Valilos datos de entrada del WS.

        Bull.ApplicationFramework.Services.ErrorNegocio err = null;
        DCPersona apoderado;
        DCPersona poderdante;

        using (ISistemaPoderes sistema = new SistemaPoderes())
        {
            //Validacion del PersIdApoderado
            apoderado = sistema.ObtDatosPersonaPorPersID(paramObtListaPoderes.PersIdApoderado, contexto);
            //Validacion del PersIDPoderdante
            poderdante = sistema.ObtDatosPersonaPorPersID(paramObtListaPoderes.PersIdPoderdante, contexto);
        }

        //Cargo los errores en caso de que alguno de los doc NO exista
        if (poderdante.PersIdentificador == int.MinValue)
        {
            err = new Bull.ApplicationFramework.Services.ErrorNegocio();
            err.Codigo = "1701";
            err.Descripcion = "Poderdante: Persona inexistente";
            err.Severidad = 1;
            result.ColErrorNegocio.Add(err);
        }

        if (apoderado.PersIdentificador == int.MinValue)
        {
            err = new Bull.ApplicationFramework.Services.ErrorNegocio();
            err.Codigo = "1701";
            err.Descripcion = "Apoderado: Persona inexistente";
            err.Severidad = 1;
            result.ColErrorNegocio.Add(err);
        }

        if (!((paramObtListaPoderes.TipoFacultades == 1) || (paramObtListaPoderes.TipoFacultades == 2) ||
                (paramObtListaPoderes.TipoFacultades == 3) || (paramObtListaPoderes.TipoFacultades == 4)))
        {
            err = new Bull.ApplicationFramework.Services.ErrorNegocio();
            err.Codigo = "1702";
            err.Descripcion = "EL valor del parametro tipoFacultades puede ser 1(Cobro), 2(Tramite), 3(Prestamo), 4(Todos) .";
            err.Severidad = 1;
            result.ColErrorNegocio.Add(err);
        }

        if (!(paramObtListaPoderes.CobroAFAM.Equals("S") || paramObtListaPoderes.CobroAFAM.Equals("N")))
        {
            err = new Bull.ApplicationFramework.Services.ErrorNegocio();
            err.Codigo = "1703";
            err.Descripcion = "EL valor del parámetro cobroAFAM no puede ser nulo y debe ser S o N.";
            err.Severidad = 1;
            result.ColErrorNegocio.Add(err);
        }

        if (result.ColErrorNegocio.Count == 0)
        {
            using (SistemaPoderes sistema = new SistemaPoderes())
            {
                var ret = sistema.ObtListaPoderes(paramObtListaPoderes.CobroAFAM, paramObtListaPoderes.TipoFacultades, paramObtListaPoderes.PersIdApoderado, paramObtListaPoderes.PersIdPoderdante, contexto);

                result.ColPoderes = ret.Select(i => new DCResultConsPoder()
                                        {
                                            CodFacultad = i.CodFacultad,
                                            DescFacultad = i.DescFacultad,
                                            CodPoder = i.CodPoder,
                                            DescTipoPoder = i.DescTipoPoder
                                        }).ToList();

            }
        }


        return result;
    }
}

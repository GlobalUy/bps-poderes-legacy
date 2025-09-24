// ===============================================================================
// Disclaimer: this class was created by DOMPRES\iotegui on 14/08/2008 09:51:37 a.m.
//
// Development platform was: Bull Guidance Package Version: 1.0.19
//
// ==============================================================================
#region Declaraciones Using
using System;
using System.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Text;

using Bull.ApplicationFramework;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Comunes.BusinessLogic;
using Bull.Seguridad.BusinessEntity;
using Bull.PRES.Comunes.BusinessEntity;
using Bull.PRES.Comunes.Facades;
using System.Collections.Generic;
using Bull.PRES.Poderes.BusinessEntities;

#endregion

namespace Bull.PRES.Poderes.ServiceAgents
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true), JustInTimeActivation(true)]
    [Guid("48df25b9-3000-4062-8530-305e23fb0a06"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class SAPoderes : BusinessLogicAbstract
    {

        public SAPoderes()
        { }

        #region ObtParamBenef
        /// <summary>
        /// Metodo encargado de cargar los parametros generales para el beneficio que se lo solicite.-
        /// </summary>
        /// <param name="beneficio">Codigo de beneficio</param>
        /// <param name="tipoSolicitud">Tipo de solicitud</param>
        /// <param name="co"></param>
        /// <returns>la estructura del tipo ParamBenef</returns>
        [AutoComplete]
        public ParamBenef ObtParamBenef(int beneficio, int tipoSolicitud, Contexto co)
        {
            using (new Tracer(new object[] { beneficio, tipoSolicitud }, co))
            {
                using (Bull.PRES.Comunes.Facades.Facade facade = new Bull.PRES.Comunes.Facades.Facade())
                {
                    List<ParamBenf> listParametrosBeneficio = facade.ObtParametrosGrales(beneficio, co.Funcion, co.Modulo, co.Paquete, null, co.Sistema, co.SubSistema, tipoSolicitud, 0, "", "", "", "", co);

                    ParamBenef paramBenef = new ParamBenef();
                    paramBenef.Parametros = listParametrosBeneficio;

                    return paramBenef;
                }
            }
        }
        #endregion

        #region INC.70197
        //Se cambia la invocación a Personas, se deja de llamar directamente a la fachada para invocar al servicio expuesto en el MSE.
        #region ObtenerPersonaPorDocumento
        [AutoComplete]
        public Bull.PRES.Poderes.BusinessEntities.Persona ObtenerPersonaPorDocumento(int codPaisEmisor, string codTipoDocumento, string nroDocumento, Contexto co)
        {
            using (new Tracer(new object[] { codPaisEmisor, codTipoDocumento, nroDocumento }, co))
            {
                using (RCOR.Persona.Facades.IExternalFacade facade = new RCOR.Persona.Facades.Facades())
                {
                    //RCOR.Persona.Facades.RetConsExistePers personaRCOR = new Bull.RCOR.Persona.Facades.RetConsExistePers();

                    //personaRCOR = facade.ExistePersIdentificador(null, codPaisEmisor, codTipoDocumento, nroDocumento, co);

                    //Bull.PRES.Poderes.BusinessEntities.Persona per = new Bull.PRES.Poderes.BusinessEntities.Persona();
                    //if (personaRCOR.PersIdentificador != null)
                    //    per.PersIdentificador = (int)personaRCOR.PersIdentificador;
                    //else
                    //    per.PersIdentificador = int.MinValue;
                    //return per;
                    Bull.PRES.Poderes.BusinessEntities.Persona per;
                    wsPersonas.wsPersonasChannel ws = Bull.ApplicationFramework.Services.Utils.GetWcfClient<wsPersonas.wsPersonasChannel>();

                    try
                    {
                        wsPersonas.obtPersonaPorDocumentoResponse resObtPersonaPorDoc = null;

                        wsPersonas.obtPersonaPorDocumentoRequest param = new wsPersonas.obtPersonaPorDocumentoRequest();

                        param.paramObtPersonaPorDocumento = new wsPersonas.ParamObtPersonaPorDocumento();
                        param.paramObtPersonaPorDocumento.CodPaisEmisor = codPaisEmisor;
                        param.paramObtPersonaPorDocumento.TipoDocumento = codTipoDocumento;
                        param.paramObtPersonaPorDocumento.NroDocumento = nroDocumento;

                        resObtPersonaPorDoc = ws.obtPersonaPorDocumento(param);

                        per = new Bull.PRES.Poderes.BusinessEntities.Persona();
                        if (resObtPersonaPorDoc.obtPersonaPorDocumentoResult.ObjPersona.PersIdentificador != int.MinValue)
                            per.PersIdentificador = resObtPersonaPorDoc.obtPersonaPorDocumentoResult.ObjPersona.PersIdentificador;
                        else
                            per.PersIdentificador = int.MinValue;

                        ws.Close();

                        return per;

                    }
                    catch (Exception exception)
                    {
                        ws.Abort();

                        ApplicationException exception2;
                        if (exception.InnerException != null)
                        {
                            exception2 = new ApplicationException(exception.InnerException.Message);
                        }
                        else
                        {
                            exception2 = new ApplicationException(exception.Message);
                        }
                        throw exception2;
                    }

                }
            }
        }
        #endregion

        #region ObtDatosPersonaPorPersID
        [AutoComplete]
        public Bull.PRES.Poderes.BusinessEntities.Persona ObtDatosPersonaPorPersID(int persId, Contexto co)
        {
            using (new Tracer(new object[] { persId }, co))
            {
                //using (RCOR.Persona.Facades.IExternalFacade facade = new RCOR.Persona.Facades.Facades())
                //{

                //    RCOR.Persona.Facades.RetConsExistePers personaRCOR = new Bull.RCOR.Persona.Facades.RetConsExistePers();

                //    personaRCOR = facade.ExistePersIdentificador(persId, null, null, null, co);

                //    Bull.PRES.Poderes.BusinessEntities.Persona per = new Bull.PRES.Poderes.BusinessEntities.Persona();
                //    if (personaRCOR.PersIdentificador != null)
                //        per.PersIdentificador = (int)personaRCOR.PersIdentificador;
                //    else
                //        per.PersIdentificador = int.MinValue;

                //    return per;
                //}

                wsPersonas.wsPersonasChannel ws = Bull.ApplicationFramework.Services.Utils.GetWcfClient<wsPersonas.wsPersonasChannel>();
                try
                {
                    wsPersonas.obtPersonaPorPersIdResponse resObtPersonaPorId = null;

                    wsPersonas.obtPersonaPorPersIdRequest param = new wsPersonas.obtPersonaPorPersIdRequest();

                    param.paramObtPersonaPorPersId = new wsPersonas.ParamObtPersonaPorPersId();
                    param.paramObtPersonaPorPersId.PersId = persId;

                    resObtPersonaPorId = ws.obtPersonaPorPersId(param);

                    Bull.PRES.Poderes.BusinessEntities.Persona per = new Bull.PRES.Poderes.BusinessEntities.Persona();
                    if (resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.PersIdentificador != int.MinValue)
                        per.PersIdentificador = resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.PersIdentificador;
                    else
                        per.PersIdentificador = int.MinValue;



                    ws.Close();
                    return per;

                }
                catch (Exception exception)
                {
                    ws.Abort();

                    ApplicationException exception2;
                    if (exception.InnerException != null)
                    {
                        exception2 = new ApplicationException(exception.InnerException.Message);
                    }
                    else
                    {
                        exception2 = new ApplicationException(exception.Message);
                    }
                    throw exception2;
                }
            }

        }
        #endregion

        /// <summary>
        /// Autor: Martin De los Reyes
        /// Fecha: 23/07/2014
        /// Desc.: Funcion que obtiene los datos de la persona, segun su persIdentificador
        /// RFC 844
        /// </summary>
        [AutoComplete]
        public Bull.PRES.Poderes.BusinessEntities.PoderPersona ObtDatosPersonaPorPersID(PoderPersona poderPersona, Contexto co)
        {
            using (new Tracer(new object[] { poderPersona }, co))
            {
                wsPersonas.wsPersonasChannel ws = Bull.ApplicationFramework.Services.Utils.GetWcfClient<wsPersonas.wsPersonasChannel>();
                try
                {
                    Bull.PRES.Poderes.BusinessEntities.PoderPersona retorno = new PoderPersona();

                    wsPersonas.obtPersonaPorPersIdResponse resObtPersonaPorId = null;

                    wsPersonas.obtPersonaPorPersIdRequest param = new wsPersonas.obtPersonaPorPersIdRequest();

                    param.paramObtPersonaPorPersId = new wsPersonas.ParamObtPersonaPorPersId();
                    param.paramObtPersonaPorPersId.PersId = poderPersona.PersIdentificador;

                    resObtPersonaPorId = ws.obtPersonaPorPersId(param);

                    if (resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.PersIdentificador != int.MinValue)
                    {
                        retorno.PersIdentificador = resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.PersIdentificador;
                        retorno.CodPaisEmisor = resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.CodPaisEmisor;
                        retorno.CodTipoDocumento = resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.CodTipoDocumento;
                        retorno.NroDocumento = resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.NroDocumento;
                        retorno.Nombre1 = resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.Nombre1;
                        retorno.Nombre2 = resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.Nombre2;
                        retorno.Apellido1 = resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.Apellido1;
                        retorno.Apellido2 = resObtPersonaPorId.obtPersonaPorPersIdResult.ObjPersona.Apellido2;
                        retorno.FechaPerDesde = poderPersona.FechaPerDesde;
                        retorno.FechaPerHasta = poderPersona.FechaPerHasta;
                        retorno.CodPoder = poderPersona.CodPoder;
                        retorno.DescPoder = poderPersona.DescPoder;
                        retorno.CodFacultad = poderPersona.CodFacultad;
                        retorno.DescFacultad = poderPersona.DescFacultad;
                        retorno.PersIdentificador_1 = poderPersona.PersIdentificador_1;
                    }

                    ws.Close();

                    return retorno;

                }
                catch (Exception exception)
                {
                    ws.Abort();

                    ApplicationException exception2;
                    if (exception.InnerException != null)
                    {
                        exception2 = new ApplicationException(exception.InnerException.Message);
                    }
                    else
                    {
                        exception2 = new ApplicationException(exception.Message);
                    }
                    throw exception2;
                }
            }

        }

        #endregion

        [AutoComplete]
        public bool ExisteUsuario(string uact, Contexto co)
        {
            using (new Tracer(new object[] { uact }, co))
            {
                try
                {
                    bool existeUsuario = false;

                    List<SeguridadCorporativa.BusinessEntity.Usuario> usuarios = new List<SeguridadCorporativa.BusinessEntity.Usuario>();

                    using (SeguridadCorporativa.Facades.BusinessFacade facSeg = new SeguridadCorporativa.Facades.BusinessFacade())
                    {
                        usuarios = facSeg.ObtUsuarios(uact, co);
                    }

                    existeUsuario = usuarios.Count > 0 && usuarios.Exists(u => !u.FechaBaja.HasValue);

                    return existeUsuario;
                }
                catch (System.ApplicationException ex)
                {
                    Utils.HandleException(ex, co);
                    throw;
                }
            }
        }

        [AutoComplete]
        public BusinessEntities.Persona ObtenerDatosPersonaPorPersID(int persIdentificador, Contexto co)
        {
            using (new Tracer(new object[] { persIdentificador }, co))
            {                
                BusinessEntities.Persona persona = new BusinessEntities.Persona();

                using (Bull.RCOR.Persona.Facades.IExternalFacade facade = new Bull.RCOR.Persona.Facades.Facades())
                {
                    Bull.RCOR.Persona.Facades.PersonaCons personaRCOR = new Bull.RCOR.Persona.Facades.PersonaCons();

                    personaRCOR = facade.ObtPersonaPorDocumento(persIdentificador, null, "", "", co);
                    persona.PersIdentificador = persIdentificador;

                    if (personaRCOR.FallecimientoCons != null)
                    {
                        persona.FechaFallecimiento = personaRCOR.FallecimientoCons.FechaFallecimiento; 
                    }
                    
                    return persona;
                }
            }
        }
    }
}
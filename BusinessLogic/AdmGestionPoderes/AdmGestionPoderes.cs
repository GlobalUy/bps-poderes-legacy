// ===============================================================================
// Disclaimer: this class was created by DOMPRES\Jomautone on 17/04/2020 02:42:32 p.m.
//
// Development platform was: Bull Guidance Package Version: 1.1.8
//
// ==============================================================================


using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Seguridad.BusinessEntity;
using System.Collections.Generic;

using Bull.ApplicationFramework;
using Bull.Comunes.BusinessLogic;
using Bull.PRES.Poderes.BusinessEntities;
using Bull.PRES.Poderes.Mappers;

namespace Bull.PRES.Poderes.BusinessLogic
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true)]
    [Guid("fa87b047-2ee3-46f6-b02e-e235610d0117"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class AdmGestionPoderes : BusinessLogicAbstract
    {
        [AutoComplete]
        public BusinessEntities.ResultIngresarPoder IngresarPoder(int codFacultad, int codPoder, int codVinculo, string comentarios, string estado, DateTime fechaPerDesde, DateTime? fechaPerHasta, string origen, int persIdApoderado, int persIdPoderdante, bool suep, int tipoCuratela, string uact, Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, codVinculo, comentarios, estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact }, co))
            {
                fechaPerDesde = fechaPerDesde.Date;
                fechaPerHasta = fechaPerHasta.HasValue ? fechaPerHasta.Value.Date : (DateTime?)null;
                BusinessEntities.ResultIngresarPoder resultIngresarPoder = new BusinessEntities.ResultIngresarPoder();
                resultIngresarPoder.ErroresNegocio = this.ValidarDatosEntrada(codFacultad, codPoder, codVinculo, comentarios, ref estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact, co);
                resultIngresarPoder.ErroresNegocio = this.ValidarNegocio(codFacultad, codPoder, codVinculo, comentarios, estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact, resultIngresarPoder.ErroresNegocio, co);
              

                if (resultIngresarPoder.ErroresNegocio.Count == 0)
                {
                    resultIngresarPoder = this.GrabarPoder(codFacultad, codPoder, codVinculo, comentarios, estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact, co);
                }

                return resultIngresarPoder;
            }
        }

        [AutoComplete]
        public BusinessEntities.ResultIngresarPoder GrabarPoder(int codFacultad, int codPoder, int codVinculo, string comentarios, string estado, DateTime fechaPerDesde, DateTime? fechaPerHasta, string origen, int persIdApoderado, int persIdPoderdante, bool suep, int tipoCuratela, string uact, Seguridad.BusinessEntity.Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, codVinculo, comentarios, estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact }, co))
            {
                BusinessEntities.ResultIngresarPoder ingresarPoder = new BusinessEntities.ResultIngresarPoder();

                using (Adapters.AdapterVb6 vb6 = new Adapters.AdapterVb6())
                {
                    ingresarPoder = vb6.fnarr2GrabarPoder(codFacultad, codPoder, codVinculo, comentarios, estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact, co);
                }

                return ingresarPoder;
            }
        }

        [AutoComplete]
        public List<BusinessEntities.ErrorNegocio> ValidarNegocio(int codFacultad, int codPoder, int codVinculo, string comentarios, string estado, DateTime fechaPerDesde, DateTime? fechaPerHasta, string origen, int persIdApoderado, int persIdPoderdante, bool suep, int tipoCuratela, string uact, List<BusinessEntities.ErrorNegocio> errores, Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, codVinculo, comentarios, estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact, errores }, co))
            {
                List<BusinessEntities.ErrorNegocio> erroresNegocio = null;
                using (Adapters.AdapterVb6 vb6 = new Adapters.AdapterVb6())
                {
                    erroresNegocio = vb6.flngValidarPreGrabar(codFacultad, codPoder, codVinculo, comentarios, estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact, co);
                }
                 
                if (erroresNegocio != null && erroresNegocio.Count > 0)
                {
                    erroresNegocio = erroresNegocio.ConvertAll(err => err = this.ObtenerErrorNegocio(err.Codigo, co));
                    errores.AddRange(erroresNegocio);
                }

                return errores;
            }
        }
        [AutoComplete]
        public List<BusinessEntities.PoderPersonaControlCant> ValidarCantPoderesExt(int codFacultad, int codPoder,  string estado, string origen, int persIdApoderado, Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, estado, origen, persIdApoderado }, co))
            {
                
                #region Obtencion ParamGral.  Facultades - Estados - CantPoderesValidos  
                ParametrosGenerales paramGral = this.ObtenerParametroGeneral(Constantes.PARAM_GRAL_PODERES_EXT_COD_FACULT_VALID, co);
                List<string> listCodigosFacultad = new List<string>(paramGral.Valor.ToString().Replace("(", "").Replace(")", "").Split(','));


                ParametrosGenerales paramGralEstados = this.ObtenerParametroGeneral(Constantes.PARAM_GRAL_PODERES_EXT_ESTADOS_VALIDADOR, co);
                List<string> listEstadosValidos = new List<string>(paramGralEstados.Valor.ToString().Replace("(", "").Replace(")", "").Split(','));

                ParametrosGenerales paramGralCantPoderes = this.ObtenerParametroGeneral(Constantes.PARAM_GRAL_PODERES_EXT_CANT_VALIDOS, co);
                int catPoderesExtValidos = Convert.ToInt32(paramGralCantPoderes.Valor.ToString());
                #endregion

                return controlCantPoderesAlta( codFacultad,  codPoder,  estado,  origen,  persIdApoderado,listEstadosValidos, listCodigosFacultad,   catPoderesExtValidos,  co); 
            }
        }

        [AutoComplete]
        public List<BusinessEntities.PoderPersonaControlCant> ValidarCantPoderesEspeciales(string secApoderado, int codFacultad, int codPoder, string estado, int codVinculo, int persIdApoderado, bool esModificacion, Contexto co)
        {
            using (new Tracer(new object[] { secApoderado, codFacultad, codPoder, estado, codVinculo, persIdApoderado, esModificacion }, co))
            {

                ParametrosGenerales paramGralCantPoderes = this.ObtenerParametroGeneral(Constantes.PARAM_GRAL_PODERES_MAX_CANT_ESPECIALES, co);
                int maxCantPoderesEspeciales = Convert.ToInt32(paramGralCantPoderes.Valor.ToString());

                ParametrosGenerales paramGralTipos = this.ObtenerParametroGeneral(Constantes.PARAM_GRAL_PODERES_TIPOS_VALIDOS_ESPECIALES, co);
                List<string> listaTiposValidos = new List<string>(paramGralTipos.Valor.ToString().Replace("(", "").Replace(")", "").Split(','));

                ParametrosGenerales paramGralFacultad = this.ObtenerParametroGeneral(Constantes.PARAM_GRAL_PODERES_FACULTAD_VALIDAS_ESPECIALES, co);
                List<string> listaFacultadesValidas = new List<string>(paramGralFacultad.Valor.ToString().Replace("(", "").Replace(")", "").Split(','));

                ParametrosGenerales paramGralEstados = this.ObtenerParametroGeneral(Constantes.PARAM_GRAL_PODERES_ESTADOS_VALIDOS_ESPECIALES, co);
                List<string> listaEstadosValidos = new List<string>(paramGralEstados.Valor.ToString().Replace("(", "").Replace(")", "").Split(','));

                return controlCantPoderesEspeciales(secApoderado, codFacultad, codPoder, estado, esModificacion, codVinculo, persIdApoderado, listaTiposValidos, listaEstadosValidos, listaFacultadesValidas, maxCantPoderesEspeciales, co);
            }
        }

        [AutoComplete]
        public List<PoderPersonaControlCant> ValidarCantPoderesExtModif(int codFacultad, int codPoder, string estado, string origen, int persIdApoderado, int codFacultadAnt, int codPoderAnt, string estadoAnt, Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, estado, origen, persIdApoderado, codFacultadAnt, codPoderAnt, estadoAnt }, co))
            {
                #region Declaraciones
               
                List<PoderPersonaControlCant> listPoderesApoderado = new List<PoderPersonaControlCant>();
                List<BusinessEntities.ErrorNegocio> erroresCantPoderes = new List<BusinessEntities.ErrorNegocio>();
                BusinessEntities.ErrorNegocio error = new BusinessEntities.ErrorNegocio();
                #endregion

                #region Obtencion ParamGral.  Facultades - Estados - CantPoderesValidos  
                ParametrosGenerales paramGral = this.ObtenerParametroGeneral(Constantes.PARAM_GRAL_PODERES_EXT_COD_FACULT_VALID, co);
                List<string> listCodigosFacultad = new List<string>(paramGral.Valor.ToString().Replace("(", "").Replace(")", "").Split(','));


                ParametrosGenerales paramGralEstados = this.ObtenerParametroGeneral(Constantes.PARAM_GRAL_PODERES_EXT_ESTADOS_VALIDADOR, co);
                List<string> listEstadosValidos = new List<string>(paramGralEstados.Valor.ToString().Replace("(", "").Replace(")", "").Split(','));

                ParametrosGenerales paramGralCantPoderes = this.ObtenerParametroGeneral(Constantes.PARAM_GRAL_PODERES_EXT_CANT_VALIDOS, co);
                int catPoderesExtValidos = Convert.ToInt32(paramGralCantPoderes.Valor.ToString());
                #endregion


                if (listCodigosFacultad.Contains(codFacultad.ToString()))
                {
                    if (codPoder == Convert.ToInt32(Constantes.COD_PODER_EXTERNO))
                    {
                        int cantPoderesExt = 0;
                        using (MapPoderes mapPoderes = new MapPoderes())
                        {
                            listPoderesApoderado = mapPoderes.MapObtenerPoderesApoderado(persIdApoderado, Convert.ToInt32(Constantes.COD_PODER_EXTERNO), null, null, null, co);
                            if (listPoderesApoderado != null && listPoderesApoderado.Count > 0)
                            {
                                foreach (PoderPersonaControlCant poder in listPoderesApoderado)
                                {
                                    if (listEstadosValidos.Contains(poder.Estado.ToString()) && (listCodigosFacultad.Contains(poder.CodFacultad.ToString())))
                                    {
                                        cantPoderesExt++;
                                    }
                                }
                            }
                        }


                        cantPoderesExt = VerifIgualdadDatoNuevo_Viejo(cantPoderesExt, codFacultad, codPoder, estado, codFacultadAnt, codPoderAnt, estadoAnt, co);
                        if (cantPoderesExt > catPoderesExtValidos)
                        {
                            error = this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_SUPERA_CANT_PODERES_EXT_PERMITIDA), co);
                            if (error != null)
                                erroresCantPoderes.Add(error);
                            listPoderesApoderado[0].ErroresNegocio = erroresCantPoderes;
                        }
                    }


                }
                return listPoderesApoderado;
            }
        }


        [AutoComplete]
        public List<BusinessEntities.PoderPersonaControlCant> controlCantPoderesAlta(int codFacultad, int codPoder, string estado, string origen, int persIdApoderado, List<string> listEstadosValidos, List<string> listCodigosFacultad,  int catPoderesExtValidos, Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, estado, origen, persIdApoderado, listEstadosValidos, listCodigosFacultad,  catPoderesExtValidos }, co))
            {
                List<PoderPersonaControlCant> listPoderesApoderado = new List<PoderPersonaControlCant>();
                List<BusinessEntities.ErrorNegocio> erroresCantPoderes = new List<BusinessEntities.ErrorNegocio>();
                BusinessEntities.ErrorNegocio error = new BusinessEntities.ErrorNegocio();

                if (listCodigosFacultad.Contains(codFacultad.ToString()))
                {
                    if (codPoder == Convert.ToInt32(Constantes.COD_PODER_EXTERNO))
                    {
                        int cantPoderesExt = 0;
                        using (MapPoderes mapPoderes = new MapPoderes())
                        {
                            listPoderesApoderado = mapPoderes.MapObtenerPoderesApoderado(persIdApoderado, Convert.ToInt32(Constantes.COD_PODER_EXTERNO), null, null, null, co);
                            if (listPoderesApoderado != null && listPoderesApoderado.Count > 0)
                            {
                                foreach (PoderPersonaControlCant poder in listPoderesApoderado)
                                {
                                    if (listEstadosValidos.Contains(poder.Estado.ToString()) && (listCodigosFacultad.Contains(poder.CodFacultad.ToString())))
                                    {
                                        cantPoderesExt++;
                                    }
                                }
                            }
                        }
                        if (cantPoderesExt >= catPoderesExtValidos)
                        {
                            error = this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_SUPERA_CANT_PODERES_EXT_PERMITIDA), co);
                            if (error != null)
                                erroresCantPoderes.Add(error);
                            listPoderesApoderado[0].ErroresNegocio = erroresCantPoderes;
                        }
                    }
                }
                
                return listPoderesApoderado;
            }
        }

        [AutoComplete]
        public List<BusinessEntities.PoderPersonaControlCant> controlCantPoderesEspeciales(string secApoderado, int codFacultad, int codPoder, string estado, bool esModificacion, int codVinculo, int persIdApoderado, List<string> listaTiposValidos, List<string> listaEstadosValidos, List<string> listaFacultadesValidas, int maxCantPoderesEspeciales, Contexto co)
        {
            using (new Tracer(new object[] { secApoderado, codFacultad, codPoder, estado, esModificacion, codVinculo, persIdApoderado, listaTiposValidos, listaEstadosValidos, listaFacultadesValidas, maxCantPoderesEspeciales }, co))
            {
                List<PoderPersonaControlCant> listaPoderesApoderado = new List<PoderPersonaControlCant>();
                PoderPersonaControlCant poderSeleccionado = new PoderPersonaControlCant();
                List<BusinessEntities.ErrorNegocio> erroresCantPoderes = new List<BusinessEntities.ErrorNegocio>();
                BusinessEntities.ErrorNegocio error = new BusinessEntities.ErrorNegocio();
                int cantPoderesEspeciales = 0;

                using (MapPoderes mapPoderes = new MapPoderes())
                {
                    listaPoderesApoderado = mapPoderes.MapObtenerPoderesApoderado(persIdApoderado, null, null, null, null, co);
                    poderSeleccionado = secApoderado != string.Empty ? listaPoderesApoderado.Find(p => p.SecApoderados == Convert.ToInt32(secApoderado)) : null;
                }
                if (listaPoderesApoderado != null && listaPoderesApoderado.Count > 0)
                {
                    foreach (PoderPersonaControlCant poder in listaPoderesApoderado)
                    {
                        //if (listEstadosValidos.Contains(poder.Estado.ToString()) && (listCodigosFacultad.Contains(poder.CodFacultad.ToString())))
                        //{
                        //    cantPoderesEspeciales++;
                        //}
                        if (listaTiposValidos.Contains(poder.CodPoder.ToString()) &&
                        listaEstadosValidos.Contains(poder.Estado) &&
                        listaFacultadesValidas.Contains(poder.CodFacultad.ToString()) &&
                        poder.CodVinculo == Constantes.COD_VINCULO_ESPECIAL) 
                        {
                            cantPoderesEspeciales++;
                        }
                    }
                }

                //Si se crea un nuevo poder
                if (!esModificacion)
                {
                    if (cantPoderesEspeciales >= maxCantPoderesEspeciales)
                    {
                        //Si supera la cantidad de poderes con las condiciones de rfc 151517   
                        if(listaEstadosValidos.Contains(estado) && 
                        listaTiposValidos.Contains(codPoder.ToString()) && 
                        listaFacultadesValidas.Contains(codFacultad.ToString()) &&
                        codVinculo == Constantes.COD_VINCULO_ESPECIAL)
                        {
                            error = this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_MAX_CANT_PODERES_ESPECIALES), co);
                            if (error != null)
                            {
                                error.Descripcion = "Ya existen " + maxCantPoderesEspeciales.ToString() + " poderes de no familiar para esta persona";
                                erroresCantPoderes.Add(error);
                            }
                            listaPoderesApoderado[0].ErroresNegocio = erroresCantPoderes;
                        }
                    }
                }
                else if(poderSeleccionado != null)
                {
                    //Se debe evaluar si el poder seleccionado no cumple con la rfc 151517
                    //Ya que puede modificar un poder existente y tener mas poderes especiales de los permitidos
                    if(!listaTiposValidos.Contains(poderSeleccionado.CodPoder.ToString()) ||
                        !listaFacultadesValidas.Contains(poderSeleccionado.CodFacultad.ToString()) ||
                        !listaEstadosValidos.Contains(poderSeleccionado.Estado) ||
                        poderSeleccionado.CodVinculo != Constantes.COD_VINCULO_ESPECIAL)
                    {
                        if (cantPoderesEspeciales >= maxCantPoderesEspeciales)
                        {
                            if (listaEstadosValidos.Contains(estado) && listaTiposValidos.Contains(codPoder.ToString()) && listaFacultadesValidas.Contains(codFacultad.ToString()) && codVinculo == Constantes.COD_VINCULO_ESPECIAL)
                            {
                                error = this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_MAX_CANT_PODERES_ESPECIALES), co);
                                if (error != null)
                                {
                                    erroresCantPoderes.Add(error);
                                }
                                listaPoderesApoderado[0].ErroresNegocio = erroresCantPoderes;
                            }
                        }
                    }
                }

                return listaPoderesApoderado;
            }
        }

        [AutoComplete]
        private int VerifIgualdadDatoNuevo_Viejo(int cantPoderesExt, int codFacultad, int codPoder, string estado, int codFacultadAnt, int codPoderAnt, string estadoAnt, Contexto co)
        {
            //Comprueba si el dato a modificar es igual al modificado, de ser diferente hay que tener lo en cuenta para ver si no se pasa de la cantidad permitida.
            using (new Tracer(new object[] { codFacultad, codPoder, estado, codFacultadAnt, codPoderAnt, estadoAnt }, co))
            {
                if (Convert.ToInt32(codFacultad) != Convert.ToInt32(codFacultadAnt) || Convert.ToInt32(codPoder) != Convert.ToInt32(codPoderAnt))
                {
                    cantPoderesExt++;
                }
                return cantPoderesExt;
            }
        }

        [AutoComplete]
        private bool VerifDatoAnteriorModificar(int codFacultadAnt, int codPoderAnt, string estadoAnt, List<string> listEstadosValidos, List<string> listCodigosFacultad,Contexto co)
        {
            //verif si los  datos viejos de la modificacion estan dentro de los datos que se tienen que controlar.
            using (new Tracer(new object[] { codFacultadAnt, codPoderAnt, estadoAnt, listEstadosValidos, listCodigosFacultad }, co))
            {
                if (codPoderAnt == Convert.ToInt32(Constantes.COD_PODER_EXTERNO) && listCodigosFacultad.Contains(codFacultadAnt.ToString()))
                {
                    return true;
                }
                return false;
            }
        }
      


        [AutoComplete]
        private List<BusinessEntities.ErrorNegocio> ValidarDatosEntrada(int codFacultad, int codPoder, int codVinculo, string comentarios, ref string estado, DateTime fechaPerDesde, DateTime? fechaPerHasta, string origen, int persIdApoderado, int persIdPoderdante, bool suep, int tipoCuratela, string uact, Contexto co)
        {
            using (new Tracer(new object[] { codFacultad, codPoder, codVinculo, comentarios, estado, fechaPerDesde, fechaPerHasta, origen, persIdApoderado, persIdPoderdante, suep, tipoCuratela, uact }, co))
            {
                List<BusinessEntities.ErrorNegocio> errores = new List<BusinessEntities.ErrorNegocio>();

                // Control de usuario en el sistema de seguridad
                errores = this.ValidarUsuario(errores, uact, co);

                // Control existencia persona en el sistema
                errores = this.ValidarPersIdentificador(errores, persIdApoderado, co);
                errores = this.ValidarPersIdentificador(errores, persIdPoderdante, co);

                // Que el apoderado y el poderdante no sean la misma persona
                if (persIdPoderdante == persIdApoderado)
                {
                    errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_IDENTIFICADORES_DE_PERSONAS_INVALIDO), co));
                }

                // Que la Facultad sea válida
                BusinessEntities.ParametrosGenerales paramGral = this.ObtenerParametroGeneral(BusinessEntities.Constantes.PARAM_GRAL_COD_FACULTAD_VALIDOS_PODERES, co);
                List<string> codigosFacultadValidos = new List<string>(paramGral.Valor.ToString().Split(','));

                if (!codigosFacultadValidos.Contains(codFacultad.ToString()))
                {
                    errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_CODIGO_DE_FACULTAD_DE_PODER_INVALIDO), co));
                }

                // Que el tipo de poder sea válido
                paramGral = this.ObtenerParametroGeneral(BusinessEntities.Constantes.PARAM_GRAL_COD_PODERES_VALIDOS, co);
                List<string> codigosPoderesValidos = new List<string>(paramGral.Valor.ToString().Split(','));

                if (!codigosPoderesValidos.Contains(codPoder.ToString()))
                {
                    errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_CODIGO_DE_PODER_INVALIDO), co));
                }

                // Que la fecha desde sea menor o igual a la fecha hasta
                if (fechaPerHasta.HasValue && fechaPerHasta.Value.Date < fechaPerDesde.Date)
                {
                    errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_FECHA_DESDE_MENOR_FECHA_HASTA), co));
                }

                // Que el código de vínculo sea válido
                if (codVinculo > 0)
                {
                    paramGral = this.ObtenerParametroGeneral(BusinessEntities.Constantes.PARAM_GRAL_COD_VINCULOS_PODER_VALIDOS, co);
                    List<string> codigosVinculoValidos = new List<string>(paramGral.Valor.ToString().Split(','));

                    if (!codigosVinculoValidos.Contains(codVinculo.ToString()))
                    {
                        errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_CODIGO_VINCULO_PODER_INVALIDO), co));
                    }
                }

                // Que el estado enviado sea válido
                if (!BusinessEntities.Constantes.codigosEstadoValidos.Contains(estado))
                {
                    if (string.IsNullOrEmpty(estado))
                        estado = BusinessEntities.Constantes.ESTADO_OTORGADO;
                    else
                        errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_ESTADO_PODER_INVALIDO), co));
                }

                // Que los comentarios no superen el valor máximo
                if (comentarios != null && comentarios.Length > BusinessEntities.Constantes.MAX_LEN_COMENTARIOS)
                {
                    errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_COMENTARIOS_PODER_SUPERAN_MAXIMO_PERMITIDO), co));
                }


                if (string.IsNullOrEmpty(origen))
                {
                    origen = "";
                }
                List<OrigenPoder> listOrigen = new List<OrigenPoder>();
                using (AdmApoderadosOrigen adm = new AdmApoderadosOrigen())
                {
                    listOrigen = adm.ObtOrigenesPoderes(origen, co);
                    
                    if (listOrigen == null || listOrigen.Count == 0)
                    {
                        errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_CODIGO_ORIGEN_INVALIDO), co));
                    }
                }
                return errores;
            }
        }

        [AutoComplete]
        public BusinessEntities.ParametrosGenerales ObtenerParametroGeneral(string descAbreviada, Seguridad.BusinessEntity.Contexto co)
        {
            using (new Tracer(new object[] { descAbreviada }, co))
            {
                BusinessEntities.ParametrosGenerales param = new BusinessEntities.ParametrosGenerales();
                List<BusinessEntities.ParametrosGenerales> paramGrales;

                using (Mappers.MapParametrosGral mapParam = new Mappers.MapParametrosGral())
                {
                    paramGrales = mapParam.ObtValoresParametroGeneral(null, descAbreviada, null, null, co);

                    if (paramGrales != null && paramGrales.Count > 0)
                        param = paramGrales[0];
                }

                return param;
            }
        }

        [AutoComplete]
        private List<BusinessEntities.ErrorNegocio> ValidarPersIdentificador(List<BusinessEntities.ErrorNegocio> errores, int persId, Contexto co)
        {
            using (new Tracer(new object[] { errores, persId }, co))
            {
                using (ServiceAgents.SAPoderes sa = new ServiceAgents.SAPoderes())
                {
                    try
                    {
                        Bull.PRES.Poderes.BusinessEntities.Persona persona = sa.ObtenerDatosPersonaPorPersID(persId, co);

                        if (persona.PersIdentificador <= 0)
                        {
                            errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_IDENTIFICADOR_DE_PERSONA_INVALIDO), co));
                        }
                        else if (persona.FechaFallecimiento.HasValue)
                        {
                            // Que la persona no este fallecida                          
                            errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_NO_PERMITE_INGRESAR_PODERES_PARA_PERSONAS_FALLECIDAS), co));
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("PER-2002"))
                        {
                            errores.Add(this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_IDENTIFICADOR_DE_PERSONA_INVALIDO), co));
                        }
                        else
                        {
                            Utils.HandleException(ex, co);
                        }
                    }
                }

                return errores;
            }
        }

        [AutoComplete]
        public List<BusinessEntities.ErrorNegocio> ValidarUsuario(List<BusinessEntities.ErrorNegocio> errores, string uact, Contexto co)
        {
            using (new Tracer(new object[] { errores, uact }, co))
            {
                bool existeUsuario = false;

                using (ServiceAgents.SAPoderes sa = new ServiceAgents.SAPoderes())
                {
                    existeUsuario = sa.ExisteUsuario(uact, co);
                }

                if (!existeUsuario)
                {
                    BusinessEntities.ErrorNegocio error = this.ObtenerErrorNegocio(Convert.ToInt32(BusinessEntities.Constantes.CodigosError.ERROR_USUARIO_INCORRECTO), co);

                    if (error != null)
                        errores.Add(error);
                }

                return errores;
            }
        }

        [AutoComplete]
        public BusinessEntities.ErrorNegocio ObtenerErrorNegocio(int codError, Seguridad.BusinessEntity.Contexto co)
        {
            using (new Tracer(new object[] { codError }, co))
            {
                BusinessEntities.ErrorNegocio error = null;

                using (Mappers.MapErroresNegocio mapError = new Mappers.MapErroresNegocio())
                {
                    error = mapError.ObtenerErrorNegocio(codError, co);
                }

                return error;
            }
        }

      
    }
}

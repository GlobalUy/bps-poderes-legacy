using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Collections.Generic;

using Bull.ApplicationFramework;
using Bull.Comunes.BusinessLogic;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Seguridad.BusinessEntity;

using Bull.ApplicationFramework.MTP.Threads.Specialized;
using Bull.ApplicationFramework.MTP.BusinessEntities;
using Bull.ApplicationFramework.MTP;
using Bull.PRES.Poderes.BusinessEntities;


namespace Bull.PRES.Poderes.BusinessLogic
{
    [Transaction(TransactionOption.NotSupported)]
    [EventTrackingEnabled(true)]
    [Synchronization(SynchronizationOption.Disabled)]
    [Guid("BDDCD7A8-A8BF-41B2-89FA-B25F21918549"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class MTPNetHilo: SimpleBatchThreadAbstract 
    {
        [AutoComplete()]
        public override ThreadExecutionResult Execute(ThreadExecutionParam param, MTPParametersDictionary record, MTPParametersDictionary customParameters, Contexto co)
        {
            using (new Tracer(new object[] { param, record, customParameters }, co))
            {
                ComParamMTP comParamMTP = new ComParamMTP();
                ComPoderes comPoderes = new ComPoderes();

                List<ComParamMTP> listaParametrosMTP = new List<ComParamMTP>();
                List<ComPoderes> listPoderes = new List<ComPoderes>();


                if (record.ContainsKey("APO_SEC_APODERADOS"))
                    comPoderes.ApoSecApoderados = record.GetString("APO_SEC_APODERADOS");

                if (record.ContainsKey("APO_PERS_IDENTIFICADOR_1"))
                    comPoderes.ApoPersIdentificador1 = record.GetString("APO_PERS_IDENTIFICADOR_1");

                if (record.ContainsKey("APO_PERS_IDENTIFICADOR_2"))
                    comPoderes.ApoPersIdentificador2 = record.GetString("APO_PERS_IDENTIFICADOR_2");

                if (record.ContainsKey("APO_COD_VINCULO"))
                    comPoderes.ApoCodVinculo = record.GetString("APO_COD_VINCULO");

                if (record.ContainsKey("APO_COMENTARIOS"))
                    comPoderes.ApoComentarios = record.GetString  ("APO_COMENTARIOS");

                if (record.ContainsKey("APO_FECHA_PER_DESDE"))
                    comPoderes.ApoFechaPerDesde = record.GetString  ("APO_FECHA_PER_DESDE");

                if (record.ContainsKey("APO_FECHA_PER_HASTA"))
                    comPoderes.ApoFechaPerHasta = record.GetString  ("APO_FECHA_PER_HASTA");

                if (record.ContainsKey("APO_FECHA_REN_REV"))
                    comPoderes.ApoFechaRenRev = record.GetString  ("APO_FECHA_REN_REV");

                if (record.ContainsKey("APO_COD_FACULTAD"))
                    comPoderes.ApoCodFacultad = record.GetString("APO_COD_FACULTAD");

                if (record.ContainsKey("APO_SUEP"))
                    comPoderes.ApoSuep = record.GetString  ("APO_SUEP");

                if (record.ContainsKey("APO_COD_PODER"))
                    comPoderes.ApoCodPoder = record.GetString("APO_COD_PODER");

                if (record.ContainsKey("CUR_TIPO_CURATELA"))
                    comPoderes.ApoCurTipoCuratela = record.GetString("CUR_TIPO_CURATELA");

                listPoderes.Add(comPoderes);

                comParamMTP.LineaGen = Utils.GetComFromList (listPoderes );
                comParamMTP.Uact = co.UsuarioActual;
                comParamMTP.Debug =co.Debug ;
                comParamMTP.FechaOpera = co.FechaOpera;

                listaParametrosMTP.Add(comParamMTP);

                
                object comParametrosMTP = Utils.GetComFromList(listaParametrosMTP);
                Utils.InvokeMethod("BatchPoderesMTP.cBatchPoderesMTP", "DispararProceso", comParametrosMTP);

            }
            return null;
        }
    }
}

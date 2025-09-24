using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Reflection;

using Bull.ApplicationFramework;
using Bull.Comunes.BusinessLogic;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Seguridad.BusinessEntity;
using Bull.ApplicationFramework.MTP;
using Bull.ApplicationFramework.MTP.BusinessEntities;
using Bull.ApplicationFramework.MTP.Specialized;
using System.Collections.Generic;
using Bull.ApplicationFramework.Legacy;
using System.Data;
using Bull.PRES.Poderes.BusinessEntities;


namespace Bull.PRES.Poderes.BusinessLogic
{
    [Transaction(TransactionOption.NotSupported)]
    [EventTrackingEnabled(true)]
    [Synchronization(SynchronizationOption.Disabled)]
    [Guid("C6BCAAB1-92EA-4B7E-9ED7-F935835E9D78"), ClassInterface(ClassInterfaceType.AutoDual)]
    [MTPThread(typeof(MTPNetHiloReportes))]
    public class MTPNetLoopReportes:SimpleBatchProcessLoopAbstract 
    {
        [AutoComplete()]
        protected override IDataReader GetDataReader(out string idColumnName, Contexto co)
        {
            bool blnHayDatos = false;
            object fnarr2ObtDatosPoderes = null;
            List <ComDatosPoderes> listDatos = new List<ComDatosPoderes> ();
            ComDatosPoderes comDatosPoderes = null;
            object parr2Datos = Utils.CreateCom ( new object[] {"COD_PAIS_EMISOR_CURADOR", "COD_TIPO_DOCUMENTO_CURADOR", "NRO_DOCUMENTO_CURADOR", "PERS_CURADOR", "NOMBRE_CURADOR", "APELLIDO_CURADOR", "COD_PAIS_EMISOR_INCAPAZ", "COD_TIPO_DOCUMENTO_INCAPAZ", "NRO_DOCUMENTO_INCAPAZ", "PERS_INCAPAZ", "NOMBRE_INCAPAZ", "APELLIDO_INCAPAZ", "COD_PODER", "ESTADO", "COD_PAIS_EMISOR_APODERADO", "COD_TIPO_DOCUMENTO_APODERADO", "NRO_DOCUMENTO_APODERADO", "PERS_APODERADO", "NOMBRE_APODERADO", "APELLIDO_APODERADO"});

             // 1º Obtengo poderes  4,5,6,9 caducados
            object parr2Poderes = Utils.InvokeMethod("ObtPoder.cObtPoder", 
                                                       "fnarr2ObtPoder","", "", "", co.FechaOpera,"(4,5,6,9)", "C", "", "", "", "", co.UsuarioActual ,"" , co.FechaOpera ,"", "", co.Debug );


            if (!Utils.IsEmpty(parr2Poderes))
            {
                for (int i = 0; i < Utils.GetRowsCount(parr2Poderes); i++)
                {
                   // plngNroSolicitud = Convert.ToInt32(Utils.GetValue("NRO_SOLICITUD", objSolicitudes,i));
                    var fecha = Utils.GetComValue ("FECHA_FALLECIMIENTO_2",parr2Poderes,i);

                    if (!Utils.IsNull("FECHA_FALLECIMIENTO_2", parr2Poderes, i))
                    {
                        var plngPersId1 =Utils.GetComValue ("PERS_IDENTIFICADOR_1",parr2Poderes,i);

                        object parr2PoderesApo = Utils.InvokeMethod("ObtPoder.cObtPoder", "fnarr2ObtPoder", "", plngPersId1,"","<NULL>","(1,2,3)","(O,P)", "", "", "","", co.UsuarioActual , "",co.FechaOpera , "", "", co.Debug );
                        
                        if (!Utils.IsEmpty(parr2PoderesApo))
                        {
                             var plngPersId2 = Utils.GetComValue ("PERS_IDENTIFICADOR_2",parr2Poderes,i); 

                             for (int e = 0; i < Utils.GetRowsCount(parr2Poderes); e++)
                             {
                                var plngPersId2Apo =  Utils.GetComValue ("PERS_IDENTIFICADOR_2",parr2PoderesApo,e);

                                if (VB60Utils.NotEqual (plngPersId2Apo,  plngPersId2))
                                {
                                    blnHayDatos =  true ;
                                    comDatosPoderes = new ComDatosPoderes() ;
                                    comDatosPoderes.CodPaisEmisorCurador  = Convert.ToString ( Utils.GetValue("PAIS_EMISOR_2",parr2Poderes,i));
                                    comDatosPoderes.CodTipoDocumentoCurador  = Convert.ToString ( Utils.GetValue("TIPO_DOCUMENTO_2",parr2Poderes,i));
                                    comDatosPoderes.NroDocumentoCurador  = Convert.ToString ( Utils.GetValue("NRO_DOCUMENTO_2",parr2Poderes,i));
                                    comDatosPoderes.PersCurador  = Convert.ToString ( Utils.GetValue("PERS_IDENTIFICADOR_2",parr2Poderes,i));
                                    comDatosPoderes.NombreCurador  = Convert.ToString ( Utils.GetValue("NOMBRE_2_1",parr2Poderes,i));
                                    comDatosPoderes.ApellidoCurador  = Convert.ToString ( Utils.GetValue("APELLIDO_2_1",parr2Poderes,i));
                                    comDatosPoderes.CodPaisEmisorIncapaz  = Convert.ToString ( Utils.GetValue("PAIS_EMISOR_1",parr2Poderes,i));
                                    comDatosPoderes.CodTipoDocumentoIncapaz  = Convert.ToString ( Utils.GetValue("TIPO_DOCUMENTO_1",parr2Poderes,i));
                                    comDatosPoderes.PersIncapaz  = Convert.ToString ( Utils.GetValue("PERS_IDENTIFICADOR_1",parr2Poderes,i));
                                    comDatosPoderes.NroDocumentoIncapaz  = Convert.ToString ( Utils.GetValue("NRO_DOCUMENTO_1",parr2Poderes,i));
                                    comDatosPoderes.NombreIncapaz  = Convert.ToString ( Utils.GetValue("NOMBRE_1_1",parr2Poderes,i));
                                    comDatosPoderes.ApellidoIncapaz  = Convert.ToString ( Utils.GetValue("APELLIDO_1_1",parr2Poderes,i));
                                    comDatosPoderes.CodPoder  = Convert.ToString ( Utils.GetValue("COD_PODER", parr2PoderesApo,e));
                                    comDatosPoderes.Estado = Convert.ToString ( Utils.GetValue("ESTADO", parr2PoderesApo,e));
                                    comDatosPoderes.CodPaisEmisorApoderado  = Convert.ToString ( Utils.GetValue("PAIS_EMISOR_2", parr2PoderesApo,e));
                                    comDatosPoderes.CodTipoDocumentoApoderado  = Convert.ToString ( Utils.GetValue("TIPO_DOCUMENTO_2", parr2PoderesApo,e));
                                    comDatosPoderes.NroDocumentoApoderado  = Convert.ToString ( Utils.GetValue("NRO_DOCUMENTO_2", parr2PoderesApo,e));
                                    comDatosPoderes.PersApoderado  = Convert.ToString ( Utils.GetValue("PERS_IDENTIFICADOR_2", parr2PoderesApo,e));
                                    comDatosPoderes.NombreApoderado  = Convert.ToString ( Utils.GetValue("NOMBRE_2_1", parr2PoderesApo,e));
                                    comDatosPoderes.ApellidoApoderado  = Convert.ToString ( Utils.GetValue("APELLIDO_2_1", parr2PoderesApo,e));

                                    listDatos.Add(comDatosPoderes);

                                }

                            }
                        }
                   
                    }
                    
                }
            }
            if (blnHayDatos)
            {
                fnarr2ObtDatosPoderes = Utils.GetComFromList (listDatos ); 
            }
            else{fnarr2ObtDatosPoderes = parr2Datos; }

            Bull.ApplicationFramework.DALCS.ComReader comRead = new ApplicationFramework.DALCS.ComReader(fnarr2ObtDatosPoderes);
            return comRead;

        }

        
        
    }
}

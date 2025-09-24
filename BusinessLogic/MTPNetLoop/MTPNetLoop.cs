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
using System.Data;

namespace Bull.PRES.Poderes.BusinessLogic
{
    [Transaction(TransactionOption.NotSupported)]
    [EventTrackingEnabled(true)]
    [Synchronization(SynchronizationOption.Disabled)]
    [Guid("6A8A19B4-6B96-4088-8FF3-FFCDF556E3CD"), ClassInterface(ClassInterfaceType.AutoDual)]
    [MTPThread(typeof(MTPNetHilo))]
    public class MTPNetLoop: SimpleBatchProcessLoopAbstract 
    {
        [AutoComplete()]
        protected override IDataReader GetDataReader(out string idColumnName, Contexto co)
        {
            idColumnName = "APO_SEC_APODERADOS";

            using (new Tracer(new object[] { idColumnName }, co))
            {
                IDataReader reader = null;
                   // Bull.ApplicationFramework.DALCS.ComReader xx = new ApplicationFramework.DALCS.ComReader(jjj)

                using (DBRapoFallecidos DBRapoFallecidos = new DBRapoFallecidos())
                {
                    reader = DBRapoFallecidos.fnarr2ObtPoderesFallecidos("", co);
                }
                //object objRapoFallecidos = Utils.InvokeMethod("MantRapoFallecidos.cMantRapoFallecidos","fnarr2ObtPoderesFallecidos",co.UsuarioActual ,"",co.FechaOpera ,"","", co.Debug );

                //Bull.ApplicationFramework.DALCS.ComReader comRead = new ApplicationFramework.DALCS.ComReader(objdatos);

                return reader;
            }
        }



    }
}

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
    [Guid("5C1AF1B6-2E63-4D08-A7DB-BAFDAD37CB26"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class MTPNetHiloReportes: SimpleBatchThreadAbstract 
    {

    }
}

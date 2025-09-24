
// ===============================================================================
// Disclaimer: this class was created by DOMPRES\fmacri on 27/09/2018 17:48:02
//
// Development platform was: Bull Guidance Package Version: 1.1.8
//
// ==============================================================================

using System;
using System.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using Bull.ApplicationFramework;
using Bull.ApplicationFramework.Diagnostics;
using Bull.Comunes.BusinessLogic;
using Bull.Seguridad.BusinessEntity;
using Bull.PRES.Poderes.ServiceAgents.Servicios.wssFuncionarios;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Security;
using Bull.PRES.Poderes.ServiceAgents.Servicios;
using Bull.PRES.Poderes.Mappers;
using Bull.PRES.Poderes.BusinessEntities;

namespace Bull.PRES.Poderes.ServiceAgents
{
    /// <summary>
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [EventTrackingEnabled(true)]
    [Guid("cdc16973-571f-458f-a891-1b68049ad33a"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class SAFuncionarios : BusinessLogicAbstract
    {
        [AutoComplete]
        public ResultObtenerFuncionarios ObtFuncionario(string nroDocumento, string tipoDoc, string codPaisEmisor, Contexto co)
        {
            using (new Tracer(new object[] { nroDocumento, tipoDoc, codPaisEmisor }, co))
            {
                try
                {
                    VirtualInterfaceClient clienteFuncionarios;
                    #region // obtengo la user & pass por parametro
                    string user = string.Empty;
                    string pass = string.Empty;
                    using (MapParametrosGral mapParamGrales = new MapParametrosGral())
                    {
                        ParametrosGenerales parametrosGrales = mapParamGrales.ObtValoresParametroGeneral(null, "WSS_FUNCIONARIOS_CREDENCIALES", null, null, co).FirstOrDefault();
                        if (parametrosGrales != null)
                        {
                            char[] separator = { ';' };
                            string valor = parametrosGrales.Valor.ToString();
                            string[] credeciales = valor.Split(separator);
                            user = credeciales[0];
                            pass = credeciales[1];
                        }
                    }

                    #endregion

                    #region // obtengo cliente, sino devuelvo null

                    //Bull.PRES.Poderes.ServiceAgents.Servicios.wssFuncionarios.VirtualInterfaceClient cliente = new Bull.PRES.Poderes.ServiceAgents.Servicios.wssFuncionarios.VirtualInterfaceClient();
                    Bull.PRES.Poderes.ServiceAgents.Servicios.wssFuncionarios.IVirtualInterfaceChannel ws = Bull.ApplicationFramework.Services.Utils.GetWcfClient<Bull.PRES.Poderes.ServiceAgents.Servicios.wssFuncionarios.IVirtualInterfaceChannel>();

                    string address = ws.RemoteAddress.Uri.AbsoluteUri;

                    if (user != string.Empty)
                    {

                        clienteFuncionarios = CrearProxyAutenticatorURL(address, user, pass, co);
                    }
                    else
                    {
                        return null;
                    }

                    #endregion

                    #region // Creo parametros a ser enviados en la peticion

                    ParamObtenerFuncionarios param = new ParamObtenerFuncionarios();

                    IdentificadorFuncionario funcionario = new IdentificadorFuncionario();
                    Bull.PRES.Poderes.ServiceAgents.Servicios.wssFuncionarios.Documento documentoFunc = new Bull.PRES.Poderes.ServiceAgents.Servicios.wssFuncionarios.Documento();
                    documentoFunc.codPaisEmisor = codPaisEmisor;
                    documentoFunc.nroDocumento = nroDocumento;
                    documentoFunc.tipoDocumento = tipoDoc;

                    funcionario.documento = documentoFunc;

                    param.identificadoresFuncionarios = new IdentificadorFuncionario[1];
                    param.identificadoresFuncionarios.SetValue(funcionario, 0);

                    obtenerFuncionariosRequest request = new obtenerFuncionariosRequest(param);
                    return clienteFuncionarios.obtenerFuncionarios(param);

                    #endregion
                }

                catch (Exception ex)
                {
                    ApplicationFramework.Utils.HandleException(ex, co);
                    throw;
                }
                finally
                { ApplicationFramework.Utils.LogFinally(System.Reflection.MethodBase.GetCurrentMethod(), co); }
            }
        }

        private static VirtualInterfaceClient CrearProxyAutenticatorURL(string url, string username, string password, Contexto co)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("La url no puede ser vacia");

            CustomBinding binding = new CustomBinding();

            var security = TransportSecurityBindingElement.CreateUserNameOverTransportBindingElement();
            security.IncludeTimestamp = false;
            security.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic256;
            security.MessageSecurityVersion = MessageSecurityVersion.WSSecurity10WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;

            var encoding = new TextMessageEncodingBindingElement();
            encoding.MessageVersion = MessageVersion.Soap11;

            var transport = new HttpsTransportBindingElement();
            transport.MaxReceivedMessageSize = 20000000; // 20 megs

            binding.Elements.Add(security);
            binding.Elements.Add(encoding);
            binding.Elements.Add(transport);

            VirtualInterfaceClient client = new Bull.PRES.Poderes.ServiceAgents.Servicios.wssFuncionarios.VirtualInterfaceClient(binding,
                new EndpointAddress(url));

            client.ChannelFactory.Endpoint.Behaviors.Remove<System.ServiceModel.Description.ClientCredentials>();
            client.ChannelFactory.Endpoint.Behaviors.Add(new CustomCredentials());

            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = password;

            return client;
        }
    }
}
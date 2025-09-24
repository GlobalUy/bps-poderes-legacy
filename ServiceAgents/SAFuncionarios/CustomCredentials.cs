using Bull.ApplicationFramework.Diagnostics;
using Bull.Seguridad.BusinessEntity;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;

namespace Bull.PRES.Poderes.ServiceAgents.Servicios
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [EventTrackingEnabled(true)]
    [Guid("925A5A67-C01E-4838-A3FA-375ADF901B70")]
    [Transaction(TransactionOption.Required)]
    public class CustomCredentials : ClientCredentials
    {
        public CustomCredentials()
        { }

        protected CustomCredentials(CustomCredentials cc)
            : base(cc)
        { }

        [AutoComplete]
        public override System.IdentityModel.Selectors.SecurityTokenManager CreateSecurityTokenManager()
        {
            using (new Tracer(new object[] { }, "BPSRING", DateTime.Now, 0))
            {
                return new CustomSecurityTokenManager(this);
            }
        }

        [AutoComplete]
        protected override ClientCredentials CloneCore()
        {
            using (new Tracer(new object[] { }, "BPSRING", DateTime.Now, 0))
            {
                return new CustomCredentials(this);
            }
        }
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [EventTrackingEnabled(true)]
    [Guid("8DC5DF9A-75A8-4440-95E7-A862F3BF330F")]
    [Transaction(TransactionOption.Required)]
    public class CustomSecurityTokenManager : ClientCredentialsSecurityTokenManager
    {
        public CustomSecurityTokenManager(CustomCredentials cred)
            : base(cred)
        { }

        [AutoComplete]
        public override System.IdentityModel.Selectors.SecurityTokenSerializer CreateSecurityTokenSerializer(System.IdentityModel.Selectors.SecurityTokenVersion version)
        {
            using (new Tracer(new object[] { version }, "BPSRING", DateTime.Now, 0))
            {
                return new CustomTokenSerializer(System.ServiceModel.Security.SecurityVersion.WSSecurity11);
            }
        }
    }

    [ClassInterface(ClassInterfaceType.AutoDual)]
    [EventTrackingEnabled(true)]
    [Guid("40066F9E-4F24-4F00-B5CB-FD5D6C988B86")]
    [Transaction(TransactionOption.Required)]
    public class CustomTokenSerializer : WSSecurityTokenSerializer
    {
        public CustomTokenSerializer(SecurityVersion sv)
            : base(sv)
        { }

        [AutoComplete]
        protected override void WriteTokenCore(System.Xml.XmlWriter writer,
                                                System.IdentityModel.Tokens.SecurityToken token)
        {
            using (new Tracer(new object[] { writer, token }, "BPSRING", DateTime.Now, 0))
            {
                UserNameSecurityToken userToken = token as UserNameSecurityToken;

                string tokennamespace = "o";

                DateTime created = DateTime.Now;
                string createdStr = created.ToString("yyyy-MM-ddThh:mm:ss.fffZ");

                // unique Nonce value - encode with SHA-1 for 'randomness'
                // in theory the nonce could just be the GUID by itself
                string phrase = Guid.NewGuid().ToString();
                var nonce = GetSHA1String(phrase);

                // in this case password is plain text
                // for digest mode password needs to be encoded as:
                // PasswordAsDigest = Base64(SHA-1(Nonce + Created + Password))
                // and profile needs to change to
                //string password = GetSHA1String(nonce + createdStr + userToken.Password);

                string password = userToken.Password;

                writer.WriteRaw(string.Format(
                "<{0}:UsernameToken u:Id=\"" + token.Id +
                "\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">" +
                "<{0}:Username>" + userToken.UserName + "</{0}:Username>" +
                "<{0}:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" +
                password + "</{0}:Password>" +
                "<{0}:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">" +
                nonce + "</{0}:Nonce>" +
                "<u:Created>" + createdStr + "</u:Created></{0}:UsernameToken>", tokennamespace));
            }
        }

        [AutoComplete]
        protected string GetSHA1String(string phrase)
        {
            using (new Tracer(new object[] { phrase }, "BPSRING", DateTime.Now, 0))
            {
                SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
                byte[] hashedDataBytes = sha1Hasher.ComputeHash(Encoding.UTF8.GetBytes(phrase));
                return Convert.ToBase64String(hashedDataBytes);
            }
        }

    }
}

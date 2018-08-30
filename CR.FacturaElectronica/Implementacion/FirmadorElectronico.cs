using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Interfaces;
using FirmaXadesNet;
using FirmaXadesNet.Crypto;
using FirmaXadesNet.Signature.Parameters;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace CR.FacturaElectronica
{
    internal class FirmadorElectronico : IFirmadorElectronico
    {
        private readonly ConfiguracionCreacionDocumentos _configuracion;

        public FirmadorElectronico(ConfiguracionCreacionDocumentos configuracion)
        {
            this._configuracion = configuracion;
        }

        public string FirmarDocumento(string rutaGuardado)
        {
            var certificado = new X509Certificate2(_configuracion.LlaveCriptograficaRuta, _configuracion.LlaveCriptograficaClave, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
            var servicioFirma = new XadesService();
            var parametros = ObtenerParametros();
            using (parametros.Signer = new Signer(certificado))
            {
                using (var fileStream = new FileStream(rutaGuardado, FileMode.Open))
                {
                    var docFirmado = servicioFirma.Sign(fileStream, parametros);
                    fileStream.Close();
                    docFirmado.Save(rutaGuardado);
                }

            }
            using (var lector = new StreamReader(rutaGuardado))
            {
                var xmlFirmado = lector.ReadToEnd();
                return xmlFirmado;

            }
            
        }

        private SignatureParameters ObtenerParametros()
        {
            var parametrosFirma = new SignatureParameters();
            parametrosFirma.SignaturePolicyInfo = new SignaturePolicyInfo();
            parametrosFirma.SignaturePolicyInfo.PolicyIdentifier = _configuracion.Politica;
            parametrosFirma.SignaturePolicyInfo.PolicyHash = _configuracion.PoliticaDigest;
            parametrosFirma.SignaturePolicyInfo.PolicyDigestAlgorithm = DigestMethod.SHA256;
            parametrosFirma.SignaturePackaging = SignaturePackaging.ENVELOPED;
            parametrosFirma.InputMimeType = "text/xml";
            parametrosFirma.SignerRole = new SignerRole();
            parametrosFirma.SignerRole.ClaimedRoles.Add("emisor");

            return parametrosFirma;
        }
    }

}

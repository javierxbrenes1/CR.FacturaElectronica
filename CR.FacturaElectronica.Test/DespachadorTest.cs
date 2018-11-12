using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Procesos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Test
{
    public class DespachadorTest
    {
        public void Ejecutar()
        {
            var config = new ConfiguracionComunicacionHacienda
            {
               ClientID = "api-stag",
               ClientSecret = "",
               GrantType = "password",
               TipoAutenticacion = "bearer",
               UrlApiHacienda = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/recepcion",
               UrlIdpLogIn = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token",
               UrlIdpLogOut = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/logout",
               IdpUsuario = "cpf-01-0956-0664@stag.comprobanteselectronicos.go.cr", 
               IdpContrasenna = "/.1_4BhBuD&)a!r{v_@$"
            };

            var despechador = new DespachadorDocumentosAHacienda(config);

            List<DocumentoDto> listadocs = new List<DocumentoDto>();
            DocumentoDto doc = new DocumentoDto {
                clave = "50611111800010956066400110000040000000002198999075", //la clave de 50 caracteres
                comprobanteXml = obtenerXML("50611111800010956066400110000040000000002198999075"),
                emisor = new PersonaDocumentoDto { //la informacion del emisor
                     numeroIdentificacion = "304810266",
                     tipoIdentificacion = "02"
                },

                fecha = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssZ") //la fecha de la factura-> cuando la factura se hizo
            };
            listadocs.Add(doc);

            despechador.EjecutarProceso(listadocs);


        }

        public string obtenerXML(string clave)
        {
            using (StreamReader lector = new StreamReader($"E:\\FEL\\xmls\\{clave}.xml")) {
                return lector.ReadToEnd();
            }
        }
    }
}

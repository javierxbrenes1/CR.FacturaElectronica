
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CR.FacturaElectronica.Mensaje_Receptor
{
    internal class MensajeReceptorProcesador 
    {
        
        // Guarda el XML en un archivo fisico
        public string fcObtenerStringXML(MensajeReceptor pvoTiquete)
        {
            try
            {
                
                //Crea Objeto serializador
                XmlSerializer vloSerializador = new XmlSerializer(typeof(MensajeReceptor));
                //Define las configuraciones
                XmlWriterSettings vloConfiguraciones = new XmlWriterSettings();
                //Asinga los valores
                vloConfiguraciones.Encoding = new UnicodeEncoding(false, false); 
                vloConfiguraciones.Indent = true;
                vloConfiguraciones.OmitXmlDeclaration = true;

                using (StringWriter vloEscritor = new StringWriter())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(vloEscritor, vloConfiguraciones))
                    {
                        vloSerializador.Serialize(xmlWriter, pvoTiquete);
                    }
                    //Antes de retornarlo lo guarda 
                    return vloEscritor.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

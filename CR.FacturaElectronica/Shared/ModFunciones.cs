using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CR.FacturaElectronica.Shared
{
    internal class ModFunciones
    {
        internal static String RemplazarCaracteresHTML(String pvoTexto)
        {
            try
            {
                if (!String.IsNullOrEmpty(pvoTexto))
                {
                    return pvoTexto.Replace("á", "&aacute;").Replace("é", "&eacute;").Replace("í", "&iacute;").Replace("ó", "&oacute;").Replace("ú", "&uacute;").Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static string ObtenerXMLComoString<T>(T documento)
        {
            XmlSerializer vloSerializador = new XmlSerializer(typeof(T));
            XmlWriterSettings vloConfiguraciones = new XmlWriterSettings();
            vloConfiguraciones.Encoding = new UnicodeEncoding(false, false);
            vloConfiguraciones.Indent = true;
            vloConfiguraciones.OmitXmlDeclaration = true;

            using (StringWriter vloEscritor = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(vloEscritor, vloConfiguraciones))
                {
                    vloSerializador.Serialize(xmlWriter, documento);
                }
                return vloEscritor.ToString();
            }
        }

        internal static T ObtenerValorEnumerador<T>(string valor, T valorDefault)
        {
            try
            {
                foreach (object item in Enum.GetValues(typeof(T)))
                {
                    T valorEnum = (T)item;
                    if (GetXmlAttrUsandoElValor<T>(valorEnum).Equals(valor, StringComparison.OrdinalIgnoreCase))
                        return (T)item;
                }
                
            }
            catch (Exception)
            {
                //No hace nada
            }
            return valorDefault;
            
        }

        private static string GetXmlAttrUsandoElValor<T>(T valorEnum)
        {
            Type type = valorEnum.GetType();
            FieldInfo info = type.GetField(Enum.GetName(typeof(T), valorEnum));
            XmlEnumAttribute att = (XmlEnumAttribute)info.GetCustomAttributes(typeof(XmlEnumAttribute), false)[0];
            return att.Name;
        }
    }

    
}

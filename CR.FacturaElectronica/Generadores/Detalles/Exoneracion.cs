using System;

namespace CR.FacturaElectronica.Generadores.Detalles
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class Exoneracion
    {
        public ExoneracionTipoDoc TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreInstitucion { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal MontoImpuesto { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string PorcentajeCompra { get; set; }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        public enum ExoneracionTipoDoc
        {
            [System.Xml.Serialization.XmlEnumAttribute("01")]
            Item01,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("02")]
            Item02,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("03")]
            Item03,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("04")]
            Item04,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("05")]
            Item05,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("99")]
            Item99,
        }

    }
}
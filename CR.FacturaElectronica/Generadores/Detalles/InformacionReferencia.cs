using System;

namespace CR.FacturaElectronica.Generadores.Detalles
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class InformacionReferencia
    {
        public TipoDocumento TipoDoc { get; set; }
        public string Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public InformacionReferenciaCodigo Codigo{ get; set; }
        public string Razon { get; set; }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        public enum InformacionReferenciaCodigo {
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
            Item99
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        public enum TipoDocumento {
            /// <comentarios/>
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
            [System.Xml.Serialization.XmlEnumAttribute("06")]
            Item06,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("07")]
            Item07,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("08")]
            Item08,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("99")]
            Item99,
        }
    }
}
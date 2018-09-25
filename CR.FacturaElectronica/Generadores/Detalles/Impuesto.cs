namespace CR.FacturaElectronica.Generadores.Detalles
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class Impuesto
    {
        public ImpuestoCodigo  Codigo{ get; set; }
        public decimal Tarifa { get; set; }
        public decimal Monto { get; set; }
        public Exoneracion Exoneracion { get; set; }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        public enum ImpuestoCodigo {
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
            [System.Xml.Serialization.XmlEnumAttribute("99")]
            Item99,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("08")]
            Item08,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("09")]
            Item09,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("10")]
            Item10,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("11")]
            Item11,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("98")]
            Item98,
        }
    }
}
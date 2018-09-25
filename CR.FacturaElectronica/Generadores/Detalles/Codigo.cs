namespace CR.FacturaElectronica.Generadores.Detalles
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class CodigoType
    {
        public TipoType Tipo { get; set; }
        public string Codigo { get; set; }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        public enum TipoType
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
            [System.Xml.Serialization.XmlEnumAttribute("99")]
            Item99

        }
    }
}
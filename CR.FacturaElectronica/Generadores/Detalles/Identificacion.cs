namespace CR.FacturaElectronica.Generadores.Detalles
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class Identificacion
    {
        public IdentificacionTipo Tipo { get; set; }
        public string Numero { get; set; }

  
        [System.SerializableAttribute()]
        public enum IdentificacionTipo
        {
            [System.Xml.Serialization.XmlEnumAttribute("01")]
            Item01,
            [System.Xml.Serialization.XmlEnumAttribute("02")]
            Item02,
            [System.Xml.Serialization.XmlEnumAttribute("03")]
            Item03,
            [System.Xml.Serialization.XmlEnumAttribute("04")]
            Item04
        }
    }
}
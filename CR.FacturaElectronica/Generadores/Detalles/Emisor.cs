namespace CR.FacturaElectronica.Generadores.Detalles
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class Emisor
    {
        public string Nombre { get; set; }
        public Identificacion Identificacion { get; set; }
        public string NombreComercial { get; set; }
        public Ubicacion Ubicacion { get; set; }
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public Telefono Telefono { get; set; }
        public Telefono Fax { get; set; }
        public string CorreoElectronico { get; set; }

    }
}
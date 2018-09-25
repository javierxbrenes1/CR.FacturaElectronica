using CR.FacturaElectronica.Generadores.Detalles;
using CR.FacturaElectronica.Interfaces;
using CR.FacturaElectronica.Shared;
using System;
using System.Xml.Serialization;

namespace CR.FacturaElectronica.Generadores.Encabezados
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica", IsNullable = false)]

    public class NotaDebitoElectronica : IEncabezado
    {
        private string SchemaLocation = "https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/notaDebitoElectronica https://tribunet.hacienda.go.cr/docs/esquemas/2016/v4.2/NotaDebitoElectronica.xsd";

        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation
        {
            get
            {
                return SchemaLocation;
            }
            set
            {
                SchemaLocation = value;
            }
        }

        public string Clave { get; set; }
        public string NumeroConsecutivo { get; set; }
        public DateTime FechaEmision { get; set; }
        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public Enumeradores.CondicionVenta CondicionVenta { get; set; }
        public string PlazoCredito { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("MedioPago")]
        public Enumeradores.MedioPago[] MedioPago { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("LineaDetalle", IsNullable = false)]
        public LineaDetalle[] DetalleServicio { get; set; }
        public ResumenFactura ResumenFactura { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("InformacionReferencia")]
        public InformacionReferencia[] InformacionReferencia { get; set; }
        public Normativa Normativa { get; set; }
        public Otros Otros { get; set; }

        public string GenerarXML()
        {
            return ModFunciones.ObtenerXMLComoString(this);
        }
    }
}

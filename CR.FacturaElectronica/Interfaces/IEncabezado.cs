using CR.FacturaElectronica.Generadores.Detalles;
using System;
using System.Xml.Serialization;

namespace CR.FacturaElectronica.Interfaces
{
    internal interface IEncabezado
    {
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        string schemaLocation { get; set; }
        string Clave { get; set; }
        string NumeroConsecutivo { get; set; }
        DateTime FechaEmision { get; set; }
        Emisor Emisor { get; set; }
        Receptor Receptor { get; set; }
        Enumeradores.CondicionVenta CondicionVenta { get; set; }
        string PlazoCredito { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("MedioPago")]
        Enumeradores.MedioPago[] MedioPago { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("LineaDetalle", IsNullable = false)]
        LineaDetalle[] DetalleServicio { get; set; }
        ResumenFactura ResumenFactura { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("InformacionReferencia")]
        InformacionReferencia[] InformacionReferencia { get; set; }
        Normativa Normativa { get; set; }
        Otros Otros { get; set; }

        string GenerarXML();
    }
}

using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores.Detalles;
using CR.FacturaElectronica.Procesos;
using CR.FacturaElectronica.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Generadores
{
    public class LineasDetalleParser
    {
        public List<LineaDetalle> ParsearLineas(List<LineaDetalleSistema> lineasSistema)
        {
            var felLineas = new List<LineaDetalle>();
            var cont = 0;
            LineaDetalle lnFel;
            foreach (var linea in lineasSistema)
            {
                lnFel = new LineaDetalle
                {
                    Cantidad = linea.Cantidad,
                    Codigo = new CodigoType[] {
                        new CodigoType{
                            Codigo = linea.Codigo, 
                            Tipo = ModFunciones.ObtenerValorEnumerador(linea.TipoCodigo, CodigoType.TipoType.Item99)
                        }
                    },
                    Detalle = linea.Detalle,
                    NumeroLinea = (cont+1).ToString(),
                    UnidadMedida = ModFunciones.ObtenerValorEnumerador(linea.UnidadMedida, LineaDetalle.UnidadMedidaType.Unid),
                    MontoDescuento = linea.MontoDescuento, 
                    MontoDescuentoSpecified = linea.MontoDescuento > 0,
                    NaturalezaDescuento = linea.NaturalezaDescuento, 
                    NaturalezaDescuentoSpecified = !string.IsNullOrEmpty(linea.NaturalezaDescuento),
                    MontoTotal = linea.MontoTotal, 
                    MontoTotalLinea = linea.MontoTotalLinea, 
                    PrecioUnitario = linea.PrecioUnitario, 
                    SubTotal = linea.SubTotal
                    
                };
                ParsearImpuesto(lnFel, linea);
                felLineas.Add(lnFel);
                cont++;
            }
            return felLineas;
        }

        private void ParsearImpuesto(LineaDetalle lnFel, LineaDetalleSistema linea)
        {
            if(!Validador.HayImpuestosDeSistema(linea.Impuesto)) return;
            var imp = new List<Impuesto>();
            linea.Impuesto.ForEach(i =>
            {
                imp.Add(new Impuesto
                {
                    Monto = i.Monto, 
                    Tarifa = i.Tarifa, 
                    Codigo = ModFunciones.ObtenerValorEnumerador(i.Codigo, Impuesto.ImpuestoCodigo.Item99),
                    Exoneracion = ParsearExoneracion(i.Exoneracion)
                });
            });
            lnFel.Impuesto = imp.ToArray();
        }

        private Exoneracion ParsearExoneracion(ExoneracionSistema exoSis)
        {
            if (exoSis == null) return null;
            var exo = new Exoneracion
            {
                FechaEmision = exoSis.FechaEmision,
                MontoImpuesto = exoSis.MontoImpuesto,
                NombreInstitucion = exoSis.NombreInstitucion,
                NumeroDocumento = exoSis.NumeroDocumento,
                PorcentajeCompra = exoSis.PorcentajeCompra,
                TipoDocumento = ModFunciones.ObtenerValorEnumerador(exoSis.TipoDocumento, Exoneracion.ExoneracionTipoDoc.Item99)
            };
            return exo;
        }
    }
}

using AutoMapper;
using CR.FacturaElectronica.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CR.FacturaElectronica.Factura
{
    internal class CreadorDetalles
    {
        private readonly IMapper mapper;

        public CreadorDetalles()
        {
            mapper = ConfigurarAutoMapper();
        }

        private Mapper ConfigurarAutoMapper()
        {
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<LineaDetalle, CR.FEL.Detalles.LineaDetalle>()
                .ForMember(r => r.Codigo, o => o.Ignore())
                .ForMember(r => r.UnidadMedida, o => o.Ignore())
                .ForMember(r => r.Impuesto, o => o.Ignore())
                .ForMember(r => r.MontoDescuentoSpecified, o => o.MapFrom(z => z.DebeMostrarDescuento))
                .ForMember(r => r.NaturalezaDescuentoSpecified, o => o.MapFrom(z => z.DebeMostrarDescuento))
                ;
                t.CreateMap<Exoneracion, CR.FEL.Detalles.Exoneracion>()
                .ForMember(r => r.TipoDocumento, o => o.Ignore())
                .ForMember(r => r.PorcentajeCompra, o => o.Ignore())
                .ForMember(r => r.MontoImpuesto, o => o.MapFrom(z => z.MontoImpuestoExon));
            });

            return new Mapper(config);
        }

        public CR.FEL.Detalles.LineaDetalle[] DefinirDetalles(List<LineaDetalle> detallesDelSistema)
        {
            CR.FEL.Detalles.LineaDetalle detalleFel;
            var contadorLinea = 0;
            var arrDetalles = new CR.FEL.Detalles.LineaDetalle[detallesDelSistema.Count];
            foreach (var detalleSistema in detallesDelSistema) {

                detalleFel = mapper.Map<CR.FEL.Detalles.LineaDetalle>(detalleSistema);
                detalleFel.Codigo = GetCodigoDetalle(detalleSistema.Codigo, detalleSistema.TipoCodigo);
                detalleFel.UnidadMedida = ModFunciones.ObtenerValorEnumerador(detalleSistema.UnidadMedida, CR.FEL.Detalles.LineaDetalle.UnidadMedidaType.Unid);
                detalleFel.Impuesto = GetImpuesto(detalleSistema);
                arrDetalles[contadorLinea] = detalleFel;
                contadorLinea++;
            }

            return arrDetalles;
        }

        private CR.FEL.Detalles.Impuesto[] GetImpuesto(LineaDetalle detalleSistema)
        {
            var arrImpuestos = new CR.FEL.Detalles.Impuesto[detalleSistema.Impuestos.Count];
            Impuesto impuestoSistema;
            CR.FEL.Detalles.Impuesto impuestoTypeFel;
            for (int i = 0; i < detalleSistema.Impuestos.Count; i++)
            {
                impuestoSistema = detalleSistema.Impuestos[i];
                impuestoTypeFel = new CR.FEL.Detalles.Impuesto
                {
                    Tarifa = impuestoSistema.Tarifa,
                    Monto = impuestoSistema.MontoImpuesto,
                    Codigo = ModFunciones.ObtenerValorEnumerador(impuestoSistema.CodigoImpuesto, CR.FEL.Detalles.Impuesto.ImpuestoCodigo.Item99)
                };
                AsignarAtributosExoneracion(impuestoTypeFel, detalleSistema);
                arrImpuestos[i] = impuestoTypeFel;
            }
            return arrImpuestos;
        }

        private void AsignarAtributosExoneracion(CR.FEL.Detalles.Impuesto impuestoFel, LineaDetalle detalleSistema)
        {
            if (!detalleSistema.EsExonerado) return;
            var exoneracion = mapper.Map<CR.FEL.Detalles.Exoneracion>(detalleSistema.Exoneracion);
            exoneracion.TipoDocumento = ModFunciones.ObtenerValorEnumerador(detalleSistema.Exoneracion.TipoDocumento, CR.FEL.Detalles.Exoneracion.ExoneracionTipoDoc.Item99);
            exoneracion.PorcentajeCompra = Convert.ToInt32(detalleSistema.Exoneracion.PorcentajeCompra).ToString();
            impuestoFel.Exoneracion = exoneracion;
        }

        private CR.FEL.Detalles.CodigoType[] GetCodigoDetalle(string codigoDetalleSistema, string codTipoDetalleSistema)
        {
            var respuesta = new CR.FEL.Detalles.CodigoType[1];
            respuesta[0] = new CR.FEL.Detalles.CodigoType()
            {
                Codigo = codigoDetalleSistema,
                Tipo = ModFunciones.ObtenerValorEnumerador(codTipoDetalleSistema, CR.FEL.Detalles.CodigoType.TipoType.Item99) 
            };
            return respuesta;
        }

        
    }

}

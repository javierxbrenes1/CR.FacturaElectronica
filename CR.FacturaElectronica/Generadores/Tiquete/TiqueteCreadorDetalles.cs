using AutoMapper;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores.Interfaces;
using CR.FacturaElectronica.Shared;
using System;
using System.Collections.Generic;

namespace CR.FacturaElectronica.Tiquete
{
    internal class TiqueteCreadorDetalles : ICreadorDetalles<TiqueteElectronicoLineaDetalle>
    {
        private readonly IMapper mapper;

        public TiqueteCreadorDetalles()
        {
            mapper = ConfigurarAutoMapper();
        }

        public TiqueteElectronicoLineaDetalle[] DefinirDetalles(List<LineaDetalle> detallesDelSistema)
        {
            TiqueteElectronicoLineaDetalle lnDetalle;
            var arrDetalles = new TiqueteElectronicoLineaDetalle[detallesDelSistema.Count];
            for (int i = 0; i < detallesDelSistema.Count; i++)
            {
                lnDetalle = mapper.Map<TiqueteElectronicoLineaDetalle>(detallesDelSistema[i]);
                lnDetalle.Codigo = GetCodigoDetalle(detallesDelSistema[i].Codigo, detallesDelSistema[i].TipoCodigo);
                lnDetalle.UnidadMedida = ModFunciones.ObtenerValorEnumerador(detallesDelSistema[i].UnidadMedida, UnidadMedidaType.Unid);
                lnDetalle.Impuesto = GetImpuesto(detallesDelSistema[i]);
                arrDetalles[i] = lnDetalle;
            }
            return arrDetalles;
        }

        private ImpuestoType[] GetImpuesto(LineaDetalle detalleSistema)
        {
            var arrImpuestos = new ImpuestoType[detalleSistema.Impuestos.Count];
            Impuesto impuestoSistema;
            ImpuestoType impuestoTypeFel;
            for (int i = 0; i < detalleSistema.Impuestos.Count; i++)
            {
                impuestoSistema = detalleSistema.Impuestos[i];
                impuestoTypeFel = new ImpuestoType
                {
                    Tarifa = impuestoSistema.Tarifa,
                    Monto = impuestoSistema.MontoImpuesto,
                    Codigo = ModFunciones.ObtenerValorEnumerador(impuestoSistema.CodigoImpuesto, ImpuestoTypeCodigo.Item99)
                };
                AsignarAtributosExoneracion(impuestoTypeFel, detalleSistema);
                arrImpuestos[i] = impuestoTypeFel;
            }
            return arrImpuestos;
        }

        private void AsignarAtributosExoneracion(ImpuestoType impuestoFel, LineaDetalle detalleSistema)
        {
            if (!detalleSistema.EsExonerado) return;
            var exoneracion = mapper.Map<ExoneracionType>(detalleSistema.Exoneracion);
            exoneracion.TipoDocumento = ModFunciones.ObtenerValorEnumerador(detalleSistema.Exoneracion.TipoDocumento, ExoneracionTypeTipoDocumento.Item99);
            exoneracion.PorcentajeCompra = Convert.ToInt32(detalleSistema.Exoneracion.PorcentajeCompra).ToString();
            impuestoFel.Exoneracion = exoneracion;
        }

        private CodigoType[] GetCodigoDetalle(string codigoDetalleSistema, string codTipoDetalleSistema)
        {
            var respuesta = new CodigoType[1];
            respuesta[0] = new CodigoType()
            {
                Codigo = codigoDetalleSistema,
                Tipo = ModFunciones.ObtenerValorEnumerador(codTipoDetalleSistema, CodigoTypeTipo.Item99)
            };
            return respuesta;
        }

        private Mapper ConfigurarAutoMapper()
        {
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<LineaDetalle, TiqueteElectronicoLineaDetalle>()
                .ForMember(r => r.Codigo, o => o.Ignore())
                .ForMember(r => r.UnidadMedida, o => o.Ignore())
                .ForMember(r => r.Impuesto, o => o.Ignore())
                .ForMember(r => r.MontoDescuentoSpecified, o => o.MapFrom(z => z.DebeMostrarDescuento))
                .ForMember(r => r.NaturalezaDescuentoSpecified, o => o.MapFrom(z => z.DebeMostrarDescuento))
                ;
                t.CreateMap<Exoneracion, ExoneracionType>()
                .ForMember(r => r.TipoDocumento, o => o.Ignore())
                .ForMember(r => r.PorcentajeCompra, o => o.Ignore())
                .ForMember(r => r.MontoImpuesto, o => o.MapFrom(z => z.MontoImpuestoExon));
            });

            return new Mapper(config);
        }
    }
}

using AutoMapper;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Factura;
using CR.FacturaElectronica.Generadores.Interfaces;
using CR.FacturaElectronica.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaDefinidorDetalles : IDefinidorDetalles<FacturaElectronicaLineaDetalle>
    {
        private readonly IMapper mapper;

        public FacturaDefinidorDetalles()
        {
            mapper = ConfigurarAutoMapper();
        }

        private Mapper ConfigurarAutoMapper()
        {
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<LineaDetalle, FacturaElectronicaLineaDetalle>()
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

        public FacturaElectronicaLineaDetalle[] DefinirDetalles(List<LineaDetalle> detallesDelSistema)
        {
            FacturaElectronicaLineaDetalle detalleFel;
            var contadorLinea = 0;
            var arrDetalles = new FacturaElectronicaLineaDetalle[detallesDelSistema.Count];
            foreach (var detalleSistema in detallesDelSistema) {

                detalleFel = mapper.Map<FacturaElectronicaLineaDetalle>(detalleSistema);
                detalleFel.Codigo = GetCodigoDetalle(detalleSistema.Codigo, detalleSistema.TipoCodigo);
                detalleFel.UnidadMedida = ModFunciones.ObtenerValorEnumerador(detalleSistema.UnidadMedida, UnidadMedidaType.Unid);
                detalleFel.Impuesto = GetImpuesto(detalleSistema);
                arrDetalles[contadorLinea] = detalleFel;
                contadorLinea++;
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

        
    }

}

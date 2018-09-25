using AutoMapper;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Factura;
using CR.FacturaElectronica.Generadores.Interfaces;
using System;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaCreadorResumen : ICreadorResumen<FacturaElectronicaResumenFactura>
    {
        private readonly IMapper mapper;

        public FacturaCreadorResumen()
        {
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<Resumen, FacturaElectronicaResumenFactura>()
                .ForMember(m=>m.CodigoMoneda, i=>i.Ignore());
            });

            mapper = new Mapper(config);
        }

        public FacturaElectronicaResumenFactura CrearResumen(Resumen resumenSistema)
        {
            var resumenFel = mapper.Map<FacturaElectronicaResumenFactura>(resumenSistema);
            try
            {
                resumenFel.CodigoMoneda = (FacturaElectronicaResumenFacturaCodigoMoneda)Enum.Parse(typeof(FacturaElectronicaResumenFacturaCodigoMoneda), resumenSistema.Moneda);
            }
            catch (Exception)
            {
                resumenFel.CodigoMoneda = FacturaElectronicaResumenFacturaCodigoMoneda.CRC;
            }
            AsignarTrueABanderasDeDespliegue(resumenFel);
            return resumenFel;
        }

        private void AsignarTrueABanderasDeDespliegue(FacturaElectronicaResumenFactura resumenFel)
        {
            resumenFel.CodigoMonedaSpecified = true;
            resumenFel.TipoCambioSpecified = true;
            resumenFel.TotalDescuentosSpecified = true;
            resumenFel.TotalExentoSpecified = true;
            resumenFel.TotalGravadoSpecified = true;
            resumenFel.TotalImpuestoSpecified = true;
            resumenFel.TotalMercanciasExentasSpecified = true;
            resumenFel.TotalMercanciasGravadasSpecified = true;
            resumenFel.TotalServExentosSpecified = true;
            resumenFel.TotalServGravadosSpecified = true;
        }
    }
}

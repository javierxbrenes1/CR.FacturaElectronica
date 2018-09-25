using AutoMapper;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Factura;
using CR.FacturaElectronica.Generadores.Interfaces;
using System;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaCreadorResumen
    {
        private readonly IMapper mapper;

        public FacturaCreadorResumen()
        {
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<Resumen, CR.FEL.Detalles.ResumenFactura>()
                .ForMember(m=>m.CodigoMoneda, i=>i.Ignore());
            });

            mapper = new Mapper(config);
        }

        public CR.FEL.Detalles.ResumenFactura CrearResumen(Resumen resumenSistema)
        {
            var resumenFel = mapper.Map<CR.FEL.Detalles.ResumenFactura>(resumenSistema);
            try
            {
                resumenFel.CodigoMoneda = (CR.FEL.Detalles.ResumenFactura.Moneda)Enum.Parse(typeof(CR.FEL.Detalles.ResumenFactura.Moneda), resumenSistema.Moneda);
            }
            catch (Exception)
            {
                resumenFel.CodigoMoneda = CR.FEL.Detalles.ResumenFactura.Moneda.CRC;
            }
            return resumenFel;
        }

      
    }
}

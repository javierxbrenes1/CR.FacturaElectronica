using AutoMapper;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores.Interfaces;
using CR.FacturaElectronica.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Tiquete
{
    internal class TiqueteCreadorDocumentoReferencia : ICreadorDocumentoReferencia<TiqueteElectronicoInformacionReferencia>
    {
        private readonly IMapper mapper;
        public TiqueteCreadorDocumentoReferencia()
        {
            var config = new MapperConfiguration(t => {
                t.CreateMap<DocumentoReferencia, TiqueteElectronicoInformacionReferencia>()
                .ForMember(m => m.Codigo, o => o.Ignore())
                .ForMember(m => m.TipoDoc, o => o.Ignore());
            });

            mapper = new Mapper(config);
        }

        public TiqueteElectronicoInformacionReferencia[] CrearArregloReferencias(DocumentoReferencia[] referenciasSistema)
        {
            if (referenciasSistema == null || referenciasSistema.Length <= 0) return null;
            var arregloFelDocsReferencias = new TiqueteElectronicoInformacionReferencia[referenciasSistema.Length];
            TiqueteElectronicoInformacionReferencia refAux;
            for (int i = 0; i < referenciasSistema.Length; i++)
            {
                refAux = mapper.Map<TiqueteElectronicoInformacionReferencia>(referenciasSistema[i]);
                refAux.Codigo = ModFunciones.ObtenerValorEnumerador(referenciasSistema[i].Codigo, TiqueteElectronicoInformacionReferenciaCodigo.Item99);
                refAux.TipoDoc = ModFunciones.ObtenerValorEnumerador(referenciasSistema[i].TipoDoc, TiqueteElectronicoInformacionReferenciaTipoDoc.Item99);
                arregloFelDocsReferencias[i] = refAux;
            }
            return arregloFelDocsReferencias;

        }
    }
}

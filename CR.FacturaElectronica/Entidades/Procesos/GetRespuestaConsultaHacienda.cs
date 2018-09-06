using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Entidades
{
    public class GetRespuestaConsultaHacienda
    {
        public bool ConsultaExitosa { get; set; }
        public string Mensaje { get; set; }
        public EstadoDocumentoDto Estado { get; set; }
    }
}

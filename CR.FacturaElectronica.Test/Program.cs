using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //new DespachadorTest().Ejecutar();
                new ConsultorTest().Consultar("50611111800010956066400110000040000000002198999075");

                //var generador = new GenerarDocumentoElectronico();

                //generador.GenerarXMl();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}

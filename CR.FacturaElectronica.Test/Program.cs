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

                new DespachadorTest().Ejecutar();
                new ConsultorTest().Consultar("50622101800030385010000100001010000000493140264212");

                var generador = new GenerarDocumentoElectronico();

                generador.GenerarXMl();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}

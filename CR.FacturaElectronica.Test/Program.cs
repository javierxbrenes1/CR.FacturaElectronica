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

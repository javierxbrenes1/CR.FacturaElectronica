﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica
{
    public class NotGeneradorFoundException : Exception
    {
        public NotGeneradorFoundException(string message): base(message)
        {}
    }
}

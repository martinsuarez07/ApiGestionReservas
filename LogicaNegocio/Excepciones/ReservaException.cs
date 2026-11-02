using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class ReservaException : Exception
    {
        public ReservaException(string mensaje)
            : base(mensaje)
        {
        }
    }
}

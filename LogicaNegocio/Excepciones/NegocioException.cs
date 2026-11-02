using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Excepciones
{
    public class NegocioException : Exception
    {
        public NegocioException(string mensaje)
            : base(mensaje)
        {
        }
    }
}

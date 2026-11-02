using DTOs.DataTransferObject;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasosDeUso.ICUUsuario
{
    public interface ICUAltaUsuario
    {
        void Ejecutar(DTOAltaUsuario dto);
    }
}

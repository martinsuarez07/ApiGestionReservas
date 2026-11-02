using DTOs.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.ICasosDeUso.ICUUsuario
{
    public interface ICULogin
    {
        DTOUsuarioLogueado Ejecutar(DTOLogin dto);
    }
}

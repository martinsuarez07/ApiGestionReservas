using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.IRepositorio
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Usuario GetByEmail(string email);

        bool ExisteEmail(string email);
    }
}

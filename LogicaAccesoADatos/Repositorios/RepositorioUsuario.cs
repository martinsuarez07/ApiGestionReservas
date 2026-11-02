using LogicaAccesoDatos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoADatos.Repositorios
{
    public class RepositorioUsuario
    : Repositorio<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(ApplicationDbContext context)
            : base(context)
        {
        }

        public Usuario GetByEmail(string email)
        {
            return _context.Usuarios
                .FirstOrDefault(u => u.Email == email);
        }

        public bool ExisteEmail(string email)
        {
            return _context.Usuarios
                .Any(u => u.Email == email);
        }
    }
}

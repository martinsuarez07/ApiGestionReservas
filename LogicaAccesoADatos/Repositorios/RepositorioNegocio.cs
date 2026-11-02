using LogicaAccesoDatos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoADatos.Repositorios
{
    public class RepositorioNegocio
    : Repositorio<Negocio>, IRepositorioNegocio
    {
        public RepositorioNegocio(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Negocio> GetNegociosActivos()
        {
            return _context.Negocios
                .Where(n => n.Activo)
                .ToList();
        }
    }
}

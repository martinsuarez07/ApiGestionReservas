using LogicaAccesoDatos;
using LogicaNegocio.Entidades;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoADatos.Repositorios
{
    public class RepositorioServicio
     : Repositorio<Servicio>, IRepositorioServicio
    {
        public RepositorioServicio(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Servicio> GetServiciosActivos()
        {
            return _context.Servicios
                .Where(s => s.Activo)
                .ToList();
        }
    }
}

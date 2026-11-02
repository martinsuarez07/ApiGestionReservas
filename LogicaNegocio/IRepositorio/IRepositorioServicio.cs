using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.IRepositorio
{
    public interface IRepositorioServicio : IRepositorio<Servicio>
    {
        void Add(Servicio servicio);
        Servicio GetById(int id);
        IEnumerable<Servicio> GetAll();
        void Update(Servicio servicio);
        void Remove(int id);

        IEnumerable<Servicio> GetServiciosActivos();
    }
}

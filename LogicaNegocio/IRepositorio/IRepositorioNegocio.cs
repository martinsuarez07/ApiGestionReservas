using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.IRepositorio
{
    public interface IRepositorioNegocio : IRepositorio<Negocio>
    {
        void Add(Negocio negocio);
        Negocio GetById(int id);
        IEnumerable<Negocio> GetAll();
        void Update(Negocio negocio);
        void Remove(int id);

        IEnumerable<Negocio> GetNegociosActivos();
    }
}

using LogicaAccesoDatos;
using LogicaNegocio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoADatos.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected ApplicationDbContext _context;
        private ApplicationDbContext context;

        public Repositorio(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public void Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            T obj = GetById(id);

            if (obj != null)
            {
                _context.Set<T>().Remove(obj);
                _context.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Entitles.Models;
using Repositories.RepositoryBase;

namespace DomainModel.Services.EmpleadoService
{
    public class EmpleadoService : IEmpleadoService
    {
        private IRepository<Empleado> _repository;

        public EmpleadoService(IRepository<Empleado> repository)
        {
            _repository = repository;
        }

        public void Add(Empleado obj)
        {
           _repository.Insert(obj);
            _repository.SaveChanges();
        }

        public IEnumerable<Empleado> GetAll()
        {
            return _repository.GetAll();
        }

        public Empleado GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Remove(Empleado obj)
        {
            _repository.Remove(obj);
            _repository.SaveChanges();
        }

        public void Update(Empleado obj)
        {
            _repository.Update(obj);
            _repository.SaveChanges();
        }
    }
}
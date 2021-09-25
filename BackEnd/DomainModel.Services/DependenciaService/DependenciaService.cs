using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.Entitles.Models;
using Repositories.RepositoryBase;

namespace DomainModel.Services.DependenciaService
{
    public class DependenciaService : IDependenciaService
    {
        private IRepository<Dependencia> _repository;

        public DependenciaService(IRepository<Dependencia> repository)
        {
            _repository = repository;
        }

        public void Add(Dependencia obj)
        {
           _repository.Insert(obj);
            _repository.SaveChanges();
        }

        public IEnumerable<Dependencia> GetAll()
        {
            return _repository.GetAll();
        }

        public Dependencia GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Remove(Dependencia obj)
        {
            _repository.Remove(obj);
            _repository.SaveChanges();
        }

        public void Update(Dependencia obj)
        {
            _repository.Update(obj);
            _repository.SaveChanges();
        }
    }
}
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;
        protected Repository()
        {
            this.models = new List<T>();
        }
        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.models.ToList().AsReadOnly();
        }

        public T GetByName(string name)
        {
            T entity = this.models.FirstOrDefault(t => t.GetType().Name == name);
            return entity;
        }

        public bool Remove(T model)
        {
            return this.models.Remove(model);
        }
    }
}

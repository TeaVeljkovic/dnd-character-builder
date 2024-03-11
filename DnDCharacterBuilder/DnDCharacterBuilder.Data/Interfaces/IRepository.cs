using DnDCharacterBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilder.Data.Interfaces
{
    public interface IRepository<T> where T : BaseClass
    {
        List<T> GetAll();
        IQueryable<T> GetAsQueryable();
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}

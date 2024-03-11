using DnDCharacterBuilder.Data.Context;
using DnDCharacterBuilder.Data.Interfaces;
using DnDCharacterBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DnDCharacterBuilder.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseClass
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _dbSet.Remove(GetById(id));
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public IQueryable<T> GetAsQueryable()
        {
            return _dbSet;
        }

        public T GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

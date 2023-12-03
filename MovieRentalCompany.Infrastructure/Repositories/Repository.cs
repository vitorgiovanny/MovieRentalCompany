using Microsoft.EntityFrameworkCore;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context) => _context = context;

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>().ToList();

        public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> condition)
            => _context.Set<TEntity>().Where(condition).ToList();

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        TEntity IRepository<TEntity>.GetById(int id) => _context.Set<TEntity>().Find(id);
    }
}

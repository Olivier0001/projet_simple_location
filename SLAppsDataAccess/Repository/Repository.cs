using Microsoft.EntityFrameworkCore;
using SLApps.DataAccess;
using SLAppsDataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SLAppsDataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> contextSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            this.contextSet= _context.Set<T>();
        }

        public void Add(T entity)
        {
            contextSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = contextSet;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = contextSet;

            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            contextSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            contextSet.RemoveRange(entity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlayTennis.Dal
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        public UnitOfWork UnitOfWork { get; set; }
        public IQueryable<TEntity> Entities { get; set; }

        private readonly PalyTennisDb _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository()
        {
            UnitOfWork = new UnitOfWork();
            _context = UnitOfWork.MyDbContext;
            _dbSet = _context.Set<TEntity>();
            Entities = _dbSet.AsNoTracking();
        }

        public virtual IEnumerable<TEntity> Get(
                Expression<Func<TEntity, bool>> filter,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            //foreach (var includeProperty in includeProperties.Split
            //    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //{
            //    query = query.Include(includeProperty);
            //}

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                return query.FirstOrDefault(filter);
            }
            return query.FirstOrDefault();
        }
        public virtual IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual int Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            if (UnitOfWork.EnableTransation)
            {
                return 0;
            }
            return _context.SaveChanges();
        }

        public virtual int Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
            if (UnitOfWork.EnableTransation)
            {
                return 0;
            }
            return _context.SaveChanges();
        }

        public virtual int Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
            if (UnitOfWork.EnableTransation)
            {
                return 0;
            }
            return _context.SaveChanges();
        }

        public virtual int Update(TEntity entityToUpdate)
        {
            DbEntityEntry<TEntity> entry = _context.Entry(entityToUpdate);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
                entry.State = EntityState.Modified;
            }

            //_dbSet.Attach(entityToUpdate);
            //_context.Entry(entityToUpdate).State = EntityState.Modified;
            if (UnitOfWork.EnableTransation)
            {
                return 0;
            }
            return _context.SaveChanges();
        }
    }
}

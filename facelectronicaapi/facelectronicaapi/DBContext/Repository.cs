using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FacElectronicaApi.DBContext
{
    public class Repository<T> where T : class
    {
        protected readonly DbContext _DbContext;
        protected readonly DbSet<T> _DbSet;

        public Repository(DbContext context)
        {
            _DbContext = context;
            _DbSet = _DbContext.Set<T>();
        }

        public DbSet<T> Items { get { return _DbSet; } }

        public IQueryable<T> GetAll()
        {
            return _DbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] paths)
        {
            IQueryable<T> query = _DbSet;
            foreach (var path in paths)
                query = query.Include(path);

            return query.AsNoTracking();
        }

        public DbRawSqlQuery<T> SqlQuery(string sql, params object[] parameters)
        {
            return _DbContext.Database.SqlQuery<T>(sql, parameters);
        }

        public long Count()
        {
            return GetAll().LongCount();
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            return Find(predicate).LongCount();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.AsNoTracking().Where<T>(predicate);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] paths)
        {
            IQueryable<T> query = _DbSet.AsNoTracking();
            foreach (var path in paths)
                query = query.Include(path);
            return query.Where<T>(predicate).AsNoTracking();
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.AsNoTracking().Single<T>(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.AsNoTracking().SingleOrDefault<T>(predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.AsNoTracking().First<T>(predicate);
        }

        public T First()
        {
            return _DbSet.AsNoTracking().First<T>();
        }

        public T Last(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.AsNoTracking().Last<T>(predicate);
        }

        public virtual void Delete(T entity)
        {
            if (_DbContext.Entry(entity).State == EntityState.Detached)
                Attach(entity);
            _DbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var entitiesToDelete = _DbSet.Where(predicate).ToList();
            foreach (var entity in entitiesToDelete)
                Delete(entity);
        }

        public virtual void Add(T entity)
        {
            _DbSet.Add(entity);
        }

        public void Attach(T entity)
        {
            _DbSet.Attach(entity);
        }

        public void Detach(T entity)
        {
            _DbContext.Entry(entity).State = EntityState.Detached;
        }

        public virtual void Update(T entity)
        {
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return _DbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (_DbContext != null)
                    _DbContext.Dispose();
        }

        public double Max(Expression<Func<T, double>> predicate)
        {
            return _DbSet.Max(predicate);
        }

        public int ExecuteSqlCommand(String sql)
        {
            return _DbContext.Database.ExecuteSqlCommand(sql, null);
        }

        public int ExecuteSqlCommand(String sql, params object[] parameters)
        {
            return _DbContext.Database.ExecuteSqlCommand(sql, parameters);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Domain.Entities.Base;
using Domain.Interfaces.Base;

namespace Infrastructure.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase<T>
    {

        protected readonly MyTasksDbContext _contexto;
        protected DbSet<T> DbSet;

        public RepositoryBase(MyTasksDbContext contexto)
        {
            _contexto = contexto;
            DbSet = this._contexto.Set<T>();
        }

        public virtual T Add(T entidade)
        {
            entidade.CreateAt = DateTime.Now;
            DbSet.Add(entidade);
            _contexto.SaveChanges();
            return entidade;
        }

        public virtual void Remove(T entidade)
        {
            DbSet.Remove(entidade);
            _contexto.SaveChanges();
        }

        public virtual T Find(int id) => DbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public virtual IEnumerable<T> GetAll() => DbSet.AsNoTracking().Select(c => c);

        public virtual void Update(T entidade)
        {
            entidade.AlterAt = DateTime.Now;
            DbSet.Update(entidade);
            _contexto.SaveChanges();
        }

        public virtual void Dispose()
        { }
    }
}

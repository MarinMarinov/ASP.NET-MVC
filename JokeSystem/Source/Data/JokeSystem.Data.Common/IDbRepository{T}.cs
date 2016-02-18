namespace JokeSystem.Data.Common
{
    using System.Linq;
    using Models;

    public interface IDbRepository<T>
        where T : BaseModel
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(object id);

        T GetByIdWithDeleted(object id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}


using EntityLibrary.abstraction;

namespace RepositoryLibrary.Base
{
    public interface IRepository<T> where T :  IEntity
    {   
        public T Create(T entity);

        public void Update(T entity);

        public void Remove(T entity);

        public List <T> GetAll(Predicate <T> filter);

       public  T Get(Predicate<T> filter);
    }
}
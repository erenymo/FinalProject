using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess;
// generic constraint --> generic kısıtlaması
// class : referans tip tutabilir demek
// IEntity : IEntity olabilir ya da IEntity implemente eden bir nesne olabilir
// new() : new'lenebilir olmalı. (IEntity newlenemez); 
public interface IEntityRepository<T> where T:class,IEntity,new()
{
    List<T> GetAll(Expression<Func<T, bool>> filter = null); // parametreye filtre girmemizi sağlar
    T Get(Expression<Func<T, bool>> filter); // filtre vermek zorunda değilsin. filtre vermezsen tüm datayı getirir.
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}

using System;

namespace ProductManagement.Repositories;

public interface IRepository<T>
{
    void AddElements(T item);
    List<T> GetAll();
    List<T> GetByCondtion(Func<T, bool> predicate);
    void UpdateElement(T item);
    void RemoveElement(T item);
}

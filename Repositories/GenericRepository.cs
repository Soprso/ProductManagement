using System;
using System.Runtime.CompilerServices;
using ProductManagement.Models;

namespace ProductManagement.Repositories;

public class GenericRepository<T> : IRepository<T> where T : IEntity
{
    List<T> elem = new List<T>();
    public void AddElements(T item)
    {
        elem.Add(item);
    }
    public List<T> GetAll()
    {
        return elem;
    }
    public List<T> GetByCondtion(Func<T, bool> predicate)
    {
        return elem.Where(predicate).ToList();
    }
    public void UpdateElement(T item)
    {
        var elemExists = elem.Where(e => e.Id == item.Id).FirstOrDefault();
        if (elemExists != null)
        {
            elem.Remove(elemExists);
            elem.Add(item);
        }
    }
    public void RemoveElement(T item)
    {
        var elemExists = elem.Where(e => e.Id == item.Id).FirstOrDefault();
        if (elemExists != null)
        {
            elem.Remove(elemExists);
        }
    }
}

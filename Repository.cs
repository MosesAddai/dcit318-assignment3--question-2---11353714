using System;
using System.Collections.Generic;
using System.Linq;

public class Repository<T> where T : class
{
    // Field to store entities
    private List<T> items = new List<T>();

    // Add an entity
    public void Add(T item)
    {
        items.Add(item);
    }

    // Retrieve all entities
    public List<T> GetAll()
    {
        return new List<T>(items);
    }

    // Retrieve first entity that matches a condition (predicate)
    public T? GetById(Func<T, bool> predicate)
    {
        return items.FirstOrDefault(predicate);
    }

    // Remove first entity that matches a condition (predicate)
    public bool Remove(Func<T, bool> predicate)
    {
        var item = items.FirstOrDefault(predicate);
        if (item != null)
        {
            items.Remove(item);
            return true;
        }
        return false;
    }
}

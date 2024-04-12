namespace ConsoleApp3;
using System;
using System.Collections.Generic;
using System.Linq;


public interface IRepository<T> where T : class
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}


public class Entity
{
    public int Id { get; set; }
}


public class GenericRepository<T> : IRepository<T> where T : class
{
    private List<T> dataStore;

    public GenericRepository()
    {
        dataStore = new List<T>();
    }

    public void Add(T item)
    {
        dataStore.Add(item);
    }

    public void Remove(T item)
    {
        dataStore.Remove(item);
    }

    public void Save()
    {
        
        Console.WriteLine("Changes saved successfully.");
    }

    public IEnumerable<T> GetAll()
    {
        return dataStore;
    }

    public T GetById(int id)
    {
        return dataStore.FirstOrDefault(item => (item as Entity)?.Id == id);
    }
}

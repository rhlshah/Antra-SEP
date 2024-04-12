namespace ConsoleApp3;
using System;
using System.Collections.Generic;

public class MyList<T>
{
    private List<T> items;

    public MyList()
    {
        items = new List<T>();
    }

    public void Add(T element)
    {
        items.Add(element);
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
        }

        T removedItem = items[index];
        items.RemoveAt(index);
        return removedItem;
    }

    public bool Contains(T element)
    {
        return items.Contains(element);
    }

    public void Clear()
    {
        items.Clear();
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
        }

        items.Insert(index, element);
    }

    public void DeleteAt(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
        }

        items.RemoveAt(index);
    }

    public T Find(int index)
    {
        if (index < 0 || index >= items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
        }

        return items[index];
    }
}
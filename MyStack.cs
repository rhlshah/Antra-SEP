namespace ConsoleApp3;

using System;
using System.Collections.Generic;

public class MyStack<T>
{
    private List<T> items;

    public MyStack()
    {
        items = new List<T>();
    }

    public int Count()
    {
        return items.Count;
    }

    public T Pop()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        T poppedItem = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return poppedItem;
    }

    public void Push(T item)
    {
        items.Add(item);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class GenericObjectPool<T> where T : class
{
    private List<PooledItem<T>> poolItems = new List<PooledItem<T>>();

    public T GetItem<U>() where U : T 
    {
        if(poolItems.Count > 0)
        {
            PooledItem<T> item = poolItems.Find(item => !item.isUsed && item.Item is U);
            if(item != null)
            {
                item.isUsed = true;
                return item.Item;
            }
        }
        return CreateNewPooledItem<U>();
    }

    private T CreateNewPooledItem<U>() where U : T       
    {
        PooledItem<T> newItem = new PooledItem<T>();
        newItem.Item = CreateItem<U>();
        newItem.isUsed = true;
        poolItems.Add(newItem);
        return newItem.Item;

    }

    protected virtual T CreateItem<U>() where U : T
    {
        throw new NotImplementedException("CreateItem() method not implemented in derived class");
    }

    public void ReturnItem(T item)
    {
        PooledItem<T> pooledItem = poolItems.Find(i => i.Item.Equals(item));
        pooledItem.isUsed = false;
    }

    public int Count
    {
        get 
        {
            int count = 0;
            foreach (var it in poolItems)
            {
                if(it.isUsed)
                    count++;
            }
            return count; 
        }
    }
}

public class PooledItem<T>
{
    public bool isUsed;
    public T Item;
}
using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    private bool _autoExpending;
    private T _prefab;
    private Transform _parent;
    private Queue<T> _pool;

    public PoolMono(T prefab, Transform parennt, int count, bool autoExpending = true)
    {
        _prefab = prefab;
        _parent = parennt;
        _autoExpending = autoExpending;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new Queue<T>(count);
        for (int i = 0; i < count; i++)
        {
            CreateElement();
        }
    }

    private T CreateElement(bool setActiveByDefault = false)
    {
        T newObject = GameObject.Instantiate(_prefab, _parent);
        newObject.gameObject.SetActive(setActiveByDefault);
        _pool.Enqueue(newObject);
        return newObject;
    }


    private bool HasFreeElement(out T element)
    {
        
        foreach (var item in _pool)
        {  

            if(item.gameObject.activeInHierarchy == false)
            { 
                element = item;
                return true;
            }

        }

        element = null;
        return false;
    }
    private T GetFreeElement()
    {
        if(HasFreeElement(out var element))
        {
            return element;
        }

        if(_autoExpending == true)
        {
            return CreateElement(true);
            
        }

        throw new Exception($"There is no free element in pool of type {typeof(T)}");
    }
    public T GetFreeElement(Vector3 position)
    {
        T element = GetFreeElement();
        element.transform.position = position;
        element.gameObject.SetActive(true);
        return element;
    }
}
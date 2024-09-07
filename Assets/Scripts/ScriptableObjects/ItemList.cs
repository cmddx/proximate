using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList<T> : ScriptableObject
{
    public List<T> items;

    public T Get(string referenceName)
    {
        foreach (T item in items)
        {
            if (referenceName.ToLower() == (item as Object).name.ToLower())
                return item;
        }

        Debug.Log("Failed to find item: " + referenceName);
        return default;
    }

    public void AddItem(T item){
        items.Add(item);
    }
}

// [CreateAssetMenu(menuName = "ScriptableObjects/Sprite List")]
// public class SpriteList : ItemList<Sprite>
// {

// }
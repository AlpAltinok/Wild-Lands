using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Collect : MonoBehaviour,Iinteraction
{
    public delegate void ToplanabilirItemOlayi(Objects item);
    public static ToplanabilirItemOlayi itemAlindi;
    [SerializeField]
    Objects item;
    public void Interaction()
    {
        itemAlindi(item);
        Destroy(gameObject);
    }

    public string getName()
    {
        return item.itemname;
    }

   
}

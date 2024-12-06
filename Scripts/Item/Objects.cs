using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objects : ScriptableObject
{
    public int itemID;
    public string itemname;
    public bool itemStoklanabilir;
    public string itemAcýklama;
    public float itemFiyat;
    public GameObject itemNesnesi;
    public Sprite itemResmi;
    

    public abstract void Kullan();
    public abstract void Sat();





}

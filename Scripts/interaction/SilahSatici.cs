using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SilahSatici : MonoBehaviour ,Iinteraction
{
    public delegate void SilahSaticiEtkilesim(SilahSatici satici);
    public static SilahSaticiEtkilesim silahSaticiAcildi;
    public List<SandikEnvanterSlot> sandikItemleri;
    public string getName()
    {
        return name;
    }

    public void Interaction()
    {
        silahSaticiAcildi(this);
    }

  
}
[Serializable]
public struct SandikEnvanterSlot{
    public Objects item;
    public int miktar;
    public int fiyat;

    public SandikEnvanterSlot(Objects item, int miktar, int fiyat)
    {
        this.item = item;
        this.miktar = miktar;
        this.fiyat = fiyat;
    }
}

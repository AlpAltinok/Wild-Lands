using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvanterController : MonoBehaviour
{
    List<EnvanterSlot> envanterItemleri = new List<EnvanterSlot>();
    List<EnvanterSlot> SilahSaticiItemleri = new List<EnvanterSlot>();
    Objects OBJ;
    [SerializeField]
    Transform envanterUI;
    [SerializeField]
    GameObject buttonPrefab;

    public GameObject envanter;
    public static bool masude;




    private void OnEnable()
    {
        Collect.itemAlindi += ItemAlindi;

    }
    private void Start()
    {
        envanter.SetActive(false);

        OBJ = GetComponent<Objects>();
    }

    private void OnDisable()
    {
        Collect.itemAlindi -= ItemAlindi;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            envanter.SetActive(!envanter.activeSelf);
        }

    }
    public void ButtonKullan(GameObject buton)
    {

        foreach (EnvanterSlot slot in envanterItemleri)
        {
            if (slot.slotButton == buton)
            {
                slot.slotItem.Kullan();
                slot.SlotStok--;
                SlotKontrol(slot);
                break;
            }
        }
    }

   


    
    public void SatmaButonu(GameObject buton)
    {
        foreach (EnvanterSlot slot in envanterItemleri)
        {
            if (slot.slotButton == buton)
            {
                Debug.Log("BEN calisiyorum");
                slot.slotItem.Sat();
                slot.SlotStok--;
                SlotKontrol(slot);
                

                break;

            }
        }
    }
    void SlotKontrol(EnvanterSlot slot)
    {
        if (slot.SlotStok < 1)
        {
            Destroy(slot.slotButton.gameObject);
            envanterItemleri.Remove(slot);
        }
    }
    public void ButonAl(GameObject buton)
    {
        foreach (EnvanterSlot slot in SilahSaticiItemleri)
        {
            if (slot.slotButton == buton)
            {
                ItemAlindi(slot.slotItem);
                slot.SlotStok--;
                break;
            }
        }
        
    }



    public void ItemAlindi(Objects item)
    {

        if (item.itemStoklanabilir)
        {
            List<Objects> geciciItemler = new List<Objects>();
            foreach (EnvanterSlot slot in envanterItemleri)
            {
                geciciItemler.Add(slot.slotItem);
               
            }
            if (geciciItemler.Contains(item))
            {
                envanterItemleri[geciciItemler.IndexOf(item)].SlotStok++;
            }
            else
            {
                yeniItemEkle(item);
               

            }

        }
        else
        {
            yeniItemEkle(item);
            
        }
       


    }

    void yeniItemEkle(Objects item)
    {
        GameObject buton = Instantiate(buttonPrefab, envanterUI);
        buton.name = item.itemname;
        if (item.itemID == 3)
        {
            masude = true;
        }
        buton.GetComponent<Image>().sprite = item.itemResmi;
        buton.GetComponent<EnvanterButton>().envanter = this;
        EnvanterSlot yenislot = new EnvanterSlot
        {
            slotButton = buton,
            SlotStok = 1,
            slotItem = item
            

        };
        envanterItemleri.Add(yenislot);
        
        
    }


    public class EnvanterSlot
    {
        public GameObject slotButton;
        public Objects slotItem;
        int slotStok;

        public int SlotStok
        {
            get
            {
                return slotStok;
            }
            set
            {
                slotStok = value;
                slotButton.GetComponentInChildren<Text>().text = (SlotStok > 1) ? SlotStok.ToString() : "";
            }
        }
    }
}
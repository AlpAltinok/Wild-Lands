using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnvanterButton : MonoBehaviour,IPointerClickHandler
{
    public EnvanterController envanter;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button==PointerEventData.InputButton.Left)
        {
            //envanter itemi kullan
            envanter.ButtonKullan(gameObject);
            
        }
        else if (eventData.button==PointerEventData.InputButton.Right)
        {
            
                envanter.SatmaButonu(gameObject);

        }
    }
    
}

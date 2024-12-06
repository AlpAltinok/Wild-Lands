using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="items/Available")]
public class Availableitem : Objects
{
   
    public override void Kullan()
    {
        if (itemID == 1)
        {
            CharacterController.aK.SetActive(true);
        }
        else if (itemID == 0)
        {
            HealthBar.health += 40;
        }
        
        Debug.Log("kullanildi");
    }

    public override void Sat()
    {
        if (itemID == 1)
        {

        }
        else if (itemID == 0)
        {
            CharacterController.para += 100;
        }
        else if( itemID == 2)
        {
            CharacterController.para += 25;
        }
        else if (itemID == 3)
        {
            CharacterController.para += 150;
        }
    }
}

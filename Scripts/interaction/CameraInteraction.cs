using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteraction : MonoBehaviour
{
  
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            if(Physics.Raycast(ray,out hitinfo))
            {
                Iinteraction interactable = hitinfo.collider.GetComponent<Iinteraction>();
                if(interactable != null)
                {
                    interactable.Interaction();
                }
            }
        }

      


    }
}

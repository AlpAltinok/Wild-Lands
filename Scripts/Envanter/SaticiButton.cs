using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaticiButton : MonoBehaviour
{
    public GameObject panel;
    public GameObject itemPrefab;
    public Transform spawnPoint;
    public GameObject itemPrefab1;
    public GameObject itemPrefab2;
    public GameObject konusmapanel;
    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            CharacterController.DiyalogPanel = true;
            konusmapanel.SetActive(false);
        }
    }
   
    public void silahalbuton()
    {
        if(CharacterController.para >= 500)
        {
            Debug.Log("item alindi");
            CharacterController.para -= 500;
            GameObject newItem = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
            konusmapanel.SetActive(true);
        }
    }
    public void SifaButon()
    {
        if (CharacterController.para >= 150)
        {
            Debug.Log("item alindi");
            CharacterController.para -= 150;
            GameObject newItem = Instantiate(itemPrefab1, spawnPoint.position, Quaternion.identity);
        }
    }
    public void CephaneButon()
    {
        if (CharacterController.para >= 50)
        {
            Debug.Log("item alindi");
            CharacterController.para -= 50;
            GameObject newItem = Instantiate(itemPrefab2, spawnPoint.position, Quaternion.identity);
        }
    }
    public void panelkapat()
    {
        panel.SetActive(false);
        CharacterController.DiyalogPanel = false;
    }
}

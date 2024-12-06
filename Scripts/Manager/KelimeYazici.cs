using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KelimeYazici : MonoBehaviour
{
    public float delay;
   
    [Multiline]
    public string Text;

    Text thisText;
    private void Start()
    {
        
        thisText = GetComponent<Text>();
        StartCoroutine(TypeWrite());
    }
    IEnumerator TypeWrite()
    {
        foreach(char i in Text)
        {
            thisText.text += i.ToString();
            
            if (i.ToString() == ".") { yield return new WaitForSeconds(1); }
            else { yield return new WaitForSeconds(delay); }
        }
    }
}

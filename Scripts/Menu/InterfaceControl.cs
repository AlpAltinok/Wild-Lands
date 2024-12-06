using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceControl : MonoBehaviour
{
    public GameObject menu;
    private void Start()
    {
        menu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ClosePanel()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }


    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}

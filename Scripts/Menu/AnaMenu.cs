using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AnaMenu : MonoBehaviour
{
    public GameObject gamingPanel;
    public GameObject settingsPanel;
    private void Start()
    {
        gamingPanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }
   
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void AnaMenuDon()
    {
        SceneManager.LoadScene(0);
        gamingPanel.SetActive(false);
        settingsPanel.SetActive(false);

    }
    public void Gaming()
    {
        gamingPanel.SetActive(true);
    }
    public void Settings()
    {
        settingsPanel.SetActive(true);
    }
    public void AnaMenuPanelKapat()
    {
        gamingPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

}

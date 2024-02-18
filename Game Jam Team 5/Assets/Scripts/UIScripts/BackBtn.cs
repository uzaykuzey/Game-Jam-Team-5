using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackBtn : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject ConInfMenu;
    public GameObject CreditsMenu;
    public GameObject SettingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContMBack()
    {
        mainMenu.SetActive(true);
        ConInfMenu.SetActive(false);
    }

    public void CreditsBack()
    {
        mainMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    /*    public void SettingsBack() 
    { 
        Time.timeScale = 1.0f;
        SettingsMenu.SetActive(false);
    }*/
}

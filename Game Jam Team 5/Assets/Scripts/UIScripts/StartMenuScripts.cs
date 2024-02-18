using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScripts : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject ConInfMenu;
    public GameObject CreditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        ConInfMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("tirtil1");
    }

    public void ConInfDisp()
    {
        mainMenu.SetActive(false);
        ConInfMenu.SetActive(true);
    }

    public void CreditsDisp()
    {
        mainMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

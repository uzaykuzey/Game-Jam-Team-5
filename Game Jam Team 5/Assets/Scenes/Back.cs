using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackMenu()
    {
        menu.SetActive(true);
        SceneManager.LoadScene("StartMenu");
    }
}

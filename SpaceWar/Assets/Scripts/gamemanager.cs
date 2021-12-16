using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public GameObject end_game_panel;
  

    private void Awake()
    {
         
    }


    public void show_panel()
    {
        end_game_panel.SetActive(true);

        Invoke("stop", 1f);

        
    }

    void stop()
    {
        Time.timeScale = 0f;
    }

    public void try_again()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Pre_game");

    }

    public void exit()
    {
        Application.Quit();
    }

    
}


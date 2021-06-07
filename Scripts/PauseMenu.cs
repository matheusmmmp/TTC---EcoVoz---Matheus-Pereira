using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject lblScene;
    public static bool GameIsPaused = true;
    public GameObject pausedMenuUi1;
    public GameObject pausedMenuUi2;   
    public int modal = 0; 
  
    void Start()
    {        
        if (PermanentUI.perm.firstTime)
        {            
            modal = 0;
            Pause();
        }
    }

    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKey("joystick button 3"))
        {          
            if (GameIsPaused)
            {
                Resume();
            }
        }
    }


    public void Resume()
    {
        if (modal == 0)
        {
            pausedMenuUi1.SetActive(false);
            lblScene.SetActive(true);
        }
        else if(modal == 1)
        {
            pausedMenuUi2.SetActive(false);
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        if (lblScene ?? true)
        {
            lblScene.SetActive(false);
        }
        if (PermanentUI.perm.firstTime)
        {
            if (modal == 0)
            {           
                pausedMenuUi1.SetActive(true);
            }
            else if (modal == 1)
            {
                pausedMenuUi2.SetActive(true);
            }
            Time.timeScale = 0f;
            GameIsPaused = true;
        }      
    }
}

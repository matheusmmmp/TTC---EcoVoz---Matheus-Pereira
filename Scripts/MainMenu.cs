using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Update()
    {      
        if (Input.GetKey("joystick button 9"))
        {
            PlayGame();
        }
    }

    public void PlayGame()
    {
        PermanentUI.perm.lastCheckPointPos = new Vector2(-7, -1); 
        PermanentUI.perm.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PermanentUI : MonoBehaviour
{
    public int cherries = 0;
    public int health = 5;
    public int savedCherries = 0;
    public Text healthAmount;
    public TextMeshProUGUI collectableNumber;
    public bool firstTime = true;
    public Vector2 lastCheckPointPos;
    public int control = 0;
    public int tentativas = 0;
    public static PermanentUI perm;

    private void Start()
    {     
        DontDestroyOnLoad(gameObject);

        if (!perm)
        {
            perm = this;         
        }
        else
            Destroy(gameObject);
    }


    public void Update()
    {
        //Reset
        if (Input.GetButtonDown("Debug Reset"))
        {
            SceneManager.LoadScene(0);
        }

        //Quit
        if (Input.GetButtonDown("Enable Debug Button 1"))
        {
            SceneManager.LoadScene(4);
        }
    }

    public void Reset()
    {
        tentativas = tentativas + 1;
        health = 5;
        healthAmount.text = health.ToString();
        cherries = savedCherries;
        collectableNumber.text = cherries.ToString();
    }


    public void Controle()
    {
       if(control == 0)
        {
            control = 1;
        }
        else
        {
            control = 0;
        }
    }

}

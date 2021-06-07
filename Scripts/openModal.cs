using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class openModal : MonoBehaviour
{
    [SerializeField] string modal;   
    private PauseMenu goScript; 

    void Start()
    {       
        goScript = (PauseMenu)GameObject.Find("Canvas").GetComponent(typeof(PauseMenu));       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {        
            if (modal.Contains("PanelTutorial"))
            {
                goScript.modal = 0;
            }
            else
            {
                goScript.modal = 1;

            }

            goScript.Pause();           
            Destroy(this);
        }
    }
}

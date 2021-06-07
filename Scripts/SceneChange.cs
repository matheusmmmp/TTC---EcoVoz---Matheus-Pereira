using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
            if (sceneName.Contains("Main"))
            {
                PermanentUI.perm.lastCheckPointPos = new Vector2(-8, -2);
            }
            else if(sceneName.Contains("SecondScene"))
            {
                PermanentUI.perm.lastCheckPointPos = new Vector2(-9, -1);
            }
            else
            {
                PermanentUI.perm.lastCheckPointPos = new Vector2(0,0);
            }
            PermanentUI.perm.firstTime = true;
        }
    }
}

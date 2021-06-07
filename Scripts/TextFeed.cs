using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TextFeed : MonoBehaviour
{
    public TextMeshProUGUI InputFeed;
    public TextMeshProUGUI InputTentativas;

    void Start()
    {
        GameObject collect = GameObject.Find("T");
        InputFeed.text = collect.GetComponent<TextMeshProUGUI>().text;
        InputTentativas.text = PermanentUI.perm.tentativas.ToString();
    }

    public void Restart()
    {
        Application.Quit();
    }

}

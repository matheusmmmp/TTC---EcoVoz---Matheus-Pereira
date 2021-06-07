using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class lblCommand : MonoBehaviour
{
    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnGUI()
    //{
    //    GUIStyle myStyle = new GUIStyle();     
    //    myStyle.fontSize = (int)(40.0f * (float)(Screen.width) / 1920.0f); //scale size font
 
    //}

    public IEnumerator CommandLbl(string palavra)
    {
        txt.text = palavra;
        float originalScale = txt.fontSize;
        float destinationScale = 40.0f;
        float currentTime = 0.0f;

        do
        {
            txt.fontSize = Mathf.Lerp(originalScale, destinationScale, currentTime / 1);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= 1);

        //yield return new WaitForSeconds(1);
        txt.text = "";
        txt.fontSize = 36.0f;
    }

    //IEnumerator ScaleOverTime(float time)
    //{
    //    Vector3 originalScale = Player.transform.localScale;
    //    Vector3 destinationScale = new Vector3(2.0f, 2.0f, 2.0f);

    //    float currentTime = 0.0f;

    //    do
    //    {
    //        Player.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
    //        currentTime += Time.deltaTime;
    //        yield return null;
    //    } while (currentTime <= time);

    //    Destroy(gameObject);
    //}

}

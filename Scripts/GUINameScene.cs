using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUINameScene : MonoBehaviour
{
    [SerializeField] private GameObject lbl;

    void Start()
    {
        StartCoroutine(RemoveLabel());
    }

    IEnumerator RemoveLabel()
    {       
        yield return new WaitForSeconds(1);
        lbl.SetActive(false);
    }


}

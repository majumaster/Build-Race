using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] public GameObject CloudText;
    [SerializeField] Animator animator;
    //public Text textInCloud;
    //public TextMesh textInCloud;
    float activeStart=0f;
    float timeActive = 2f;
    void Update()
    {

        if (animator.GetBool("Hit"))
        {
            CloudText.SetActive(true);
            //SetTextInCloud("Oh no, My boards!!");
            
        }
        else
        {
            CloudText.SetActive(false);
        }
    }
    /*
    public void SetTextInCloud(string text)
    {
        textInCloud.text = text;
    }
    */
}

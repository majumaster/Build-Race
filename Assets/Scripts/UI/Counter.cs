using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] GameObject wallStart;
    public Text text;
    float count = 5f;
    int liczba;

    void Update()
    {
        if (count > 1)
        {
            liczba = (int)count;
            text.text = liczba.ToString();
        }
        else
        {
            if (count < 1.1f && count>0.9f)
            {
                text.text = "GO!";
                audio.Play();
                wallStart.SetActive(false);
            }
            if (count < -1)
            {
                gameObject.SetActive(false);
            }
            
        }
        count -= Time.deltaTime;
    }
}

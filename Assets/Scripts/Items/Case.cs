using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    [SerializeField]GameObject item;
    [SerializeField] GameObject light;

    private void OnTriggerEnter(Collider other)
    { 
        GameEvent.current.CaseTriggerEnter();
        gameObject.SetActive(false);
        light.SetActive(true);
    }

}

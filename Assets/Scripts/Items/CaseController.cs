using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseController : MonoBehaviour
{
    Animation Animation;
    AudioSource AudioSource;
    void Start()
    {
        GameEvent.current.onCaseTriggerEnter += OnCaseOpen;
    }

    void OnCaseOpen()
    {
        Animation = gameObject.GetComponent<Animation>();
        AudioSource = gameObject.GetComponent<AudioSource>();
        Animation.Play();
        AudioSource.Play();
        Debug.Log("sound");
    }
}

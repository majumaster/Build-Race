using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;
    private void Awake()
    {
        current = this;
    }

    public event Action onCaseTriggerEnter;
    public void CaseTriggerEnter()
    {
        if (onCaseTriggerEnter!=null)
        {
            onCaseTriggerEnter();
        }
    }

}

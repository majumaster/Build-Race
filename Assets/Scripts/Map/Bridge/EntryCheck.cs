using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryCheck : MonoBehaviour
{
    [SerializeField] Collider wall;
    private void OnTriggerEnter(Collider other)
    {
        if (wall.isTrigger)
        {
            wall.isTrigger = false;
        }
    }
}

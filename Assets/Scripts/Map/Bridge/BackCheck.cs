using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCheck : MonoBehaviour
{
    [SerializeField] Collider wall;
    private void OnTriggerEnter(Collider other)
    {
        if (wall.isTrigger==false)
        {
            wall.isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (wall.isTrigger == false)
        {
            wall.isTrigger = true;
        }
    }

}

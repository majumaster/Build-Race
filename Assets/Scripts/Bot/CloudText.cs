using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudText : MonoBehaviour
{

    [SerializeField] GameObject bot;
    void Update()
    {
        gameObject.transform.position = bot.transform.position + new Vector3(0.3f, 0.4f, 0);
    }
}

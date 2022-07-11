using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;
    public float speed_=3;
    void FixedUpdate()
    {
        if (Input.GetKey("d"))
        {
            cc.Move(new Vector3(speed_ * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey("a"))
        {
            cc.Move(new Vector3(-speed_ * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey("w"))
        {
            cc.Move(new Vector3(0, 0, speed_ * Time.deltaTime));
        }
        if (Input.GetKey("s"))
        {
            cc.Move(new Vector3(0, 0, -speed_ * Time.deltaTime));
        }
    }
 
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Board"))
        {
            Destroy(hit.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] public GameObject board;
    [SerializeField] protected Animator m_animator;
    Player otherPlayer;
    [SerializeField] PlayerUIController playerUIController;
    protected DataBoards dataBoards = new DataBoards();
    [SerializeField] protected int ID;
    protected int plate_Num=0;
    protected int countBoard_ = 0;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenBoard"))
        {
            countBoard_++;
            //m_animator.SetBool("Pickup", true);
            Destroy(other.gameObject);
            dataBoards.SetCountGreenBoards(dataBoards.GetCountGreenBoards() - 1);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bot"))
        {
            otherPlayer = collision.transform.GetComponent<Player>();
            if (countBoard_ < otherPlayer.GetCountBoard())
            {
                countBoard_ = 0;
                m_animator.SetTrigger("Wave");
                m_animator.SetBool("Hit",true);
                //playerUIController.SetTextInCloud("Oh no, My boards!!");
            }
        }
    }

    public int GetCountBoard()
    {
        return countBoard_;
    }
    public void MinusBoard()
    {
        countBoard_--;
        //Debug.Log(countBoard_);
    }

    public int GetID()
    {
        return ID;
    }
}

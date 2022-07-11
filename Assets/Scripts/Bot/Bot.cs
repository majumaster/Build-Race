using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Player
{
    Player player;
    [SerializeField] EnemyMovement EnemyMovement;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedBoard"))
        {
            countBoard_++;
            dataBoards.RemoveRedFromList(other.transform.position);
            dataBoards.SetCountRedBoards(dataBoards.GetCountRedBoards() - 1);
            Destroy(other.gameObject);
        }
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.transform.GetComponent<Player>();
            if (countBoard_ < player.GetCountBoard())
            {
                countBoard_ = 0;
                EnemyMovement.isBuild = false;
                m_animator.SetTrigger("Wave");
                m_animator.SetBool("Hit", true);

            }
        }
    }
    public void NextLVL()
    {
        plate_Num++;
    }
    public int GetLVL()
    {
        return plate_Num;
    }


}

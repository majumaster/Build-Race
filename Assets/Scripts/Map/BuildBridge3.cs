using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridge3 : MonoBehaviour
{
    Bridge bridge = new Bridge();
    Player player;
    EnemyMovement enemyMovement;
    List<Collider> players = new List<Collider>();
    Vector3 []positionNow = new Vector3[2];
    Vector3 startPosition = new Vector3();
    GameObject[] boards;
    int[] IdBoards;
    int []counts_;


    void Start()
    {
        startPosition = gameObject.transform.position;
        startPosition.z -= 2.5f;
        Debug.Log(bridge.maxBoards+ "bridge.maxBoards");
        IdBoards = new int[12+2];//zamiast 12 wstawic informacje ile max boards
        counts_ = new int[2];//zamiast 2 wstawic informacje ilu graczy
        boards = new GameObject[12 + 2];
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Player>();
        positionNow[player.GetID() - 1] = startPosition;
        counts_[player.GetID() - 1] = 0;
        Debug.Log("wszedl" + other.tag);

    }
    private void OnTriggerStay(Collider other)
    {        
            player = other.GetComponent<Player>();
            if (other.transform.position.z >= positionNow[player.GetID() - 1].z)
            {
                var hitColliders = Physics.OverlapSphere(positionNow[player.GetID() - 1] + new Vector3(0, -0.8f, 0), 0.1f);
                if (player.GetCountBoard() > 0 || IdBoards[counts_[player.GetID() - 1]] == player.GetID())
                {

                    if (hitColliders.Length < 0.1)
                    {
                        Respawn(positionNow[player.GetID() - 1], player.board, counts_[player.GetID() - 1]);
                        player.MinusBoard();
                        IdBoards[counts_[player.GetID() - 1]] = player.GetID();
                    }
                    else
                    {
                        if (IdBoards[counts_[player.GetID() - 1]] != player.GetID())
                        {
                            //destroy aktualny
                            Destroy(boards[counts_[player.GetID() - 1]]);
                            //utwórz nowy
                            player.MinusBoard();
                            Respawn(positionNow[player.GetID() - 1], player.board, counts_[player.GetID() - 1]);
                            IdBoards[counts_[player.GetID() - 1]] = player.GetID();
                        }
                        
                    }
                    positionNow[player.GetID() - 1].z += bridge.boardSize_.z + 0.4f;
                    counts_[player.GetID() - 1] += 1;
                }
                else
                {
                    if (other.CompareTag("Bot"))
                    {
                        enemyMovement = other.GetComponent<EnemyMovement>();
                        enemyMovement.isBuild = false;
                    }
                    else
                    {
                        StopGo(player);
                    }

                }
            }

        
        
    }
    private void OnTriggerExit(Collider other)
    {
        players.Remove(other);
        Debug.Log("wyszedl" + other.tag);
    }

    void StopGo(Player player)
    {
        player.transform.position -= new Vector3(0, 0, 0.1f);
    }
    void Respawn(Vector3 position, GameObject board_, int count)
    {

        boards[count] =((GameObject)Instantiate(board_, position + new Vector3(0f, -0.8f, 0f), new Quaternion(0, 0, 0, 0)));

    }
}

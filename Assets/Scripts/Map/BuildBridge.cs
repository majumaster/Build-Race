using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridge : MonoBehaviour
{
    Bridge bridge= new Bridge();
    Player player;
    Vector3 position= new Vector3();
    List<GameObject> boardsList = new List<GameObject>();

    void Start()
    {
        position = gameObject.transform.position;
        position.z -= bridge.bridgeSize_.z / 2;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        player = other.GetComponent<Player>();
        if (player.GetCountBoard() > 0)
        {
            //if (boardsList.Count<=bridge.maxBoards)
            //{
                Build();
            //}
        
        }
    }
    void Build()
    {
        if (Respawn(position, player.board))
        {
            position.z += bridge.boardSize_.z+0.3f;
            gameObject.transform.position = position;
            player.MinusBoard();
        }
    }
    bool Respawn(Vector3 position, GameObject board_)
    {
        var hitColliders = Physics.OverlapSphere(position+new Vector3(0,-0.7f,0), 0.1f);


        if (hitColliders.Length < 0.1)
        {
            boardsList.Add((GameObject)Instantiate(board_, position + new Vector3(0f, -0.6f, 0f), new Quaternion(0, 0, 0, 0)));
            return true;
        }
        return false;
    }
}

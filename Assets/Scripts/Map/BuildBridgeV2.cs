using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBridgeV2 : MonoBehaviour
{

    Bridge bridge = new Bridge();
    Player player;   
    List<GameObject> boardsList = new List<GameObject>();
    int count = 0;
    Vector3 positionNow=new Vector3();
    Vector3 startPosition = new Vector3();


    void Start()
    {
        startPosition = gameObject.transform.position;
        startPosition.z -= bridge.bridgeSize_.z/2;
        positionNow = startPosition;
        Debug.Log(startPosition);
    }
   


    private void OnTriggerStay(Collider collider)
    {

        player = collider.GetComponent<Player>();
        if (Mathf.Abs(positionNow.z - player.transform.position.z) > bridge.boardSize_.z)
        {
            positionNow.z += bridge.boardSize_.z;
            count++;
        }

        var hitColliders = Physics.OverlapSphere(positionNow + new Vector3(0, -1.3f, 0), 0.1f);

        if (hitColliders.Length < 0.1 && player.GetCountBoard() > 0)
        {
            Respawn(positionNow, player.board);
        }
        else
        {
            GoBack(player);
        }

    }
    
    void Respawn(Vector3 position, GameObject board_)
    {
       
       boardsList.Add((GameObject)Instantiate(board_, position + new Vector3(0f, -1.2f, 0f), new Quaternion(0, 0, 0, 0)));

    }
    void GoBack(Player player)
    {
        player.transform.position -= new Vector3(0, 0, 0.1f);
    }
}

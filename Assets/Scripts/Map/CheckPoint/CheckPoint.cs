using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] GameObject plane;
    Spawner spawner;
    DataBoards dataBoards = new DataBoards();
    Bot bot;
    private void Start()
    {
        spawner = plane.GetComponent<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            if (spawner.IsPlayer())
            {
                StopGo(other);
            }
            spawner.PlayerIn();
            dataBoards.SetCountGreenBoards(0);
        }
        if (other.CompareTag("Bot"))
        {
            if (spawner.IsBot())
            {
                StopGo(other);
            }
            spawner.BotIn();
            dataBoards.SetCountRedBoards(0);
            bot = other.GetComponent<Bot>();
            bot.NextLVL();
        }
    }
    void StopGo(Collider other)
    {
        other.transform.position += new Vector3(0, 0, 0.1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPoint : MonoBehaviour
{
    [SerializeField] Image winnerImage;
    [SerializeField] Text winnerText;
    [SerializeField] Image loserImage;
    [SerializeField] Text loserText;
    [SerializeField] GameObject finishGraphic;
    EnemyMovement bot;
    int count = 1;
    bool playerIsFinish_ = false;
    bool enemyIsFinish_ = false;
    bool isEND=false;


    private void OnTriggerEnter(Collider other)
    {
        if (isEND == false)
        {
            finishGraphic.SetActive(true);
            isEND = true;
        }
        if(playerIsFinish_&& enemyIsFinish_)
        {
            //koniec lvl
        }
        if (other.CompareTag("Player"))
        {
            if (!playerIsFinish_)
            {
                if (count % 2 != 0)
                {
                    winnerText.text = 1 + " player";
                    count++;
                }
                else
                {
                    loserText.text = 2 + " player";
                }
                playerIsFinish_ = true;
            }
            else
            {
                StopGo(other);
            }
        }
        if (other.CompareTag("Bot"))
        {
            if (!enemyIsFinish_)
            {
                bot = other.GetComponent<EnemyMovement>();
                bot.isEnd = true;
                if (count % 2 != 0)
                {
                    winnerText.text = 1 + " bot";
                    count++;
                }
                else
                {
                    loserText.text = 2 + " bot";
                }
                enemyIsFinish_ = true;
            }
            else
            {
                StopGo(other);
            }
        }
    }

    void StopGo(Collider other)
    {
        other.transform.position += new Vector3(0, 0, 0.1f);
    }
}

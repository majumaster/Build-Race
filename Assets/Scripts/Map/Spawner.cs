using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject greenBoard;
    [SerializeField] GameObject redBoard;
    DataBoards dataBoards;
    Vector3 planeSize_;
    Vector3 boardSize_;
    Vector3 boardSize2_;
    float timeCheck = 0f;
    int maxBoards;
    int maxBoards2;
    int halfBoards;
    int los;
    int createRed = 0;
    int createGreen = 0;
    [SerializeField] bool isPlayer;
    [SerializeField] bool isBot;
    void Start()
    {
        dataBoards = new DataBoards();
        planeSize_ = GetComponent<Collider>().bounds.size;
        boardSize2_ = greenBoard.GetComponent<Collider>().bounds.size;
        boardSize_ = new Vector3(1, 0.16f, 0.4f);
        maxBoards2 = (int)(((planeSize_.x- boardSize_.x*2) / (boardSize_.x+1)) * ((planeSize_.z- boardSize_.z*2) / (boardSize_.z+0.6f)));
        maxBoards = 58;
        halfBoards = 18;


    }
    
    void Update()
    {
        ///*
        if (Time.time >= timeCheck)
        {
            Spawning();

            timeCheck = Time.time + 5f;

        }
        //*/
        /*
        if (Time.time >= timeCheck)
        {
            SpawningV2();

            timeCheck = Time.time + 5f;

        }
        */
    }

    void Spawning()
    {
        Vector3 position=gameObject.transform.position - planeSize_/2 + new Vector3(0,0.5f, 0);
        for(int i=0; i < maxBoards; i++)
        {   
            if(gameObject.transform.position.x + planeSize_.x / 2 - position.x  > 1)
            {
                los = Random.Range(0, 2);
                if (gameObject.transform.position.z + planeSize_.z / 2 - position.z  < 1)
                {
                    position.x += boardSize_.x + 1f;
                    position.z = gameObject.transform.position.z - planeSize_.z / 2 ;
                }
                else
                {
                    if (isBot && los == 0 && dataBoards.GetCountRedBoards() < halfBoards)
                    {
                        if(Respawn(position, redBoard))
                        {
                            dataBoards.SetCountRedBoards(dataBoards.GetCountRedBoards() + 1);
                            dataBoards.AddRedToList(position);
                        }
                        
                            
                    }
                    else
                    {
                        if (isPlayer && dataBoards.GetCountGreenBoards()< halfBoards)
                        {
                            if(Respawn(position, greenBoard))
                                dataBoards.SetCountGreenBoards(dataBoards.GetCountGreenBoards() + 1);
                            
                        }
                        else
                        {
                            if (isBot && dataBoards.GetCountRedBoards() < halfBoards)
                            {
                                if(Respawn(position, redBoard))
                                {
                                    dataBoards.SetCountRedBoards(dataBoards.GetCountRedBoards() + 1);
                                    dataBoards.AddRedToList(position);
                                }

                            }
                        }
                    }
                    //Respawn(position, GreenBoard);
                    position.z += boardSize_.z+0.6f;
                }
            }
            
        }
    }
    void SpawningV2()
    {
        Vector3 position = gameObject.transform.position - planeSize_ / 2 + new Vector3(0f, 0.5f, 0f);
        //createRed = dataBoards.GetCountRedBoards();
        //createGreen = dataBoards.GetCountGreenBoards();

        while (createRed < halfBoards  || createGreen < halfBoards)
        {
            if (gameObject.transform.position.x + planeSize_.x / 2 - position.x > 1)
            {
                los = Random.Range(0, 2);
                if (gameObject.transform.position.z + planeSize_.z / 2 - position.z < 1)
                {
                    position.x += boardSize_.x + 1;
                    position.z = gameObject.transform.position.z - planeSize_.z / 2;
                }
                else
                {
                    if (isBot && los == 0 && dataBoards.GetCountRedBoards() < halfBoards)
                    {
                        if (Respawn(position, redBoard))
                        {
                            dataBoards.SetCountRedBoards(dataBoards.GetCountRedBoards() + 1);
                            dataBoards.AddRedToList(position);
                            
                        }

                    }
                    
                    if (isPlayer && los == 1 && dataBoards.GetCountGreenBoards() < halfBoards)
                    {
                        if (Respawn(position, greenBoard))
                        {
                            dataBoards.SetCountGreenBoards(dataBoards.GetCountGreenBoards() + 1);
                            
                        }
                            
                    }
                        
                    
                    //Respawn(position, GreenBoard);
                    position.z += boardSize_.z;
                }
            }
            else
            {
                position = gameObject.transform.position - planeSize_ / 2 + new Vector3(0f, 0.5f, 0f);
            }

        }
        
    }
    public bool Respawn(Vector3 position, GameObject board_)
    {
        var hitColliders = Physics.OverlapSphere(position, 0.1f);


        if (hitColliders.Length < 0.1)
        {
            Instantiate(board_, position, new Quaternion(0, 0, 0, 0));
            return true;
        }
        return false;
    }
           
    public void PlayerIn()
    {
        isPlayer = true;
    }
    public void BotIn()
    {
        isBot = true;
    }
    public bool IsPlayer()
    {
        return isPlayer;
    }
    public bool IsBot()
    {
        return isBot;
    }
}

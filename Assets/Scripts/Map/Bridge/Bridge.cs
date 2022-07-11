using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] GameObject board;
    public Vector3 bridgeSize_;
    public Vector3 boardSize_;
    public int maxBoards;
    void Start()
    {
        bridgeSize_ = GetComponent<Collider>().bounds.size;
        boardSize_ = board.GetComponent<Collider>().bounds.size;
        maxBoards = (int)(bridgeSize_.z/ 0.4);

        
        Debug.Log(maxBoards+ "  maxBoards");
    }
    
}

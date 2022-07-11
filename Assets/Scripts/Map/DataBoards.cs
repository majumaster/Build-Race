using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBoards : MonoBehaviour
{
    static List<Vector3> redPositions = new List<Vector3>();
    static int redBoards_=0;
    static int greenBoards_ = 0;

    void Start()
    {
        redBoards_ = 0;
        greenBoards_ = 0;
        redPositions.Clear();
    }
    public void ResetData()
    {
        redBoards_ = 0;
        greenBoards_ = 0;
        redPositions.Clear();
    }
    public void SetCountRedBoards(int i)
    {
        redBoards_ = i;
    }
    public void SetCountGreenBoards(int i)
    {
        greenBoards_ = i;
    }
    public int GetCountRedBoards()
    {
        return redBoards_;
    }
    public int GetCountGreenBoards()
    {
        return greenBoards_;
    }

    public void AddRedToList(Vector3 vector3)
    {
        redPositions.Add(vector3);
    }
    public void RemoveRedFromList(Vector3 vector3)
    {
        redPositions.Remove(vector3);
    }
    public int GetCountFromList()
    {
        return redPositions.Count;
    }

    public Vector3 GetPosition(int i)
    {
        return redPositions[i];
    }
}

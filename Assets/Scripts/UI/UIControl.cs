using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] Text greenCount;
    [SerializeField] Text redCount;
    [SerializeField] Player player;
    [SerializeField] Player Bot;
    void Update()
    {
        greenCount.text = "x " +player.GetCountBoard();
        redCount.text = "x " + Bot.GetCountBoard();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    bool isPaused = false;
    PauzeMenu PauzeMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                pauseMenu.SetActive(true);
                isPaused = true;
                Time.timeScale = 0f;
            }
            else
            {
                pauseMenu.SetActive(false);
                isPaused = false;
                Time.timeScale = 1f;
                PauzeMenu=pauseMenu.GetComponent<PauzeMenu>();
                PauzeMenu.OffOptions();
            }
        }
    }
}

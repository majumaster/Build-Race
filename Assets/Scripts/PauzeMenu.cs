using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzeMenu : MonoBehaviour
{
    DataBoards DataBoards = new DataBoards();
    [SerializeField] GameObject options;
    bool isOnOptions = false;
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        DataBoards.ResetData();
        OffOptions();
    }
    public void Options()
    {
        if (isOnOptions == false)
        {
            options.SetActive(true);
            isOnOptions = true;
        }
        else
        {
            OffOptions();
        }

    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        OffOptions();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void OffOptions()
    {
        isOnOptions = false;
        options.SetActive(false);
    }
}

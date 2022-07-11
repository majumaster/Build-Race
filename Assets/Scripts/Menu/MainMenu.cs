using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu:MonoBehaviour
{
    DataBoards DataBoards = new DataBoards();
    [SerializeField] GameObject options;
    bool isOnOptions=false;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
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

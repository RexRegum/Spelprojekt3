using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int levelToLoad;


    public void StartButton()
    {   
        SceneManager.LoadScene(levelToLoad);
    }

    public void QuitButton()
    {
        Application.Quit();
        print("Oh no, you quit the game!");
    }

}

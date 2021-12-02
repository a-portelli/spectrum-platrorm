using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public GameObject pauseButton;

    public Text pauseText;
    public static bool GameIsPaused = false;

    public void onClickPause()
    {
        GameIsPaused = !GameIsPaused;
        if(GameIsPaused == true)
        {
            pauseText.text = "Resume";
            gamePause();
        }
        else
        {
            pauseText.text = "Pause";
            Resume();
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("RESUME");
    }

    public void gamePause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("PAUSE");
    }
}

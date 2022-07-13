using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;

    public void Pause()
    {
        if (GamePaused == false)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }
        else
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GamePaused = false;
        }
    }

    public void MenuButton()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

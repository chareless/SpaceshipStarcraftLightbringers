using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject quitButton;
    public float timer;
    public GameObject gameSound;
    public GameObject loseSound;
    public GameObject waveSpawner;
    public GameObject coinSpawner;
    void Start()
    {
        Destroy(gameSound);
        waveSpawner.SetActive(false);
        coinSpawner.SetActive(false);
        loseSound.SetActive(true);
        timer = 2f;
        PlayerPrefs.SetInt("TotalPlay", (PlayerPrefs.GetInt("TotalPlay") + 1));
        PlayerPrefs.SetInt("Coin", (PlayerPrefs.GetInt("Coin") + Status.coins));
        PlayerPrefs.SetInt("TotalKill", (PlayerPrefs.GetInt("TotalKill") + Status.totalKill));
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            menuButton.SetActive(true);
            quitButton.SetActive(true);
        }
       
    }
}

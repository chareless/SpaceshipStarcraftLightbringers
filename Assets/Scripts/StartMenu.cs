using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject DefaultCanvas;
    public GameObject MainCanvas;
    public GameObject SettingsCanvas;
    public GameObject ShopDefaultCanvas;
    public GameObject ShopMainCanvas;
    public GameObject ShopBullet1Canvas;
    public GameObject ShopBullet2Canvas;
    public GameObject ShopBullet3Canvas;
    public GameObject ShopSkinCanvas;
    public GameObject SelectCanvas;
    public GameObject SelectHeroCanvas;
    public GameObject SelectBulletCanvas;
    public GameObject QuitCanvas;
    public GameObject LoadingCanvas;

    public AudioSource clickSound;
    public AudioSource gameMusic;
    public AudioClip nextClip;
    public AudioClip backClip;
    public AudioClip purchase;
    public AudioClip cancel;

    public Slider mainSlider;
    public Slider musicSlider;
    public TextMeshProUGUI mainVolumeText;
    public TextMeshProUGUI musicVolumeText;
    public static float volumeValue;
    public static float musicValue;

    public Text versionText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI coinText;

    public static string ownHeroes;
    public static string[] myHeroes= new string[6];
    public static int maxHeroCount = 5;
    public static string ownBullets;
    public static string[] myBullets = new string[16];
    public static int maxBulletCount = 15;
    public static int totalPlay;
    public static int coin;
    public static int highscore;

    public bool startClicked;
    public float timer;

    public GameObject[] bulletWindows;
    public Button[] bulletWindowsButton;
    public SpriteRenderer[] bulletSprites;
    public TextMeshProUGUI[] bulletNames;
    public TextMeshProUGUI[] bulletPricesText;
    public Sprite[] bullets;
    public int[] bulletPrices;

    public GameObject[] heroWindows;
    public Button[] heroWindowsButton;
    public SpriteRenderer[] heroSprites;
    public TextMeshProUGUI[] heroNames;
    public TextMeshProUGUI[] heroPricesText;
    public Sprite[] heroes;
    public int[] heroPrices;

    public static int selectedHero;
    public static int selectedBullet;
    public SpriteRenderer selectedBulletSprite;
    public SpriteRenderer selectedHeroSprite;
    public Button startButton;


    public GameObject[] selectBulletWindows;
    public Button[] selectBulletWindowsButton;
    public SpriteRenderer[] selectBulletSprites;

    public GameObject[] selectHeroWindows;
    public Button[] selectHeroWindowsButton;
    public SpriteRenderer[] selectHeroSprites;

    void Start()
    {
        timer = 0.1f;
        LoadValues();
        ObjectInitialize();
        highscoreText.text = "HIGHSCORE : " + highscore;
        coinText.text = "COIN : " + coin + " C";
        versionText.text = Application.version;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

    void PlayNextButtonSound()
    {
        clickSound.PlayOneShot(nextClip);
    }
    void PlayBackButtonSound()
    {
        clickSound.PlayOneShot(backClip);
    }
    void PlayPurchaseButtonSound()
    {
        clickSound.PlayOneShot(purchase);
    }
    void PlayCancelButtonSound()
    {
        clickSound.PlayOneShot(cancel);
    }

    public void PlayGame()
    {
        MainCanvas.SetActive(false);
        SelectCanvas.SetActive(true);
        PlayNextButtonSound();
    }
    public void SelectHeroButton()
    {
        SelectCanvas.SetActive(false);
        SelectHeroCanvas.SetActive(true);
        PlayNextButtonSound();
    }
    public void SelectBulletButton()
    {
        SelectCanvas.SetActive(false);
        SelectBulletCanvas.SetActive(true);
        PlayNextButtonSound();
    }
    public void QuitButton()
    {
        QuitCanvas.SetActive(true);
        PlayBackButtonSound();
    }
    public void QuitGame()
    {
        PlayBackButtonSound();
        Application.Quit();
    }
    public void CancelQuit()
    {
        QuitCanvas.SetActive(false);
        PlayNextButtonSound();
    }
    public void Options()
    {
        SettingsCanvas.SetActive(true);
        MainCanvas.SetActive(false);
        PlayNextButtonSound();
    }
    public void OpenWebSite()
    {
        PlayNextButtonSound();
        Application.OpenURL("http://saribayirdeniz.cf/spaceshipstarcraft2.html");
    }
    public void OpenStoreLink()
    {
        PlayNextButtonSound();
        //Application.OpenURL("https://play.google.com/store/apps/details?id=com.saribayirdeniz.SpaceshipStarcraftLightbringers");
    }

    public void OpenShop()
    {
        ShopDefaultCanvas.SetActive(true);
        ShopMainCanvas.SetActive(true);
        MainCanvas.SetActive(false);
        DefaultCanvas.SetActive(false);
        PlayNextButtonSound();
    }
    public void OpenHeroShop()
    {
        ShopMainCanvas.SetActive(false);
        ShopBullet1Canvas.SetActive(false);
        ShopBullet2Canvas.SetActive(false);
        ShopBullet3Canvas.SetActive(false);
        ShopSkinCanvas.SetActive(true);
        PlayNextButtonSound();
    }
    public void OpenBulletShop()
    {
        ShopMainCanvas.SetActive(false);
        ShopSkinCanvas.SetActive(false);
        ShopBullet1Canvas.SetActive(true);
        ShopBullet2Canvas.SetActive(false);
        ShopBullet3Canvas.SetActive(false);
        PlayNextButtonSound();
    }

    public void NextBulletShop()
    {
        if (ShopBullet1Canvas.activeInHierarchy == true)
        {
            ShopBullet1Canvas.SetActive(false);
            ShopBullet2Canvas.SetActive(true);
            ShopBullet3Canvas.SetActive(false);
            PlayNextButtonSound();
        }
        else if (ShopBullet2Canvas.activeInHierarchy == true)
        {
            ShopBullet2Canvas.SetActive(false);
            ShopBullet1Canvas.SetActive(false);
            ShopBullet3Canvas.SetActive(true);
            PlayNextButtonSound();
        }
        else if (ShopBullet3Canvas.activeInHierarchy == true)
        {
            ShopBullet2Canvas.SetActive(false);
            ShopBullet1Canvas.SetActive(true);
            ShopBullet3Canvas.SetActive(false);
            PlayNextButtonSound();
        }
    }
    public void BackBulletShop()
    {
        if (ShopBullet1Canvas.activeInHierarchy == true)
        {
            ShopBullet1Canvas.SetActive(false);
            ShopBullet2Canvas.SetActive(false);
            ShopBullet3Canvas.SetActive(true);
            PlayBackButtonSound();
        }
        else if (ShopBullet2Canvas.activeInHierarchy == true)
        {
            ShopBullet2Canvas.SetActive(false);
            ShopBullet1Canvas.SetActive(true);
            ShopBullet3Canvas.SetActive(false);
            PlayBackButtonSound();
        }
        else if (ShopBullet3Canvas.activeInHierarchy == true)
        {
            ShopBullet2Canvas.SetActive(true);
            ShopBullet1Canvas.SetActive(false);
            ShopBullet3Canvas.SetActive(false);
            PlayBackButtonSound();
        }
    }

    void ObjectInitialize()
    {
        AddBulletButtonsListeners();
        AddHeroButtonsListeners();
        AddSelectHeroButtonsListeners();
        AddSelectBulletButtonsListeners();


        for (int i = 0; i < bullets.Length; i++)
        {
            bulletSprites[i].sprite = bullets[i];
            bulletNames[i].text = bullets[i].name;
        }

        for (int i = 0; i < bulletWindows.Length; i++)
        {
            if (i >= bullets.Length)
            {
                Destroy(bulletWindows[i]);
            }
        }

        for (int i = 0; i < bulletPrices.Length; i++)
        {
            bulletPricesText[i].text = bulletPrices[i] + " C";
            if (bulletWindowsButton[i].interactable == false)
            {
                bulletPricesText[i].text = "";
            }
        }


        for (int i = 0; i < heroes.Length; i++)
        {
            heroSprites[i].sprite = heroes[i];
            heroNames[i].text = heroes[i].name;
        }

        for (int i = 0; i < heroWindows.Length; i++)
        {
            if (i >= heroes.Length)
            {
                Destroy(heroWindows[i]);
            }
        }

        for (int i = 0; i < heroPrices.Length; i++)
        {
            heroPricesText[i].text = heroPrices[i] + " C";
            if (heroWindowsButton[i].interactable == false)
            {
                heroPricesText[i].text = "";
            }
        }


        for (int i = 0; i < bullets.Length; i++)
        {
            selectBulletSprites[i].sprite = bullets[i];
        }

        for (int i = 0; i < heroes.Length; i++)
        {
            selectHeroSprites[i].sprite = heroes[i];
        }
    }

    public void AddBulletButtonsListeners()
    {
        for (int index = 0; index < bullets.Length; ++index)
        {
            if (bulletWindows[index] != null)
                AddBulletButtonListener(bulletWindowsButton[index], index);
        }
    }
    public void AddSelectBulletButtonsListeners()
    {
        for (int index = 0; index < bullets.Length; ++index)
        {
            if (selectBulletWindows[index] != null)
                AddSelectBulletButtonListener(selectBulletWindowsButton[index], index);
        }
    }
    public void AddHeroButtonsListeners()
    {
        for (int index = 0; index < heroes.Length; ++index)
        {
            if (heroWindows[index] != null)
                AddHeroButtonListener(heroWindowsButton[index], index);
        }
    }
    public void AddSelectHeroButtonsListeners()
    {
        for (int index = 0; index < heroes.Length; ++index)
        {
            if (selectHeroWindows[index] != null)
                AddSelectHeroButtonListener(selectHeroWindowsButton[index], index);
        }
    }
    public void AddBulletButtonListener(Button button, int index)
    {
        button.onClick.AddListener(() =>
        {
            if(coin >= bulletPrices[index])
            {
                PlayPurchaseButtonSound();
                ownBullets += "b" + (index + 1);
                coin -= bulletPrices[index];
                PlayerPrefs.SetInt("Coin", coin);
                PlayerPrefs.SetString("Bullets", ownBullets);
                PlayerPrefs.Save();
                LoadValues();
            }
            else
            {
                PlayCancelButtonSound();
            }
            
        });
    }
    public void AddHeroButtonListener(Button button, int index)
    {
        button.onClick.AddListener(() =>
        {
            if (coin >= heroPrices[index])
            {
                PlayPurchaseButtonSound();
                ownHeroes += "h" + (index + 1);
                coin -= heroPrices[index];
                PlayerPrefs.SetInt("Coin", coin);
                PlayerPrefs.SetString("Heroes", ownHeroes);
                PlayerPrefs.Save();
                LoadValues();
            }
            else
            {
                PlayCancelButtonSound();
            }

        });
    }
    public void AddSelectBulletButtonListener(Button button, int index)
    {
        button.onClick.AddListener(() =>
        {
            selectedBullet = index+1;
            selectedBulletSprite.sprite=bullets[index];
            selectedBulletSprite.transform.localScale = new Vector3(10, 10, 0);
            SelectBulletCanvas.SetActive(false);
            SelectCanvas.SetActive(true);
            PlayNextButtonSound();
        });
    }
    public void AddSelectHeroButtonListener(Button button, int index)
    {
        button.onClick.AddListener(() =>
        {
            selectedHero = index + 1;
            selectedHeroSprite.sprite = heroes[index];
            selectedHeroSprite.transform.localScale = new Vector3(20, 20, 0);
            SelectHeroCanvas.SetActive(false);
            SelectCanvas.SetActive(true);
            PlayNextButtonSound();
        });
    }

    public void BackButton()
    {
        MainCanvas.SetActive(true);
        DefaultCanvas.SetActive(true);
        SelectCanvas.SetActive(false);
        SelectHeroCanvas.SetActive(false);
        SelectBulletCanvas.SetActive(false);
        ShopDefaultCanvas.SetActive(false);
        ShopMainCanvas.SetActive(false);
        ShopSkinCanvas.SetActive(false);
        ShopBullet1Canvas.SetActive(false);
        ShopBullet2Canvas.SetActive(false);
        ShopBullet3Canvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        QuitCanvas.SetActive(false);
        PlayBackButtonSound();
    }
    public void SaveButton()
    {
        volumeValue = mainSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", volumeValue);
        musicValue = musicSlider.value;
        PlayerPrefs.SetFloat("MusicValue", musicValue);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("ChangeValues", 1);
        LoadValues();
        SettingsCanvas.SetActive(false);
        MainCanvas.SetActive(true);
        DefaultCanvas.SetActive(true);
        PlayNextButtonSound();
    }

    public void SaveDataButton()
    {
        FileSave.SaveFile();
        MainCanvas.SetActive(true);
        DefaultCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
        PlayNextButtonSound();
    }
    public void LoadDataButton()
    {
        FileSave.LoadFile();
        MainCanvas.SetActive(true);
        DefaultCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
        PlayNextButtonSound();
    }

    public void MainSlider(float volume)
    {
        mainVolumeText.text = "Main Volume : " + (volume * 100).ToString("F0");
    }
    public void MusicSlider(float volume)
    {
        musicVolumeText.text = "Music Volume : " + (volume * 100).ToString("F0");
    }

    public void VolumeControl()
    {
        if (PlayerPrefs.GetInt("ChangeValues") == 1)
        {
            volumeValue = PlayerPrefs.GetFloat("VolumeValue");
            mainSlider.value = volumeValue;
            AudioListener.volume = volumeValue;
        }
        else
        {
            volumeValue = 1;
            mainSlider.value = volumeValue;
            AudioListener.volume = volumeValue;
        }

    }
    public void MusicControl()
    {
        if (PlayerPrefs.GetInt("ChangeValues") == 1)
        {
            musicValue = PlayerPrefs.GetFloat("MusicValue");
            musicSlider.value = musicValue;
            gameMusic.volume = musicValue;
        }
        else
        {
            musicValue = 1;
            musicSlider.value = musicValue;
            gameMusic.volume = musicValue;
        }

    }
    public void ScoreControl()
    {
        if (PlayerPrefs.GetInt("Highscore") > 0)
        {
            highscore = PlayerPrefs.GetInt("Highscore");
        }
        else
        {
            highscore=0;
        }

        highscoreText.text = "HIGHSCORE : " + highscore;
    }
    public void TotalPlayedControl()
    {
        if (PlayerPrefs.GetInt("TotalPlay") > 0)
        {
            totalPlay = PlayerPrefs.GetInt("TotalPlay");
        }
        else
        {
            totalPlay = 0;
        }
    }
    public void MoneyControl()
    {
        if (PlayerPrefs.GetInt("Coin") > 0)
        {
            coin = PlayerPrefs.GetInt("Coin");
        }
        else
        {
            coin = 0;
        }

        coinText.text = "COIN : " + coin + " C";
    }
    public void BulletControl()
    {
        if (PlayerPrefs.GetString("Bullets") != "")
        {
            ownBullets = PlayerPrefs.GetString("Bullets");
        }
        else
        {
            ownBullets = "b1b2";
        }

        string[] temp = ownBullets.Split('b');
        int count = 0;
        foreach (string s in temp)
        {
            myBullets[count] = s;
            count++;
        }
        for (int i = 1; i <= maxBulletCount; i++)
        {
            for (int j = 0; j < maxBulletCount; j++)
            {
                if (i.ToString() == (myBullets[j]))
                {
                    bulletWindowsButton[i - 1].interactable = false;
                    selectBulletWindows[i - 1].SetActive(true);
                }
            }
        }
    }
    public void SkinControl()
    {
        if (PlayerPrefs.GetString("Heroes") != "")
        {
            ownHeroes = PlayerPrefs.GetString("Heroes");
        }
        else
        {
            ownHeroes = "h1";
        }

        string[] temp = ownHeroes.Split('h');
        int count = 0;
        foreach (string s in temp)
        {
            myHeroes[count] = s;
            count++;
        }
        for (int i = 1; i <= maxHeroCount; i++)
        {
            for (int j = 0; j < maxHeroCount; j++)
            {
                if (i.ToString() == (myHeroes[j]))
                {
                    heroWindowsButton[i - 1].interactable = false;
                    selectHeroWindows[i - 1].SetActive(true);
                }
            }
        }
    }

    void LoadValues()
    {
        VolumeControl();
        MusicControl();
        ScoreControl();
        TotalPlayedControl();
        MoneyControl();
        BulletControl();
        SkinControl();
    }

    void BackControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (QuitCanvas.activeInHierarchy == false)
            {
                QuitCanvas.SetActive(true);
            }
            else
            {
                QuitCanvas.SetActive(false);
            }
        }
    }
    void StartControl()
    {
        if(selectedBullet >0 && selectedHero >0)
        {
            startButton.interactable = true;
        }
        if (startClicked == true)
        {
            Status.selectedBullet = selectedBullet;
            Status.selectedHero = selectedHero;
            LoadingCanvas.SetActive(true);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    void Update()
    {
        BackControl();
        StartControl();
    }
}

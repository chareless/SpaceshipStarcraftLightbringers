using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int maxHealth;
    public static int health;
    public static int coins;
    public static float attackSpeed;
    public static string type;
    public static bool isAlive;
    public static int score;
    public static bool takeKill;
    public static int totalKill;
    public GameObject[] healthBars;
    public GameObject bullet;
    public GameObject hero;
    public GameObject[] bullets;
    public GameObject[] heroes;

    public static int selectedHero;
    public static int selectedBullet;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinText;

    public Transform firePoint;

    Rigidbody2D rb;

    public GameObject gameOverCanvas;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        InvokeRepeating("PointsTime", 0f, 0.015f);
        isAlive = true;
        coins = 0;
        totalKill = 0;
        attackSpeed = 1.5f;
        health = maxHealth;
        StartControl();
    }

    void StartControl()
    {
        //selectedBullet = StartMenu.selectedBullet;
        //selectedHero = StartMenu.selectedHero;
        selectedBullet = 1;
        selectedHero = 1;
        bullet = bullets[selectedBullet-1];
        hero = heroes[selectedHero-1];
        for(int i = 0; i < heroes.Length; i++)
        {
            if(i+1 != selectedHero)
            {
                Destroy(heroes[i]);
            }
        }
       
    }

    void HealthControl()
    {
        if(health<=0)
        {
            health = 0;
            isAlive=false;
            //ölüm animasyonu
            gameOverCanvas.SetActive(true);
        }
        else
        {
            if(health>maxHealth)
            {
                health=maxHealth;
            }
            isAlive=true;
        }

        for (int i = 0; i < maxHealth; i++)
        {
            if (i < health)
            {
                healthBars[i].SetActive(true);
            }
            else
            {
                healthBars[i].SetActive(false);
            }
        }
    }

    void KillControl()
    {
        if(takeKill==true && isAlive)
        {
            ScorePoints(200);
            totalKill++;
            takeKill =false;
        }
    }

    void ScorePoints(int points)
    {
        score += points * (BottomSpawner.difLevel + 1);
        if (score <= 0)
        {
           score = 0;
        }
    }
    public void PointsTime()
    {
        if (isAlive)
        {
            score += (BottomSpawner.difLevel + 1);
        }
        scoreText.text = "Score : " + score.ToString();
    }

    void TakeDamage(int damage)
    {
        health -= damage;
    }

    void EarnCoin(int coin)
    {
        coins += coin;
        coinText.text = " : " + coin.ToString();
    }

    public void Jump()
    {

    }

    public void Shoot()
    {

    }

    void Update()
    {
        HealthControl();
        KillControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive)
        {
            if (collision.gameObject.tag == "EnemyHead" || collision.gameObject.tag == "EnemyEye" || collision.gameObject.tag == "EnemySlime"
            || collision.gameObject.tag == "EnemyWorm" || collision.gameObject.tag == "EnemyCannon")
            {
                TakeDamage(1);
                ScorePoints(-500);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Coin")
            {
                EarnCoin(1);
                ScorePoints(1000);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "EnemyBullet")
            {
                TakeDamage(1);
                ScorePoints(-20);
                Destroy(collision.gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int damage;
    public static int coins;
    public float attackSpeed;
    public static string type;
    public static bool isAlive;
    public static int score;
    public static float gameSpeed;
    public static float gameTime;
    public static int gameLevel;
    public static bool takeKill;
    public static int totalKill;
    GameObject[] healthBars;
    GameObject bullet;

    public static int selectedHero;
    public static int selectedBullet;
    void Start()
    {
        Application.targetFrameRate = 60;
        isAlive = true;
        coins = 0;
        gameTime = 0;
        gameLevel = 1;
        gameSpeed = 10;
        totalKill = 0;
    }

    void HealthControl()
    {
        if(health<=0)
        {
            health = 0;
            isAlive=false;
            //ölüm animasyonu
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
        if(takeKill==true)
        {
            ScorePoints(100);
            totalKill++;
            takeKill =false;
        }
    }

    void TimeTicking()
    {
        gameTime += Time.deltaTime;
    }

    void LevelControl()
    {
        if(gameTime>100)
        {
            gameLevel++;
            gameSpeed += 5;
            gameTime = 0;
        }
    }

    void ScorePoints(int points)
    {
        score += points*gameLevel;
        if(score<=0)
        {
            score = 0;
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
    }

    void EarnCoin(int coin)
    {
        coins += coin;
    }

    void Jump()
    {

    }

    void Shoot()
    {

    }

    void Update()
    {
        HealthControl();
        TimeTicking();
        LevelControl();
        KillControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            TakeDamage(1);
            ScorePoints(-50);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="Coin")
        {
            EarnCoin(1);
            ScorePoints(1000);
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="EnemyFire")
        {
            TakeDamage(1);
            ScorePoints(-20);
            Destroy(collision.gameObject);
        }
    }
}

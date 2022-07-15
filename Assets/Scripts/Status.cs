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
    public static float shootTimer;
    public float bulletForce;

    Rigidbody2D rb;
    AudioSource sourceAudio;
    public AudioClip coin;
    public AudioClip laser;
    public AudioClip hit;
    public AudioClip die;

    public GameObject gameOverCanvas;

    public static float jump;
    public static bool jumpable;
    Vector3 velocity;
    void Start()
    {
        sourceAudio = gameObject.GetComponent<AudioSource>();
        rb =GetComponent<Rigidbody2D>();
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
            sourceAudio.PlayOneShot(die);
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
        sourceAudio.PlayOneShot(hit);
    }

    void EarnCoin(int coin)
    {
        coins += coin;
        coinText.text = " : " + coin.ToString();
        sourceAudio.PlayOneShot(this.coin);
    }

    public void Jump()
    {
        if (Mathf.Approximately(rb.velocity.y, 0) || jumpable == true )
        {
            jump = 13f;
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            jump = 0f;
        }
    }

    public void Shoot()
    {
        if (shootTimer <= 0)
        {
            sourceAudio.PlayOneShot(laser);
            GameObject bulletr = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
            Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
            rgbr.AddForce(firePoint.transform.right * bulletForce, ForceMode2D.Impulse);
            Destroy(bulletr, 1.5f);
            shootTimer = attackSpeed;
        }
    }

    void Update()
    {
        HealthControl();
        KillControl();
        shootTimer -= Time.deltaTime;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            jumpable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive)
        {
            if (collision.gameObject.tag == "Platform")
            {
                jumpable = true;
            }

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

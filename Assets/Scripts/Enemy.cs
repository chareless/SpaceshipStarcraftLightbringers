using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;
    public float aliveTime;

    public float Sayac;
    public float bulletForce;
    public Transform firePoint;
    public GameObject bullet;
    public int randomShoot;
    public AudioClip laserSound;
    AudioSource sourceAudio;

    public GameObject particle;
    void Start()
    {
        aliveTime = 5;
        randomShoot = Random.Range(0, 100);
        Sayac = 3f;
        sourceAudio = gameObject.GetComponent<AudioSource>();
    }

    void DestroyTimer()
    {
        aliveTime -= Time.deltaTime;
        if (aliveTime < 0)
        {
            Destroy(gameObject);
        }
    }

    void Fire()
    {
        if (Sayac <= 0)
        {
            sourceAudio.PlayOneShot(laserSound);
            GameObject bulletr = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rgbr = bulletr.GetComponent<Rigidbody2D>();
            rgbr.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
            sourceAudio.PlayOneShot(laserSound);
            Destroy(bulletr, 3f);
            Sayac = 3f;
        }
    }

    void ShootControl()
    {
        Sayac -= Time.deltaTime;

        if(gameObject.tag != "EnemySlime")
        {
            switch (BottomSpawner.difLevel)
            {
                case 0:
                    if (randomShoot < 0)
                    {
                        Fire();
                    }
                    break;
                case 1:
                    if (randomShoot < 5)
                    {
                        Fire();
                    }
                    break;
                case 2:
                    if (randomShoot < 10)
                    {
                        Fire();
                    }
                    break;
                case 3:
                    if (randomShoot < 15)
                    {
                        Fire();
                    }
                    break;
                case 4:
                    if (randomShoot < 20)
                    {
                        Fire();
                    }
                    break;
                case 5:
                    if (randomShoot < 25)
                    {
                        Fire();
                    }
                    break;
                case 6:
                    if (randomShoot < 30)
                    {
                        Fire();
                    }
                    break;
                case 7:
                    if (randomShoot < 35)
                    {
                        Fire();
                    }
                    break;
                case 8:
                    if (randomShoot < 40)
                    {
                        Fire();
                    }
                    break;
                case 9:
                    if (randomShoot < 45)
                    {
                        Fire();
                    }
                    break;
                case 10:
                    if (randomShoot < 50)
                    {
                        Fire();
                    }
                    break;
            }
        }
    }

    void Move()
    {
        transform.position -= new Vector3(speed*Time.deltaTime, 0, 0);
    }
    void Update()
    {
        Move();
        DestroyTimer();
        ShootControl();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Status.takeKill = true;
        }
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(particle, transform.position, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public int[] randomRanges;

    public int randomShip;
    public int randomPlace;
    public int enemyIndex;
    public static int difLevel;

    public static float spawnRate;
    public float nextSpawn = 0.0f;
    public float nextStepSayac = 2;
    public float timer;

    //randomRange[0] = head
    //randomRange[1] = eye
    //randomRange[2] = slime
    //randomRange[3] = warm
    //randomRange[4] = cannon 

    void Start()
    {
        spawnRate = 3f;
        timer = 0;
        difLevel = 0;
    }

    void RateControl()
    {
        if (timer >= 50)
        {
            timer = 0;
            if (spawnRate != 0.1f)
            {
                spawnRate -= 0.1f;
            }
        }

        if (spawnRate == 3f)
        {
            randomRanges[0] = 50;
            randomRanges[1] = 100;
            randomRanges[2] = 200;
            randomRanges[3] = 200;
            randomRanges[4] = 200;
            difLevel = 0;
        }
        else if(spawnRate == 2.8f)
        {
            randomRanges[0] = 45;
            randomRanges[1] = 90;
            randomRanges[2] = 100;
            randomRanges[3] = 200;
            randomRanges[4] = 200;
            difLevel = 1;
        }
        else if (spawnRate == 2.6f)
        {
            randomRanges[0] = 40;
            randomRanges[1] = 80;
            randomRanges[2] = 100;
            randomRanges[3] = 200;
            randomRanges[4] = 200;
            difLevel = 2;
        }
        else if (spawnRate == 2.4f)
        {
            randomRanges[0] = 30;
            randomRanges[1] = 60;
            randomRanges[2] = 90;
            randomRanges[3] = 100;
            randomRanges[4] = 200;
            difLevel = 3;
        }
        else if (spawnRate == 2.2f)
        {
            randomRanges[0] = 25;
            randomRanges[1] = 50;
            randomRanges[2] = 80;
            randomRanges[3] = 100;
            randomRanges[4] = 200;
            difLevel = 4;
        }
        else if (spawnRate == 2f)
        {
            randomRanges[0] = 25;
            randomRanges[1] = 50;
            randomRanges[2] = 75;
            randomRanges[3] = 100;
            randomRanges[4] = 200;
            difLevel = 5;
        }
        else if (spawnRate == 1.8f)
        {
            randomRanges[0] = 20;
            randomRanges[1] = 40;
            randomRanges[2] = 60;
            randomRanges[3] = 90;
            randomRanges[4] = 100;
            difLevel = 6;
        }
        else if (spawnRate == 1.6f)
        {
            randomRanges[0] = 15;
            randomRanges[1] = 30;
            randomRanges[2] = 45;
            randomRanges[3] = 80;
            randomRanges[4] = 100;
            difLevel = 7;
        }
        else if (spawnRate == 1.4f)
        {
            randomRanges[0] = 10;
            randomRanges[1] = 20;
            randomRanges[2] = 30;
            randomRanges[3] = 70;
            randomRanges[4] = 100;
            difLevel = 8;
        }
        else if (spawnRate == 1.2f)
        {
            randomRanges[0] = 10;
            randomRanges[1] = 20;
            randomRanges[2] = 30;
            randomRanges[3] = 65;
            randomRanges[4] = 100;
            difLevel = 9;
        }
        else
        {
            randomRanges[0] = 10;
            randomRanges[1] = 20;
            randomRanges[2] = 30;
            randomRanges[3] = 60;
            randomRanges[4] = 100;
            difLevel = 10;
        }
       
    }

    void Spawn()
    {
        randomShip = Random.Range(0, 100);
        randomPlace = Random.Range(0, 5);
        if (randomShip <= randomRanges[0])
        {
            enemyIndex = 0;
        }
        else if(randomShip>randomRanges[0] && randomShip <= randomRanges[1])
        {
            enemyIndex = 1;
        }
        else if (randomShip > randomRanges[1] && randomShip <= randomRanges[2])
        {
            enemyIndex = 2;
        }
        else if (randomShip > randomRanges[2] && randomShip <= randomRanges[3])
        {
            enemyIndex = 3;
        }
        else if (randomShip > randomRanges[3] && randomShip <= randomRanges[4])
        {
            enemyIndex = 4;
        }
    }
    void Update()
    {
        if (Status.isAlive)
        {
            RateControl();
            timer += Time.deltaTime;
            if (Time.time > nextSpawn)
            {
                nextStepSayac -= Time.deltaTime;

                if (nextStepSayac < 0)
                {
                    nextSpawn = Time.time + spawnRate;
                    Spawn();
                    Instantiate(enemies[enemyIndex], transform.position + new Vector3(0, randomPlace, 0), transform.rotation);
                }
            }
        }
    }
}

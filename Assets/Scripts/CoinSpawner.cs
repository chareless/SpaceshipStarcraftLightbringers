using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public float timer;
    public bool create;
    void Update()
    {
        if (!create)
        {
            int random = Random.Range(25, 50);
            create = true;
            timer = random;
        }

        if (create)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                create = false;
                timer = 0;
                int randomPlace = Random.Range(0,5);
                Instantiate(coin, transform.position + new Vector3(0,randomPlace,0), transform.rotation);
            }
        }
    }
}

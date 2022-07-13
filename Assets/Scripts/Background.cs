using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        
        if (transform.position.x < -24f)
        {
            transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            if(BottomSpawner.spawnRate != 0)
            {
                transform.position -= new Vector3(speed * Time.deltaTime * (1 / BottomSpawner.spawnRate), 0, 0);
            }
            else
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
            
        }
    }
}

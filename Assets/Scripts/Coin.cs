using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int speed;
    void Update()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}

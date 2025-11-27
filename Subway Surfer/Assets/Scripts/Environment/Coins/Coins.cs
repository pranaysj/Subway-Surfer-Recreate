using Entities;
using Environment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins: MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 3);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + "Coin collected!");
    }
}

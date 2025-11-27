using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    private int zOutOfBound = -5;

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 3);

        if (transform.position.z < zOutOfBound)
        {
            Destroy(gameObject);
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 3);
    }
}

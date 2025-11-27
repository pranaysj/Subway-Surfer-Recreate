using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float laneIndex;
    private int zOutOfBound = -5;

    private void Start()
    {
        laneIndex = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 3);

        if (transform.position.z < zOutOfBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            CoinsSpawn.Instance.ChangeLane(laneIndex);

        }
    }
}

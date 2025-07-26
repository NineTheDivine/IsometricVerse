using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresher : MonoBehaviour
{
    [SerializeField] private readonly Vector3 Distance = new Vector3(50, 0, 0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position += Distance;
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.gameObject.GetComponent<Obstacle>().GiveRandomPos();
        }
        if (collision.gameObject.CompareTag("Gold"))
        {
            collision.gameObject.GetComponent<Gold>().GiveRandomPos();
        }
    }
}

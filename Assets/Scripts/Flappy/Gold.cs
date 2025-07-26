using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private void Start()
    {
        GiveRandomPos();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.AddSessionGold(1);
            transform.position += new Vector3(50, 0, 0);
            GiveRandomPos();
        }
    }

    public void GiveRandomPos()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-2.0f, 2.0f), transform.position.z);
    }
}

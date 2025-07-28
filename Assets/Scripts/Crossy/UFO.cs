using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UFO : MonoBehaviour
{
    private float speed = -3f;
    private bool _isReverse = true;
    public const int BoarderSize = 18;
    private Tilemap tilemap;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void Init(float speed, bool isReverse)
    {
        this.speed = speed;
        this._isReverse = isReverse;
        if (_isReverse)
            this.speed *= -1;
    }
    
    private void FixedUpdate()
    {
        transform.position += tilemap.CellToLocal(Vector3Int.up) * speed * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HorizontalReload"))
        {
            //move to other side
            if (_isReverse)
                transform.position += tilemap.CellToLocal(Vector3Int.up) * (BoarderSize-2);
            else
                transform.position -= tilemap.CellToLocal(Vector3Int.up) * (BoarderSize-2);

            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<CrossyCharController>().KillPlayer();
            return;
        }
    }


}

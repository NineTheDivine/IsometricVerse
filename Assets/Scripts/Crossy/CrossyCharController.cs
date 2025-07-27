using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CrossyCharController : MonoBehaviour
{
    private const float MovementDelay = 0.3f;
    private float delay = 0.0f;
    [SerializeField] Tilemap playerTilemap;

    void OnFoward(InputValue input)
    {
        //if delay, return
        if (delay > 0.0f) return;
        //Move Foward
        transform.position = playerTilemap.GetCellCenterWorld(new Vector3Int(1, 0, 0));
        delay = MovementDelay;
        StartCoroutine(KeyDelay());
    }

    void OnLeft(InputValue input)
    {
        //if delay, return
        if (delay > 0.0f) return;
        //if obstacle, return

        //if no obstacle, move
        transform.position = playerTilemap.GetCellCenterWorld(new Vector3Int(0, 1, 0));
        delay = MovementDelay;
        StartCoroutine(KeyDelay());
    }

    void OnRight(InputValue input)
    {
        //if delay, return
        if (delay > 0.0f) return;
        //if obstacle, return

        //if no obstacle, move
        transform.position = playerTilemap.GetCellCenterWorld(new Vector3Int(0, -1, 0));
        delay = MovementDelay;
        StartCoroutine(KeyDelay());
    }

    IEnumerator KeyDelay()
    {
        while (delay > 0.0f)
        {
            delay -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        delay = 0.0f;
        StopCoroutine(KeyDelay());
    }

}

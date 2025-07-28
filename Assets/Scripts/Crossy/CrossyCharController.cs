using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CrossyCharController : MonoBehaviour
{
    private const float MovementDelay = 0.4f;
    private float delay = 0.0f;
    private bool isStop = true;
    [SerializeField] Tilemap playerTilemap;
    [SerializeField] CrossyManager crossyManager;
    public LayerMask blcokLayer;

    private bool isDead = false;


    void OnFoward(InputValue input)
    {
        if(isDead) return;
        //if delay, return
        if (!isStop) return;
        //Move Foward
        Vector3 targetposition = playerTilemap.GetCellCenterWorld(new Vector3Int(1, 0, 0));
        crossyManager.playerFowardAction();
        delay = MovementDelay;
        isStop = false;
        StartCoroutine(KeyDelay(targetposition));
    }

    void OnLeft(InputValue input)
    {
        if(isDead) return;
        //if delay, return
        if (!isStop) return;
        Vector3 targetposition = playerTilemap.GetCellCenterWorld(new Vector3Int(0, 1, 0));

        //if obstacle, return
        if (Physics2D.OverlapBox(targetposition + Vector3.down, playerTilemap.cellSize, 0, blcokLayer))
            return;
        //if no obstacle, move
        delay = MovementDelay;
        isStop = false;
        StartCoroutine(KeyDelay(targetposition));
    }

    void OnRight(InputValue input)
    {
        if(isDead) return;
        //if delay, return
        if (!isStop) return;

        Vector3 targetposition = playerTilemap.GetCellCenterWorld(new Vector3Int(0, -1, 0));
        if (Physics2D.OverlapBox(targetposition + Vector3.down, playerTilemap.cellSize, 0, blcokLayer))
            return;
        delay = MovementDelay;
        isStop = false;
        StartCoroutine(KeyDelay(targetposition));
    }

    IEnumerator KeyDelay(Vector3 targetposition)
    {
        while (delay >= 0.0f)
        {
            delay -= Time.fixedDeltaTime;
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, targetposition.x, delay),
                Mathf.Lerp(transform.position.y, targetposition.y, delay),
                transform.position.z
                );
            yield return new WaitForFixedUpdate();
        }
        transform.position = targetposition;
        delay = 0.0f;
        isStop = true;
        StopCoroutine(KeyDelay(targetposition));
    }

    public void KillPlayer()
    {
        isDead = true;
        playerTilemap.ClearAllTiles();
        //show ui
    }

}

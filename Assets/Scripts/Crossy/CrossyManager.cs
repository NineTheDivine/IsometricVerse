using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CrossyManager : MonoBehaviour
{
    [SerializeField] Chunk chunkPrefab;
    Queue<Chunk> chunks = new Queue<Chunk>();
    Vector3 lastPosition = new Vector3 (0,0,10);
    private int playerMove = 0;
    [SerializeField] CrossyCharController playerController;

    private void Start()
    {
        int chunkcount = 3;
        for (int i = 0; i < chunkcount; i++)
        {
            Chunk newchunk = Instantiate(chunkPrefab);
            lastPosition = newchunk.moveChunk(lastPosition);
            chunks.Enqueue(newchunk);
        }

    }

    public void playerFowardAction()
    {
        playerMove++;
        if (playerMove >= Chunk.positionOffset)
        {
            playerMove = 0;
            Chunk lastChunk = chunks.Peek();
            chunks.Dequeue();
            lastPosition = lastChunk.moveChunk(lastPosition);
            chunks.Enqueue(lastChunk);
        }
    }

}

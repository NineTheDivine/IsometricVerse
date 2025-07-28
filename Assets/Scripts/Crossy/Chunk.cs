using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public const int positionOffset = 21;
    [SerializeField] ObstacleLane[] lanes;
    public Vector3 moveChunk(Vector3 lastPosition)
    {
        transform.position = lastPosition;

        for (int i = 0; i < lanes.Length; i++)
            lanes[i].InitRandom(i);
        return GetComponent<Grid>().CellToWorld(Vector3Int.right * positionOffset);
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleLane : MonoBehaviour
{
    private Tilemap tilemap;
    private List<UFO> ufoList;
    [SerializeField] UFO ufoPrefab;

    private float speed;
    private int count;
    private bool isReverse;

    public void InitRandom()
    {
        speed = Random.Range(3.0f, 5.0f);
        count = Random.Range(4, 8);
        isReverse = Random.Range(0.0f, 1.0f) >= 0.5f ? true: false;

        Vector3Int ufopos = new Vector3Int(0, -UFO.BoarderSize/2 , 0);
        for(int i = 0; i < count; i++)
        {
            UFO ufo = Instantiate(ufoPrefab, transform);
            ufo.Init(this.speed, this.isReverse);
            ufo.transform.localPosition += tilemap.CellToLocal(ufopos);
            ufoList.Add(ufo);

            ufopos += Vector3Int.up * UFO.BoarderSize/(count);
        }
    }
    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        ufoList = new List<UFO>();
    }


    private void Start()
    {
        InitRandom();
    }


}

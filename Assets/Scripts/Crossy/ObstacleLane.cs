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

    public void InitRandom(int index)
    {
        foreach (UFO ufo in ufoList)
        {
            Destroy(ufo.gameObject);
        }
        ufoList.Clear();
        transform.localPosition = tilemap.GetCellCenterLocal(Vector3Int.zero + Vector3Int.right * index * 4 + Vector3Int.left * 2);
        transform.localPosition += Vector3.forward * 50;

        speed = Random.Range(3.0f, 5.0f);
        count = Random.Range(4, 6);
        isReverse = (Random.Range(0.0f, 1.0f) >= 0.5f ? true: false);

        int startpos = -UFO.BoarderSize / 2 + 1;
        int endpos = UFO.BoarderSize / 2 - 1;
        int gap = (endpos - startpos) / count;
        int padding = endpos - (startpos + gap * count);

        startpos += (padding+1) / 2;
        endpos -= (padding+1) / 2;

        Vector3Int ufopos = new Vector3Int(0, isReverse? startpos : endpos , 0);
        for(int i = 0; i < count; i++)
        {
            UFO ufo = Instantiate(ufoPrefab, transform);
            ufo.Init(this.speed, this.isReverse);
            ufoList.Add(ufo);

            ufo.transform.localPosition += tilemap.CellToLocal(ufopos);
            if (isReverse)
            {
                ufopos += Vector3Int.up * gap;
            }
            else
            {
                ufopos -= Vector3Int.up * gap;
            }
        }
    }
    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        ufoList = new List<UFO>();
    }
}

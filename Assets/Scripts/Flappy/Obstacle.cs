using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Transform top;
    Transform bottom;
    private const float Gap = 1.0f;

    public void Awake()
    {
        top = transform.Find("Top");
        bottom = transform.Find("Bottom");
    }

    public void Start()
    {
        if (top == null || bottom == null)
        {
            Debug.Log("Top or Bottom not found in Obstacle");
            return;
        }
        GiveRandomPos();
    }

    public void GiveRandomPos()
    {
        float randomSelect = Random.Range(0f, 1f);
        float randomTop;
        float randomBottom;
        if (randomSelect >= 0.5f)
        {
            randomTop = Random.Range(1.0f, 2.0f);
            randomBottom = 4 - Gap - randomTop;
        }
        else
        {
            randomBottom = Random.Range(1.0f, 2.0f); 
            randomTop = 4 - Gap - randomBottom;
        }
        top.transform.localScale = new Vector3(top.transform.localScale.x, randomTop, top.transform.localScale.z);
        bottom.transform.localScale = new Vector3(bottom.transform.localScale.x, randomBottom, bottom.transform.localScale.z);
    }
}

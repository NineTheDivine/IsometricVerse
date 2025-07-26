using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    Vector2 offset;
    [SerializeField] bool FixedY= false;
    void Start()
    {
        if (target == null)
        {
            Debug.Log("Target not found in Camera");
            return;
        }
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos = (Vector2)target.position + offset;
        transform.position = new Vector3(pos.x, 
            FixedY ? transform.position.y : pos.y,
            transform.position.z);
    }
}

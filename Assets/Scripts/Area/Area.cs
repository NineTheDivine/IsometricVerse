using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Area : MonoBehaviour
{
    CompositeCollider2D _collision;
    GameObject Tower;
    Animator _anim;

    private void Start()
    {
        _collision = GetComponent<CompositeCollider2D>();
        if (_collision == null)
        {
            Debug.Log("Area Collision is empty");
            return;
        }
        Tower = transform.GetChild(0).gameObject;
        _anim = Tower.transform.Find("UISprite").GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.Log("Area Animator is empty");
            return;
        }
        _anim.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered Location");
            _anim.gameObject.SetActive(true);
            _anim.SetBool("IsOpen", true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exit Location");
            _anim.SetBool("IsOpen", false);
        }
    }
}

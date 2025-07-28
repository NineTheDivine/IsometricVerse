using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Area : MonoBehaviour
{
    CompositeCollider2D _collision;
    Animator _anim;

    [SerializeField] string NextScene = "";

    private void Start()
    {
        _collision = GetComponent<CompositeCollider2D>();
        _anim = transform.Find("UISprite").GetComponent<Animator>();
        if (_collision == null)
        {
            Debug.Log("Area Collision is empty");
            return;
        }
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
            collision.GetComponent<PlayerController>().AddArea(this);
            _anim.gameObject.SetActive(true);
            _anim.SetBool("IsOpen", true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().RemoveArea(this);
            _anim.SetBool("IsOpen", false);
        }
    }

    public void ActivateArea()
    {
        NextScene.Trim();
        if (NextScene == null || NextScene == "")
        {
            Debug.Log("Scene has no name in Area");
            return;
        }
        SceneManager.LoadScene(NextScene);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrossyBtn : MonoBehaviour
{
    [SerializeField] CrossyManager manager;
    public void OnPlayBtn()
    {
        Debug.Log("Click");
        manager.ChangeState(CrossyManager.GameState.Play);
    }
    public void OnReadyBtn()
    {
        Debug.Log("Click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnReturnBtn()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("MapScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBtn : MonoBehaviour
{
    [SerializeField] FlappyManager manager;
    public void OnPlayBtn()
    {
        manager.ChangeState(FlappyManager.GameState.Play);
    }
    public void OnReadyBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnReturnBtn()
    {
        SceneManager.LoadScene("MapScene");
    }
}

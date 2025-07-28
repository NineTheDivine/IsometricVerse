using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class CrossyManager : MonoBehaviour
{


    [SerializeField] Canvas _ReadyUI;
    [SerializeField] Canvas _DeadUI;
    [SerializeField] Canvas _PlayUI;
    public enum GameState
    {
        Ready,
        Play,
        Dead
    }

    [SerializeField] public GameState currentState = GameState.Ready;
    private int _currentScore;
    private int _bestScore;
    private string _bestKey = "CrossyBestScore";
    public int currentScore { get => _currentScore; }
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

        if (_ReadyUI == null)
            Debug.Log("_ReadyUI not found in CrossyManager");
        if (_DeadUI == null)
            Debug.Log("_DeadUI not found in CrossyManager");
        if (PlayerManager.Instance.sessionGold == null)
            PlayerManager.Instance.InitSessionGold();
        currentState = GameState.Ready;
        _bestScore = PlayerPrefs.GetInt(_bestKey, 0);
        ChangeState(GameState.Ready);

    }

    public void playerFowardAction()
    {
        playerMove++;
        AddScore(1);
        if (playerMove >= Chunk.positionOffset)
        {
            playerMove = 0;
            Chunk lastChunk = chunks.Peek();
            chunks.Dequeue();
            lastPosition = lastChunk.moveChunk(lastPosition);
            chunks.Enqueue(lastChunk);
        }
    }


    public void ChangeState(GameState state)
    {
        currentState = state;
        switch (state)
        {
            case GameState.Ready: onReady(); break;
            case GameState.Dead: onDead(); break;
            case GameState.Play: onPlay(); break;
        }
    }

    private void onReady()
    {
        //visualize Ready ui
        _currentScore = 0;
        _DeadUI.enabled = false;
        _PlayUI.enabled = false;
        _ReadyUI.enabled = true;
    }

    private void onPlay()
    {
        //hide ready ui
        _PlayUI.enabled = true;
        _PlayUI.transform.Find("BestTxt").GetComponent<TextMeshProUGUI>().text = "Best : " + _bestScore.ToString();
        _ReadyUI.enabled = false;
    }

    private void onDead()
    {
        //visualize dead ui
        _PlayUI.enabled = false;
        _DeadUI.enabled = true;
        TextMeshProUGUI ScoreValueText = _DeadUI.transform.Find("ScoreValueTxt").GetComponent<TextMeshProUGUI>();
        ScoreValueText.text = _currentScore.ToString();
        if (_currentScore > _bestScore)
        {
            ScoreValueText.text += " New BEST!";
            ScoreValueText.color = new Color(212 / 255.0f, 175 / 255.0f, 55 / 255.0f);
            _bestScore = _currentScore;
            PlayerPrefs.SetInt(_bestKey, _bestScore);
        }
        _DeadUI.transform.Find("BestValueTxt").GetComponent<TextMeshProUGUI>().text = _bestScore.ToString();
    }

    public void AddScore(int amount)
    {
        _currentScore += amount;
        _PlayUI.transform.Find("ScoreTxt").GetComponent<TextMeshProUGUI>().text = "Score : " + _currentScore.ToString();
    }

}

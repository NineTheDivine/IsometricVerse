using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FlappyManager : MonoBehaviour
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

    [SerializeField] GameState currentState = GameState.Ready;
    [SerializeField] Plane plane;
    private int _currentScore;
    private int _bestScore;
    private string _bestKey = "BestScore";
    public int currentScore { get => _currentScore; }

    private void Start()
    {
        if (_ReadyUI == null)
            Debug.Log("_ReadyUI not found in FlappyManager");
        if (_DeadUI == null)
            Debug.Log("_DeadUI not found in FlappyManager");
        currentState = GameState.Ready;
        _bestScore = PlayerPrefs.GetInt(_bestKey, 0);
        ChangeState(GameState.Ready);
    }

    public void ChangeState(GameState state)
    {
        currentState = state;
        switch (state)
        {
            case GameState.Ready:onReady(); break;
            case GameState.Dead: onDead(); break;
            case GameState.Play: onPlay(); break;
        }
    }

    private void onReady()
    {
        //visualize Ready ui
        plane.setStop(true);
        _currentScore = 0;
        _DeadUI.enabled = false;
        _PlayUI.enabled = false;
        _ReadyUI.enabled = true;
    }

    private void onPlay()
    {
        //hide ready ui
        plane.setStop(false);
        _PlayUI.enabled=true;
        _PlayUI.transform.Find("BestTxt").GetComponent<TextMeshProUGUI>().text = "Best : " + _bestScore.ToString();
        _ReadyUI.enabled=false;
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
        plane.setAdditionalSpeed((_currentScore / 5) / 2.0f);
        _PlayUI.transform.Find("ScoreTxt").GetComponent<TextMeshProUGUI>().text = "Score : " + _currentScore.ToString();
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private int? _sessionGold = null;
    public int? sessionGold { get => _sessionGold; }

    private int _gold = 0;
    public int gold { get { return _gold; } }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void InitSessionGold()
    {
        _sessionGold = 0;
    }

    public void AddSessionGold(int amount)
    {
        _sessionGold += amount;
    }

    public void EndSessionGold()
    {
        if (_sessionGold == null)
            return;
        _gold += (int)_sessionGold;
        _sessionGold = null;
    }
}

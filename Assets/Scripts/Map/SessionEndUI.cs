using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SessionEndUI : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;
    [SerializeField] InfoUI infoUI;

    private void OnEnable()
    {
        playerInput.actions.Disable();
    }
    private void OnDisable()
    {
        PlayerManager.Instance.EndSessionGold();
        infoUI.SetGoldText();
        playerInput.actions.Enable();
    }
}

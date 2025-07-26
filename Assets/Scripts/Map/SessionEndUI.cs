using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SessionEndUI : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.actions.Disable();
    }
    private void OnDisable()
    {
        PlayerManager.Instance.EndSessionGold();
        playerInput.actions.Enable();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    [SerializeField] Canvas sessionEndUI;
    
    private void Awake()
    {
        if (PlayerManager.Instance == null)
        {
            Debug.Log("Player manager not initialized");
            return;
        }
    }

    private void Start()
    {
        if (PlayerManager.Instance.sessionGold == null)
        {
            sessionEndUI.gameObject.SetActive(false);
        }
        else
        {
            sessionEndUI.gameObject.SetActive(true);
            sessionEndUI.transform.Find("AmountTxt").GetComponent<TextMeshProUGUI>().text =
                (PlayerManager.Instance.sessionGold == 0 ? "" : "+ ") + PlayerManager.Instance.sessionGold.ToString() + " G";
        }
    }
}

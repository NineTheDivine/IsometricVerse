using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI amountTxt;
    void Start()
    {
        SetGoldText();
    }

    public void SetGoldText()
    {
        amountTxt.text = PlayerManager.Instance.gold.ToString() + " G";
    }

}

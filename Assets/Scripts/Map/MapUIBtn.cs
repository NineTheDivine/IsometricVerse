using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIBtn : MonoBehaviour
{
    public void OnHidePress(Canvas ui)
    {
        ui.gameObject.SetActive(false);
    }

    public void OnShowPress(Canvas ui)
    {
        ui.gameObject.SetActive(true);
    }
}

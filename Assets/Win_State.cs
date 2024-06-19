using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_State : MonoBehaviour
{
    public GameObject WinCanvas;

    private void OnTriggerEnter(Collider other)
    {
        WinCanvas.SetActive(true);
    }
}

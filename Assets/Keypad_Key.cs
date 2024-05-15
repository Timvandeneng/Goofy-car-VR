using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad_Key : MonoBehaviour
{
    [SerializeField] private KeypadManager manager;

    [SerializeField] private int Number;

    [SerializeField] private Material normalMat;
    [SerializeField] private Material SelectedMat;
    [SerializeField] private Material CorrectMat;
    [SerializeField] private Material WrongMat;

    private MeshRenderer MRenderer;

    private bool pressed = false;

    private void Start()
    {
        MRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lhand") || other.CompareTag("Rhand"))
        {
            if (!pressed)
            {
                manager.Combination += Number.ToString();
                MRenderer.material = SelectedMat;
                pressed = true;
            }
        }
    }

    public void Correct()
    {
        MRenderer.material = CorrectMat;
    }

    public void Wrong()
    {
        MRenderer.material = WrongMat;
    }

    public void Reset()
    {
        MRenderer.material = normalMat;
        pressed = false;
    }

}

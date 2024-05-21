using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Button : MonoBehaviour
{
    ModuleInput moduleInput;

    [SerializeField] private Transform Model;
    [SerializeField] private Vector3 restingpos;
    [SerializeField] private Vector3 pushedpos;
    public bool toggled = false;

    private void Awake()
    {
        moduleInput = GetComponent<ModuleInput>();

        moduleInput.type = ModuleInput.InputType.Analog;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggled)
        {
            Model.localPosition = pushedpos;
        }
        else
        {
            Model.localPosition = restingpos;
        }

        moduleInput.digitalValue = toggled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rhand") || other.CompareTag("Lhand"))
        {
            toggled = !toggled;
        }
    }
}

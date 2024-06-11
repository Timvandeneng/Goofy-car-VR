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

    [Header("Debug settings")]
    [SerializeField] private float DebugTimer;
    private float resetDebug;
    private bool canToggle = true;

    private void Awake()
    {
        moduleInput = GetComponent<ModuleInput>();

        moduleInput.type = ModuleInput.InputType.Digital;
        resetDebug = DebugTimer;
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

        if (!canToggle)
        {
            DebugTimer -= Time.deltaTime;
            if(DebugTimer < 0)
            {
                DebugTimer = resetDebug;
                canToggle = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rhand") || other.CompareTag("Lhand"))
        {
            if (canToggle)
            {
                toggled = !toggled;
                canToggle = false;
            }
        }
    }
}

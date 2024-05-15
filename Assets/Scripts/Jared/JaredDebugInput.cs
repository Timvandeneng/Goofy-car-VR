using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaredDebugInput : MonoBehaviour {
    private ModuleInput moduleInput;

    public KeyCode requiredKey;

    private void Awake()
    {
        moduleInput = GetComponent<ModuleInput>();

        moduleInput.type = ModuleInput.InputType.Digital;
    }

    void Update()
    {
        if(Input.GetKeyDown(requiredKey)) {
            moduleInput.moduleInputBoolean = !moduleInput.moduleInputBoolean;
        }
    }
}

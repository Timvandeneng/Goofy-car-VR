using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Controller_manager : MonoBehaviour
{

    private InputData _inputData;

    public bool leftHandTrigger;
    public bool rightHandTrigger;

    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerL))
        {
            leftHandTrigger = triggerL;
        }
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerR))
        {
            rightHandTrigger = triggerR;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class Module : MonoBehaviour {
    GameManager gameManager;

    public enum ModuleType {
        Accelerate,
        TurnLeft,
        TurnRight,
        Brake,
        Breakdown
    }

    public ModuleType moduleType;

    public List<ModuleInput> combination = new List<ModuleInput>();


    private void Update()
    {
        switch(moduleType) {
            case ModuleType.Accelerate:
                break;
            case ModuleType.TurnLeft:
                break;
            case ModuleType.TurnRight:
                break;
            case ModuleType.Brake:
                break;
            case ModuleType.Breakdown:
                break;
        }
    }

    private void AccelerationLogic()
    {
         
    }

    private void TurnLogic(string turnType) {
        
    }
}

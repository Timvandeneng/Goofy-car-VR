using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Module : MonoBehaviour {
    GameManager gameManager;

    public enum ModuleType {
        Accelerate,
        Turn,
        Brake,
        Breakdown,
        None
    }

    public ModuleType moduleType;

    public ModuleInput analogInput;

    public List<ModuleInput> combination = new List<ModuleInput>();
    private List<ModuleInput> userInputs = new List<ModuleInput>(); // list of inputs the user is currently giving

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }


    private void Update()
    {
        foreach(ModuleInput input in combination) {
            if(input.type == ModuleInput.InputType.Digital && input.completed) {
                //Debug.Log($"onToggle: {input.onToggle}");
                userInputs.Add(input);
            }
        }

        // Trim userInputs
        while(userInputs.Count > combination.Count) {
            userInputs.RemoveAt(0);
        }

        if(userInputs.SequenceEqual(combination)) {
            switch(moduleType) {
                case ModuleType.Accelerate:
                    AccelerationLogic();
                    break;
                case ModuleType.Turn:
                    TurnLogic();
                    break;
                case ModuleType.Brake:
                    BrakeLogic();
                    break;
                case ModuleType.Breakdown:
                    break;
                case ModuleType.None:
                default:
                    break;
            }
        }
    }

    private void AccelerationLogic()
    {
        gameManager.carAcceleration = analogInput.analogValue;
        Debug.Log("Acceleration Logic");
    }

    private void TurnLogic()
    {
        gameManager.carSteering = analogInput.analogValue * 10;
        Debug.Log("Turn Logic");
    }

    private void BrakeLogic()
    {
        gameManager.carDeceleration = -analogInput.analogValue;
        Debug.Log("Slow down Logic");
    }
}
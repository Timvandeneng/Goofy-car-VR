using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Module : MonoBehaviour {
    GameManager gameManager;

    public enum ModuleType {
        Accelerate,
        Turn,
        Brake,
        Breakdown
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
            if(input.type == ModuleInput.InputType.Digital && input.moduleInputBoolean) {
                userInputs.Add(input);
                input.moduleInputBoolean = false;
            }
        }

        // Trim userInputs
        while(userInputs.Count > combination.Count) {
            userInputs.Remove(userInputs[0]);
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
            }
        }
    }

    private void AccelerationLogic()
    {
        gameManager.carAcceleration = analogInput.moduleInputFloat;
    }

    private void TurnLogic()
    {
        gameManager.carSteering = analogInput.moduleInputFloat;
    }

    private void BrakeLogic()
    {
        gameManager.carAcceleration = -analogInput.moduleInputFloat;
    }
}

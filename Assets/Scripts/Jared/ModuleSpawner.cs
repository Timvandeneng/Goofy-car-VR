using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSpawner : MonoBehaviour {
    public List<GameObject> moduleSpawners = new List<GameObject>();

    public List<GameObject> AccelerateModules = new List<GameObject>();
    public List<GameObject> TurnModules = new List<GameObject>();
    public List<GameObject> BrakeModules = new List<GameObject>();
    public List<GameObject> DummyModules = new List<GameObject>();

    private List<int> moduleSelectionBag = new List<int>(); // Similar to a tetris bag, where you load all the numbers at once and shuffle so that you don't get any duplicates

    private List<GameObject> dummiesUsed = new List<GameObject>(); // A list used for the spawning of dummies
    private void Awake()
    {
        for(int i = 0; i < moduleSpawners.Count; i++) { // Populating the list with numbers from 1 to the amount of module spawners
            moduleSelectionBag.Add(i + 1);
        }

        for(int i = 0; i < moduleSelectionBag.Count; i++) { // Shuffling the bag so the numbers are in a random order
            int k = UnityEngine.Random.Range(0, moduleSelectionBag.Count);
            (moduleSelectionBag[k], moduleSelectionBag[i]) = (moduleSelectionBag[i], moduleSelectionBag[k]);
        }

        int _i = 0;
        foreach(GameObject moduleSpawner in moduleSpawners) {
            switch(moduleSelectionBag[_i]) {
                case 1:
                    GameObject currentAccelerateModule = AccelerateModules[UnityEngine.Random.Range(0, AccelerateModules.Count)];
                    currentAccelerateModule.transform.SetParent(moduleSpawner.transform);
                    currentAccelerateModule.transform.localPosition = Vector3.zero;
                    currentAccelerateModule.transform.localRotation = Quaternion.identity;
                    //currentAccelerateModule.transform.localScale = Vector3.one;
                    break;
                case 2:
                    GameObject currentLeftModule = TurnModules[UnityEngine.Random.Range(0, TurnModules.Count)];
                    currentLeftModule.transform.SetParent(moduleSpawner.transform);
                    currentLeftModule.transform.localPosition = Vector3.zero;
                    currentLeftModule.transform.localRotation = Quaternion.identity;
                    //currentLeftModule.transform.localScale = Vector3.one;
                    break;
                case 3:
                    GameObject currentBrakeModule = BrakeModules[UnityEngine.Random.Range(0, BrakeModules.Count)];
                    currentBrakeModule.transform.SetParent(moduleSpawner.transform);
                    currentBrakeModule.transform.localPosition = Vector3.zero;
                    currentBrakeModule.transform.localRotation = Quaternion.identity;
                    //currentBrakeModule.transform.localScale = Vector3.one;
                    break;
                default:
                    GameObject currentDummyModule = DummyModules[UnityEngine.Random.Range(0, DummyModules.Count)];
                    while(dummiesUsed.Contains(currentDummyModule)) {
                        currentDummyModule = DummyModules[UnityEngine.Random.Range(0, DummyModules.Count)];
                    }
                    dummiesUsed.Add(currentDummyModule);
                    currentDummyModule.transform.SetParent(moduleSpawner.transform);
                    currentDummyModule.transform.localPosition = Vector3.zero;
                    currentDummyModule.transform.localRotation = Quaternion.identity;
                    //currentDummyModule.transform.localScale = Vector3.one;
                    break;
            }
            _i++;
        }
    }
}

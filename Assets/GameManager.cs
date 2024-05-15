using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // A bunch of data
    [HideInInspector] public bool accelerating;
    [HideInInspector] public bool turning;
    [HideInInspector] public bool braking;
    [HideInInspector] public bool breakingDown;

    [HideInInspector] public bool canControl;

    [HideInInspector] public float carAcceleration;
    [HideInInspector] public float carSteering;
}

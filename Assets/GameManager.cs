using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // A bunch of data
    [HideInInspector] public bool accelerating;
    [HideInInspector] public bool turningLeft;
    [HideInInspector] public bool turningRight;
    [HideInInspector] public bool braking;
    [HideInInspector] public bool breakingDown;

    // This is just a general control variable, instead of having a different float per direction just assign this to that direction
    [HideInInspector] public float analogVariable;
}

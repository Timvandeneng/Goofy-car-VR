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

    [HideInInspector] public float analogVariable; // This is just a general
}

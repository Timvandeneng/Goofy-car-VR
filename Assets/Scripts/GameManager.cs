using UnityEngine;

public class GameManager : MonoBehaviour {
    // A bunch of data
    [HideInInspector] public bool accelerating;
    [HideInInspector] public bool turning;
    [HideInInspector] public bool braking;
    [HideInInspector] public bool breakingDown;

    public bool canControl;

    [HideInInspector] public float carAcceleration;
    [HideInInspector] public float carSteering;

    private void Update()
    {
        Debug.Log(carAcceleration);
    }
}

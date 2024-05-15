using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Physics : MonoBehaviour
{

    [HideInInspector] public Rigidbody rbody;
    
    GameManager gameManager;

    [Header("Tire Physics")]
    public float raylength;
    public float springrestpos;
    public float springstrength;
    public float DampForce;
    public float friction;

    [Header("Drive Physics")]
    public float desiredAcceleration;
    public float desiredSteering;
    [SerializeField] private float stationaryDampForce;
    [SerializeField] private float maxCarSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>(); 

        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameManager.canControl) return;

        SpeedHandler();

        desiredAcceleration = gameManager.carAcceleration;
        desiredSteering = gameManager.carSteering;
    }

    void SpeedHandler()
    {
        //rbody.drag = desiredAcceleration != 0 ? 0 : stationaryDampForce;
        rbody.velocity = Vector3.ClampMagnitude(rbody.velocity, maxCarSpeed);
    }
}

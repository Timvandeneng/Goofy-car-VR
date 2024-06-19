using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModuleInput))]
public class Pull_Lever : MonoBehaviour {
    private ModuleInput moduleInput;

    [Header("Model Transforms")]
    [SerializeField] private Transform Model;
    [SerializeField] private Transform origin;

    [Header("Hand physics")]
    public GameObject LhandModel;
    public GameObject LhandModelDummy;
    public GameObject RhandModel;
    public GameObject RhandModelDummy;

    [Header("Lever physics")]
    [SerializeField] private float minimumDistance;
    [SerializeField] private float maximumDistance;
    [SerializeField] private float minOutput;
    [SerializeField] private float maxOutput;

    private float minClamp;
    private float maxClamp;

    [Header("Working physics")]
    [SerializeField] private Transform HandTracker;

    [Header("Output")]
    public float AnalogOutput;

    private bool RActivated;
    private bool LActivated;

    private Controller_manager controller;
    private Vector3 startpos;

    //DEBUG
    private GameObject debugPoint;
    private GameObject secondDebugPoint;

    private void Awake()
    {
        moduleInput = GetComponent<ModuleInput>();

        moduleInput.type = ModuleInput.InputType.Analog;

        minClamp = -minimumDistance;
        maxClamp = -maximumDistance;
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindFirstObjectByType<Controller_manager>();
        startpos = Vector3.zero;

        LhandModel = GameObject.FindGameObjectWithTag("Lhand");
        RhandModel = GameObject.FindGameObjectWithTag("Rhand");

        debugPoint = GameObject.Find("DebugPoint");
        secondDebugPoint = GameObject.Find("SecondDebugPoint");
    }

    // Update is called once per frame
    void Update()
    {
        CheckForReset();
        MoveIfHeld();
        OutputVal();

        debugPoint.transform.position = startpos;
        secondDebugPoint.transform.position = transform.position + Model.transform.localPosition;
    }

    void OutputVal()
    {
        AnalogOutput = Mathf.Abs(Vector3.Distance(startpos, Model.transform.localPosition));
        AnalogOutput = ExtensionMethods.Remap(AnalogOutput, minimumDistance, maximumDistance, minOutput, maxOutput);
        moduleInput.analogValue = AnalogOutput;
    }


    void MoveIfHeld()
    {
        if(LActivated) {
            HandTracker.position = LhandModel.transform.position;
            Model.localPosition = new Vector3(Model.localPosition.x, Model.localPosition.y, -(startpos.z - HandTracker.localPosition.z));
        }
        if(RActivated) {
            HandTracker.position = RhandModel.transform.position;
            Model.localPosition = new Vector3(Model.localPosition.x, Model.localPosition.y, -(startpos.z - HandTracker.localPosition.z));
        }

        if(Model.localPosition.z < maxClamp)
            Model.localPosition = new Vector3(Model.localPosition.x, Model.localPosition.y, maxClamp);
        if(Model.localPosition.z > minClamp)
            Model.localPosition = new Vector3(Model.localPosition.x, Model.localPosition.y, minClamp);

    }

    void CheckForReset()
    {

        if(LActivated && !controller.leftHandTrigger) {
            LhandModel.SetActive(true);
            LhandModelDummy.SetActive(false);
            LActivated = false;
        }

        if(RActivated && !controller.rightHandTrigger) {
            RhandModel.SetActive(true);
            RhandModelDummy.SetActive(false);
            RActivated = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Lhand") && controller.leftHandTrigger && !RActivated && !LActivated) {
            LhandModel.SetActive(false);
            LhandModelDummy.SetActive(true);
            LActivated = true;
        }

        if(other.CompareTag("Rhand") && controller.rightHandTrigger && !RActivated && !LActivated) {
            RhandModel.SetActive(false);
            RhandModelDummy.SetActive(true);
            RActivated = true;
        }
    }
}

public static class ExtensionMethods {
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
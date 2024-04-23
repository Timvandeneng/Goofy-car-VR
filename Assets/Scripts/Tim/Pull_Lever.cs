using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull_Lever : MonoBehaviour
{
    [Header("Model Transforms")]
    [SerializeField] private Transform Model;
    [SerializeField] private Transform origin;

    [Header("Hand physics")]
    public GameObject LhandModel;
    public  GameObject LhandModelDummy;
    public GameObject RhandModel;
    public GameObject RhandModelDummy;

    [Header("Lever physics")]
    [SerializeField] private float maximumDistance;
    [SerializeField] private float minimumDistance;
    [SerializeField] private float minOutput;
    [SerializeField] private float maxOutput;

    [Header("Output")]
    public float AnalogOutput;

    private bool RActivated;
    private bool LActivated;

    private Controller_manager controller;
    private Vector3 startpos;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindFirstObjectByType<Controller_manager>();
        startpos = origin.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForReset();
        MoveIfHeld();
        OutputVal();
    }

    void OutputVal()
    {
        AnalogOutput = Vector3.Distance(startpos, Model.transform.position);

        AnalogOutput = ExtensionMethods.Remap(AnalogOutput, maximumDistance, minimumDistance, minOutput, maxOutput);

        AnalogOutput = AnalogOutput - 3;
    }

   
    void MoveIfHeld()
    {
        if (LActivated)
        {
            Model.localPosition = new Vector3(Model.localPosition.x, Model.localPosition.y, -Vector3.Distance(startpos, LhandModel.transform.position));
        }
        if (RActivated)
        {
            Model.localPosition = new Vector3(Model.localPosition.x, Model.localPosition.y, -Vector3.Distance(startpos, RhandModel.transform.position));
        }

        if(Model.localPosition.z < maximumDistance)
            Model.localPosition =new Vector3(Model.localPosition.x, Model.localPosition.y, maximumDistance);
        if (Model.localPosition.z > minimumDistance)
            Model.localPosition = new Vector3(Model.localPosition.x, Model.localPosition.y, minimumDistance);

    }

    void CheckForReset()
    {

        if (LActivated && !controller.leftHandTrigger)
        {
            LhandModel.SetActive(true);
            LhandModelDummy.SetActive(false);
            LActivated = false;
        }

        if (RActivated && !controller.rightHandTrigger)
        {
            RhandModel.SetActive(true);
            RhandModelDummy.SetActive(false);
            RActivated = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Lhand") && controller.leftHandTrigger && !RActivated && !LActivated)
        {
            LhandModel.SetActive(false);
            LhandModelDummy.SetActive(true);
            LActivated = true;
        }

        if(other.CompareTag("Rhand") && controller.rightHandTrigger && !RActivated && !LActivated)
        {
            RhandModel.SetActive(false);
            RhandModelDummy.SetActive(true);
            RActivated = true;
        }
    }
}

public static class ExtensionMethods
{
    public static float Remap(this float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        var fromAbs = from - fromMin;
        var fromMaxAbs = fromMax - fromMin;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = toMax - toMin;
        var toAbs = toMaxAbs * normal;

        var to = toAbs + toMin;

        return to;
    }
}

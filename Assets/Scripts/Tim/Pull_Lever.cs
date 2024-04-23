using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull_Lever : MonoBehaviour
{
    [SerializeField] private Transform Model;
    private Controller_manager controller;

    Vector3 startpos;
    [SerializeField] private Transform origin;

    [SerializeField] private GameObject LhandModel;
    [SerializeField] private GameObject LhandModelDummy;
    [SerializeField] private GameObject RhandModel;
    [SerializeField] private GameObject RhandModelDummy;

    private bool RActivated;
    private bool LActivated;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull_Lever : MonoBehaviour
{
    [SerializeField] private Transform Model;
    private Controller_manager controller;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (LActivated && !controller.leftHandTrigger)
        {
            LhandModel.SetActive(true);
            LhandModelDummy.SetActive(false);
            LActivated = false;
        }

        if(RActivated && !controller.rightHandTrigger)
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

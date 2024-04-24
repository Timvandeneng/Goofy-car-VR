using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clamb_script : MonoBehaviour
{

    [SerializeField] private clamb_script otherclamb;
    public bool beingHeld;

    [SerializeField] private Transform LeftHand;
    [SerializeField] private Transform RightHand;

    private bool leftGrab;
    private bool rightGrab;

    private Controller_manager controller;
    private ConfigurableJoint joint;

    [SerializeField] private Clamb_Manager clambmngr;


    // Start is called before the first frame update
    void Start()
    {
        controller = FindFirstObjectByType<Controller_manager>();
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        handleGrabbing();
        handleRelease();
    }

    void handleGrabbing()
    {
        if (leftGrab)
        {
            transform.position = LeftHand.position;
            transform.rotation = LeftHand.rotation;
        }

        if (rightGrab)
        {
            transform.position = RightHand.position;
            transform.rotation = RightHand.rotation;
        }
    }

    void handleRelease()
    {
        if (leftGrab &&!controller.leftHandTrigger)
        {
            leftGrab = false;
            beingHeld = false;
            gameObject.layer = 0;
        }

        if(rightGrab && !controller.rightHandTrigger)
        {
            rightGrab = false;
            beingHeld = false;
            gameObject.layer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Lhand") && controller.leftHandTrigger && !beingHeld)
        {
            leftGrab = true;
            beingHeld = true;
            gameObject.layer = 6;
        }

        if (other.CompareTag("Rhand") && controller.rightHandTrigger && !beingHeld)
        {
            rightGrab = true;
            beingHeld = true;
            gameObject.layer = 6;
        }

        if (other.CompareTag("Clamp") && otherclamb.beingHeld)
        {
            clambmngr.AttachClamps();
        }
    }
}

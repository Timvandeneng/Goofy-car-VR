using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamb_Manager : MonoBehaviour
{

    [SerializeField] private GameObject leftClamb;
    [SerializeField] private GameObject rightClamb;
    [SerializeField] private GameObject middleClamb;

    private bool Attached;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Attached)
        {
            HandleClampMiddleWay();
        }
    }

    void HandleClampMiddleWay()
    {
        Vector3 position = (leftClamb.transform.position + rightClamb.transform.position) / 2;
        middleClamb.transform.position = position;

        middleClamb.SetActive(false);
    }

    public void DetachtClamps()
    {

    }

    public void AttachClamps()
    {
        Attached = true;
        middleClamb.SetActive(true);
        leftClamb.SetActive(false);
        rightClamb.SetActive(false);
    }
}

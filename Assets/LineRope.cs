using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRope : MonoBehaviour
{
    [SerializeField] private Transform FirstObject;
    [SerializeField] private Transform SecondObject;

    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();

        line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, FirstObject.position);
        line.SetPosition(1, SecondObject.position);
    }
}

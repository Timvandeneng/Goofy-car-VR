using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Button : MonoBehaviour
{

    [SerializeField] private Transform Model;
    [SerializeField] private Vector3 restingpos;
    [SerializeField] private Vector3 pushedpos;
    public bool toggled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggled)
        {
            Model.localPosition = pushedpos;
        }
        else
        {
            Model.localPosition = restingpos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rhand") || other.CompareTag("Lhand"))
        {
            toggled = !toggled;
        }
    }
}

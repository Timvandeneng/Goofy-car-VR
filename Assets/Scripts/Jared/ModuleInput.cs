using UnityEngine;

public class ModuleInput : MonoBehaviour
{
    public enum InputType
    {
        Digital,
        Analog
    }

    [HideInInspector] public InputType type;

    [HideInInspector] public bool moduleInputBoolean;
    [HideInInspector] public float moduleInputFloat;


    //private void Update()
    //{
    //    Debug.Log(moduleInputBoolean);
    //}
}

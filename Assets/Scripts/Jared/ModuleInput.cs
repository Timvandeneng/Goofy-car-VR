using UnityEngine;

public class ModuleInput : MonoBehaviour
{
    [HideInInspector]
    public bool completed;

    public enum InputType
    {
        Digital,
        Analog
    }

    // Variables that 'Module' needs to access
    public bool moduleInputBoolean;
    public float moduleInputFloat;
}

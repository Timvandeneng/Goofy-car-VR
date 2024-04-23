using UnityEngine;

public class ModuleInput : MonoBehaviour
{
    public KeyCode requiredKey;

    // Variables that 'Module' needs to access
    public bool moduleInputBoolean;
    public float moduleInputFloat;

    [HideInInspector]
    public bool completed;

    private void Update()
    {
        if (Input.GetKeyDown(requiredKey)) {
            completed = !completed;
        }
    }
}

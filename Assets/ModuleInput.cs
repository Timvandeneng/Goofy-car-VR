using UnityEngine;

public class ModuleInput : MonoBehaviour
{
    public KeyCode requiredKey;

    // Variables that 'Module' needs to access
    public bool moduleBoolean;
    public float moduleFloat;

    [HideInInspector]
    public bool completed;

    private void Update()
    {
        if (Input.GetKeyDown(requiredKey)) {
            completed = !completed;
        }
    }
}

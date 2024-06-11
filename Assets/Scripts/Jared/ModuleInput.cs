using Unity.VisualScripting;
using UnityEngine;

public class ModuleInput : MonoBehaviour {
    public enum InputType {
        Digital,
        Analog
    }

    [HideInInspector] public InputType type;

    [HideInInspector] public bool digitalValue;
    [HideInInspector] public float analogValue;

    [HideInInspector] public bool onToggle;

    //private void Update()
    //{
    //    Debug.Log($"from {transform.name}: digital value: {digitalValue}, analog value: {0}");
    //}
}
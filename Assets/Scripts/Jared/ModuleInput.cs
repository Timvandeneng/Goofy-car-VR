using UnityEngine;

public class ModuleInput : MonoBehaviour {
    public enum InputType {
        Digital,
        Analog
    }

    [HideInInspector] public InputType type;

    [HideInInspector] public bool digitalValue;
    [HideInInspector] public float analogValue;

    //private void Update()
    //{
    //    Debug.Log($"from {transform.name}: digital value: {digitalValue}, analog value: {analogValue}");
    //}
}
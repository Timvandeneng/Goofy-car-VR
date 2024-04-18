using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_Controls : MonoBehaviour
{
    [Header("Camera Physics")]
    [SerializeField] private float MouseSenseX = 1f;
    [SerializeField] private float MouseSenseY = 1f;
    [SerializeField] private float minYLook;
    [SerializeField] private float maxYLook;
    [SerializeField] private Camera cam;

    [Header("Booklet physics")]
    [SerializeField] private Transform booklet;
    [SerializeField] private float bookletShowSpeed;
    [SerializeField] private float cameraYBookletRot;
    [SerializeField] private float debugRotation;
    [SerializeField] private Vector3 bookletRestingPos;
    [SerializeField] private Vector3 bookletActivatedPos;
    private bool visibleBooklet = false;
    private Vector3 currentBookletPos;

    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleBooklet();
    }


    void HandleRotation()
    {
        mouseX += Input.GetAxis("Mouse X") * MouseSenseX;
        mouseY += Input.GetAxis("Mouse Y") * MouseSenseY;

        mouseY = Mathf.Clamp(mouseY, minYLook, maxYLook);
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-mouseY, mouseX, 0));
    }

    void HandleBooklet()
    {
        currentBookletPos = cam.transform.localRotation.eulerAngles.x > cameraYBookletRot && cam.transform.localRotation.eulerAngles.x < debugRotation ? bookletActivatedPos : bookletRestingPos;
        visibleBooklet = cam.transform.localRotation.eulerAngles.x > cameraYBookletRot && cam.transform.localRotation.eulerAngles.x < debugRotation ? true : false;

        booklet.localPosition = Vector3.Lerp(booklet.localPosition, currentBookletPos, bookletShowSpeed * Time.deltaTime);
    }
}

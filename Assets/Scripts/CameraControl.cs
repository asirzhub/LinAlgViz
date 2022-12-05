using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera cam;

    public float moveSpeed = 10f;
    public float lookSpeed = 2f;
    public float zoomSpeed = 2f;

    public float smoothScale;
    private float fov;

    public Vector3 targetPos;
    public Quaternion targetRot;

    public Vector2 mouseDelta;

    private void Start()
    {
        cam = GetComponent<Camera>();
        targetPos = transform.position;
        mouseDelta = new Vector2(-135, -30);
        fov = cam.fieldOfView;
    }

    private void Update()
    {
        if (Application.isFocused)
        {
            // efficiently manage position vector by multiplying everything in one line, float -> vector
            Vector3 forwards = Input.GetAxisRaw("Vertical") * transform.forward;
            Vector3 sideways = Input.GetAxisRaw("Horizontal") * transform.right;
            Vector3 upwards = Input.GetAxisRaw("Height") * transform.up;

            targetPos += Time.deltaTime * moveSpeed * (forwards + sideways + upwards);

            //rotation
            mouseDelta.x += lookSpeed * Input.GetAxis("Mouse X");
            mouseDelta.y += lookSpeed * Input.GetAxis("Mouse Y");

            //clamp rotation
            mouseDelta.y = Mathf.Clamp(mouseDelta.y, -90, 90);
            targetRot = Quaternion.Euler(-mouseDelta.y, mouseDelta.x, 0);
            Debug.Log(mouseDelta.x + " " + mouseDelta.y);

            // zoom control
            fov -= zoomSpeed * Input.GetAxisRaw("Mouse ScrollWheel");
            fov = Mathf.Clamp(fov, 10, 120);
        }
    }

    
    private void LateUpdate()
    {
        // changing theses values during LateUpdate() makes for a smoother viewer experience
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothScale);
        transform.localRotation = Quaternion.Lerp(transform.rotation, targetRot, smoothScale);
        cam.fieldOfView = fov;
    }
}

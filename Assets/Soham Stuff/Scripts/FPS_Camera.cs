using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Camera : MonoBehaviour
{
    [SerializeField] float mouseSense, xRotation;

    [SerializeField] GameObject player;

    [SerializeField] GameObject cam;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cam = GameObject.FindWithTag("MainCamera");

        player = GameObject.FindWithTag("Player");
    }

    void CameraControl()
    {
        float X_axis = Input.GetAxis("Mouse X") * mouseSense * 100f * Time.deltaTime;
        float Y_axis = Input.GetAxis("Mouse Y") * mouseSense * 100f * Time.deltaTime;

        xRotation -= Y_axis;
        xRotation = Mathf.Clamp(xRotation, -30f, 90f);

        player.transform.Rotate(Vector3.up, X_axis);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void Update()
    {
        CameraControl();
    }
}

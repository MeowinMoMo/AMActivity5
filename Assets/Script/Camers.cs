using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camers : MonoBehaviour
{
    [Header("Mouse Look Controls")]
    [SerializeField, Range(0.5f, 100f)] private float mouseSens = 25f;
    [SerializeField, Range(0.5f, 10f)] private float mouseSmooth = 2f;
    [SerializeField] public Transform PlayerOrientation;
    private float xRotate;
    private float yRotate;
    float mouseX;
    float mouseY;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        PlayerLookControl();
    }
    public void PlayerLookControl()
    {
        xRotate -= Input.GetAxis("Mouse Y") * mouseSmooth;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotate, 0, 0);
        PlayerOrientation.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * mouseSmooth, 0);
    }
}

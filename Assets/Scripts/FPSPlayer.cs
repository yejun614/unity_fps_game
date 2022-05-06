using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 5.0f;
    Vector3 prevMouePos = Vector3.zero;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Rotate();
        Movement();
    }

    void Rotate() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * rotateSpeed);
        playerCamera.transform.Rotate(Vector3.left, mouseY * rotateSpeed);
    }

    void Movement() {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
    }
}

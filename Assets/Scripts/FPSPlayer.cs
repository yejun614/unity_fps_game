using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayer : MonoBehaviour
{
    [SerializeField]
    private float groundRayDistance = 1f;
    private bool isGround = false;

    [SerializeField]
    private Camera playerCamera;

    [Header("Player Movement")]
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 5.0f;
    public float jumpForce = 5.0f;
    private float currentJumpHeight = 0;
    private bool isJump = false;
    private Rigidbody playerRigidbody;

    [Header("Audio Sources")]
    private AudioSource audioSource;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GroundCheck();

        Rotate();
        Jumping();
        Movement();
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * rotateSpeed);
        playerCamera.transform.Rotate(Vector3.left, mouseY * rotateSpeed);

        // Vertical rotation limit for Camera
        // When the Y and Z values of camera localEulerAngles are 180, camera is flipped vertically.
        Vector3 cameraAngles = playerCamera.transform.localEulerAngles;
        if (Mathf.Abs(cameraAngles.y - 180.0f) <= 0.1f && Mathf.Abs(cameraAngles.z - 180.0f) <= 0.1f) {
            cameraAngles.y = 0;
            cameraAngles.z = 0;

            // Change to normal angle
            playerCamera.transform.localEulerAngles = cameraAngles;
        }
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
    }

    void Jumping()
    {
        if (!isJump && isGround && Input.GetAxis("Jump") > 0)
        {
            isJump = true;
            playerRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }

    void GroundCheck()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, out var hit, groundRayDistance);
        isJump = false;
    }
}

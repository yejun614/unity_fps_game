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
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 5.0f;
    Vector2 prevMouePos = Vector2.zero;
    public float jumpSpeed = 5.0f;
    public float jumpHeight = 5.0f;
    private float currentJumpHeight = 0;
    private bool isJump = false;
    private Rigidbody playerRigidbody;

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

        if (!isJump) {
            Movement();
        }
    }

    void Rotate() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * rotateSpeed);
        playerCamera.transform.Rotate(Vector3.left, mouseY * rotateSpeed);
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
    }

    void Jumping()
    {
        if (isJump) {
            Vector3 velocity = Vector3.up * jumpSpeed * Time.deltaTime;

            transform.Translate(velocity);
            currentJumpHeight += velocity.y;

            if (currentJumpHeight >= jumpHeight) {
                currentJumpHeight = 0;
                isJump = false;
                playerRigidbody.isKinematic = false;
            }

        } else if (isGround && Input.GetAxis("Jump") == 1) {
            isJump = true;
            playerRigidbody.isKinematic = true;
        }
    }

    void GroundCheck()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, out var hit, groundRayDistance);
    }
}

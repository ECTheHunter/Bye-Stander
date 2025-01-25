using System;
using UnityEngine;
using DialogueEditor;

public class Player : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 2f;
    public float lookYlimit = 45f;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0f;
    public bool canMove = true;
    public CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.gameManager.player = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isrunning = Input.GetKey(KeyCode.LeftShift);
        float curspeedX = canMove && !ConversationManager.Instance.IsConversationActive ? (isrunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0f;
        float curspeedY = canMove && !ConversationManager.Instance.IsConversationActive ? (isrunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0f;
        float moveDirectionY = moveDirection.y;
        moveDirection = (forward * curspeedX) + (right * curspeedY);

        if (Input.GetKey(KeyCode.Space) && canMove && characterController.isGrounded && !ConversationManager.Instance.IsConversationActive)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = moveDirectionY;
        }
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection*Time.deltaTime);
        if(canMove){
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookYlimit, lookYlimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }
}

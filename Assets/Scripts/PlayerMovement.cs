using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CharController;

    public float walkSpeed;
    public float runSpeed;
    private Vector3 finalSpeed;

    public Transform cameraPoint;
    public float mouseSensitivity;
    public bool isInverted;

    public float gravityModifier;

    public bool canJump;
    public float JumpPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CameraRotation();
    }

    // THIS WILL HANDLE PLAYERS WALK,RUN AND JUMP
    void Movement()
    {
        var horizontalValue = transform.right * Input.GetAxis("Horizontal");
        var verticalValue =  transform.forward* Input.GetAxis("Vertical");

       
        //if (horizontalValue.magnitude == 0.0f && verticalValue.magnitude == 0.0f)
        //    return;


        finalSpeed = (horizontalValue + verticalValue) * walkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            finalSpeed = (horizontalValue + verticalValue) * runSpeed;
        }

        if (CharController.isGrounded)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }


        finalSpeed.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

        if (canJump && Input.GetKey(KeyCode.Space))
        {
            finalSpeed.y = JumpPower;
        }

        CharController.Move(finalSpeed * Time.deltaTime);


    }

     //FOR ROTATION
    void CameraRotation()
    {
        Vector2 mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        if (isInverted)
        {
            mouseDirection.x = -mouseDirection.x;
            mouseDirection.y = -mouseDirection.y;
        }

        this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 
            transform.rotation.eulerAngles.y + mouseDirection.x,
            transform.rotation.eulerAngles.z);

        cameraPoint.rotation = Quaternion.Euler(cameraPoint.rotation.eulerAngles 
            + new Vector3(-mouseDirection.y, 0f, 0f));



    }
}

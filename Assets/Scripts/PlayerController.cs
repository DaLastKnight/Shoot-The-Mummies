using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Camera playerCamera;
    private CharacterController playerControl;
    public Transform groundCheck;
    public PlayerData playerData;
    public LayerMask groundLayer;
    private float camVertAngle = 0;
    private float yVelocity;
    private bool playerGrounded;
    private bool isJumping = false;
    private bool isSprinting = false;
    public int maxJumps = 2;
    private int jumpNum = 0;
    public float cameraSensitivity = 0.75f;
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public int health;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerControl = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        MovePlayer();
        playerData.playerPos = transform.position;

        if (playerGrounded)
        {
            return;
        }


    }


    void OnTriggerEnter(UnityEngine.Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            health--;
            Debug.Log(health);
        }
    }

    void RotateCamera()
    {
        // Horizontal Camera controls
        transform.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X") * cameraSensitivity);

        // Vertical Camera controls
        camVertAngle += Input.GetAxisRaw("Mouse Y");
        camVertAngle = Mathf.Clamp(camVertAngle, -89f, 89f);
        playerCamera.transform.localEulerAngles = new Vector3(-camVertAngle, 0, 0);

        // Locks/Unlocks Cursor
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void MovePlayer()
    {
        Vector3 motionX = transform.right * Input.GetAxis("Horizontal");
        Vector3 motionY = transform.forward * Input.GetAxis("Vertical");
        Vector3 motion = motionX + motionY;
        Vector3 gravity = new Vector3(0, yVelocity, 0);


        playerControl.Move(((motion * moveSpeed) + gravity) * Time.deltaTime);

        if (motion.magnitude > 1)
        {
            motion.Normalize(); // Converts motion value to unit
        }

        if (Physics.Raycast(groundCheck.position, Vector3.down, 1.1f, groundLayer))
        {
            playerGrounded = true;
            jumpNum = 0;
            yVelocity = -0.01f;
        }
        else
        {
            yVelocity += -9.81f * Time.deltaTime;
        }


        // Limit of 2 Jumps. Reset number of jumps when on ground
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpNum < maxJumps)
            {
                playerGrounded = false;
                isJumping = true;
                jumpNum++;
            }


            if (isJumping)
            {
                yVelocity = Mathf.Sqrt(jumpHeight * -3.0f * -9.81f);
                isJumping = false;
            }
            
        }
        
        // Code for sprinting
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }

        if (isSprinting)
        {
            moveSpeed = 10f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 7f;
            isSprinting = false;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;
    public float downwardForce = 9.8f;
    private Rigidbody rgbd;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public bool isGrounded = false;
    public bool jump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        if(isGrounded && Input.GetKeyDown("space")){
            jump = true;
        }
        if(!isGrounded){
            rgbd.AddForce(Vector3.down * downwardForce,ForceMode.Acceleration);
        }
    }

    void FixedUpdate(){
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");     

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement) * moveSpeed;
        rgbd.velocity = new Vector3(movement.x, rgbd.velocity.y, movement.z);

       
         if(jump){
            rgbd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
         }
        
    }
}

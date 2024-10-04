using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 5.0f;
    private float moveSpeed; // this will be edited by the emotions so we can increase and decrease without having to add or take away movement speed
    public float jumpForce = 10.0f;
    public float downwardForce = 9.8f;
    private Rigidbody rgbd;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public bool isGrounded = false;
    public bool jump = false;

    public int health = 100;

    public Spells spells;

    public bool hasRelicOne = false;
    public bool hasRelicTwo = false;
    public bool hasRelicThree = false;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        moveSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        if (isGrounded && Input.GetKeyDown("space"))
        {
            jump = true;
        }
        if (!isGrounded)
        {
            rgbd.AddForce(Vector3.down * downwardForce, ForceMode.Acceleration);
        }
        // SpellBuffs();
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement) * moveSpeed;

        Vector3 moveDirection = (transform.forward * verticalMovement) + (transform.right * horizontalMovement);

        Vector3 movement = moveDirection.normalized * moveSpeed;
        rgbd.velocity = new Vector3(movement.x, rgbd.velocity.y, movement.z);



        if (jump)
        {
            rgbd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }

    }

    public void HasRelicOne()
    {
        hasRelicOne = true;
    }
    public bool CheckHasRelicOne()
    {
        return hasRelicOne;
    }
    public void HasRelicTwo()
    {
        hasRelicTwo = true;
    }
    public bool CheckHasRelicTwo()
    {
        return hasRelicTwo;
    }
    public void HasRelicThree()
    {
        hasRelicThree = true;
    }
    public bool CheckHasRelicThree()
    {
        return hasRelicThree;
    }

    /*public void SpellBuffs()
    {
        // state machine... :/
        Spells currentEmotion = spells.currentEmotion;

        switch (currentEmotion)
        {
            case Spells.Angry:
                //This one currently doesnt do anything to the player
                moveSpeed = baseSpeed;
                break;

            case Spells.Disgust:
                // Do we want to also slightly push the player backwards?
                moveSpeed = baseSpeed;
                break;

            case Spells.Fear:
                moveSpeed = baseSpeed * .5f;
                health -= 10;
                break;

            case Spells.Happy:
                moveSpeed = baseSpeed;
                health += 100;
                // flashlight, guess I can just set gameObject true for a light (probably real easy)
                break;

            case Spells.Sad:
                moveSpeed = baseSpeed * .8f;
                // I might have to implement the actual attack here as well...
                break;

            case Spells.Surprise:
                moveSpeed = baseSpeed * 1.5f;
                break;

            case Spells.Neutral:
                moveSpeed = baseSpeed;
                // is Neutral an emotion on the thingy?
                break;
        }
    }*/
}

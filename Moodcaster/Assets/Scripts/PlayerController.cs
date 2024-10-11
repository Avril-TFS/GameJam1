using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 10.0f;
    public float moveSpeed; // this will be edited by the emotions so we can increase and decrease without having to add or take away movement speed
    public float jumpForce = 10.0f;
    public float downwardForce = 9.8f;
    private Rigidbody rgbd;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public bool isGrounded = false;
    public bool jump = false;

    public float crouchSpeed = 5.0f;
    public bool isCrouched = false;
    public Camera playerCamera;
    private float playerCrouchCamera = 1.5f;
    private Vector3 playerCameraPosition;
    private CapsuleCollider playerCollider;
    private float colliderPosition;
    public float crouchColliderPosition = .2f;
    public int health = 100;

    public Spells spells;

    public bool hasRelicOne = false;
    public bool hasRelicTwo = false;
    public bool hasRelicThree = false;
    public GameObject firePrefab;
    public Transform fireBallCastPoint;

    public GameManager gameManager;
    public AudioSource audioSource;
    public AudioClip fireballSound;
    public AudioClip disgustSound;
    public AudioClip fearSound;
    public AudioClip sadSound;
    public AudioClip happySound;
    public AudioClip excitedSound;

    public enum Emotion { Anger, Disgust, Fear, Happy, Sad, Excited }
    public Emotion emotion;
    public enum SpellName { Iratus_Ignis, Impulsum, Noctis_Timor, Radiatus, Lacrimae, Celeritas }
    public SpellName spellName;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        moveSpeed = baseSpeed;

        playerCameraPosition = playerCamera.transform.localPosition;
        playerCollider = GetComponent<CapsuleCollider>();
        colliderPosition = playerCollider.height;

        gameManager = GameObject.FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
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

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
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

    public void Crouch()
    {
        if (isCrouched != true)
        {
            moveSpeed = crouchSpeed;
            isCrouched = true;

            playerCamera.transform.localPosition = new Vector3(playerCameraPosition.x, playerCameraPosition.y - playerCrouchCamera, playerCameraPosition.z);

            playerCollider.height = crouchColliderPosition;
            playerCollider.center = new Vector3(playerCollider.center.x, playerCollider.center.y - (colliderPosition - crouchColliderPosition) / 2, playerCollider.center.z);
        }
        else if (isCrouched != false)
        {
            moveSpeed = baseSpeed;
            isCrouched = false;

            playerCamera.transform.localPosition = playerCameraPosition;

            playerCollider.height = colliderPosition;
            playerCollider.center = new Vector3(playerCollider.center.x, playerCollider.center.y + (colliderPosition - crouchColliderPosition) / 2, playerCollider.center.z);
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
    public void Potion(int amount)
    {
        health += amount;

        health = Mathf.Clamp(health, 0, 100);
    }

    public void SlowDown()
    {
        moveSpeed = baseSpeed * .5f;
        Debug.Log("Speed = " + moveSpeed);
    }
    public void SpeedUp()
    {
        moveSpeed = baseSpeed * 1.5f;
        Debug.Log("Speed = " + moveSpeed);
    }
    public void BaseSpeed()
    {
        moveSpeed = baseSpeed;
        Debug.Log("Speed = " + moveSpeed);
    }
    public void Healing(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, 100);
        Debug.Log("Health = " + health);
    }
    public void Damage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, 100);
        Debug.Log("Health = " + health);

        if (health <= 0)
        {
            gameManager.GameOver();
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Exit"))
        {
            gameManager.Victory();
        }
    }
    public void FireBall()  // Anger spell
    {
        GameObject fireBall = Instantiate(firePrefab, fireBallCastPoint.position, fireBallCastPoint.rotation);
        Destroy(fireBall, 8.0f);

        audioSource.PlayOneShot(fireballSound);

        gameManager.AngerSpellText();
    }
    public void KnockBack(float radius, float kockBackForce) // Disgust Spell
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in cols)
        {
            Rigidbody otherRgbd = hit.GetComponent<Rigidbody>();

            if (otherRgbd != null && otherRgbd != rgbd)
            {
                Vector3 direction = (hit.transform.position - transform.position).normalized;

                otherRgbd.AddForce(direction * kockBackForce, ForceMode.Impulse);
            }
        }
        audioSource.PlayOneShot(disgustSound);
        gameManager.DisgustSpellText();
    }
    public void Splash(float radius, int damageAmount, float slowAmount, float slowTime) // sad SPell
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in cols)
        {
            EnemyController enemy = hit.GetComponent<EnemyController>();

            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);

                StartCoroutine(ApplySlow(enemy, slowAmount, slowTime));
            }
        }
        audioSource.PlayOneShot(sadSound);
        gameManager.SadSpellText();
    }
    public void FearSound()     // Fear Spell
    {
        audioSource.PlayOneShot(fearSound);
        gameManager.FearSpellText();

    }
    public void HappySoud() // Happy Spell
    {
        audioSource.PlayOneShot(happySound);
        gameManager.HappySpellText();
    }
    public void ExcitedSound()      // Excited Spell
    {
        audioSource.PlayOneShot(excitedSound);
        gameManager.ExcitedSpellText();
    }
    private IEnumerator ApplySlow(EnemyController enemy, float slowAmount, float duration)
    {
        float originalSpeed = enemy.moveSpeed;
        enemy.moveSpeed *= slowAmount;
        yield return new WaitForSeconds(duration);
        enemy.moveSpeed = originalSpeed;
    }
    public void EarthBolt()
    {
        // I want to add this spell
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

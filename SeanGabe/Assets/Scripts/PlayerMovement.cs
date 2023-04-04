using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bashSFX;
    private Vector2 movementDir;
    private Rigidbody2D rb;
    // private Health health;
    public AudioClip jumpSFX;

    #region -- // Speed Fields // --
    public float speed = 3;
    public float sprintSpeed;
    public float inAirSpeed;

    private bool isSprinting;
    private float currentSpeed;
    #endregion

    #region -- // Jump Fields // --
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float jumpForce = 3;
    public float bashForce = 3;
    public int maxJumps = 2;
    private int currentJumps = 0;
    public bool isBashing;
    private bool jumping;
    bool canBash;

    // New airControl field: a higher value 
    // results in more control in air.
    [Min(0)] public float airControl = 1;
    private bool isGrounded;
    #endregion


    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //health = GetComponent<Health>();
        currentSpeed = speed;
    }

    private void MoveCharacter(Vector2 dir)
    {
        Vector2 vel = dir * currentSpeed;
        vel.y = rb.velocity.y;

        // If the character is grounded, apply
        // the desired velocity.
        if (isGrounded)
        {
            rb.velocity = vel;
        }
        else
        {
            // vel = the direction the player wants to move,
            // So we Lerp between the current velocity and 
            // the desired velocity over time.
            if (vel != Vector2.zero)
            {
                rb.velocity = Vector2.Lerp(rb.velocity, vel, Time.deltaTime * airControl);
            }
        }

    }
    private IEnumerator CheckBash()
    {
        while (true)
        {
            Debug.Log("insideBash");
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StopAllCoroutines();
                StartCoroutine(PerformBash());
                audioSource.PlayOneShot(bashSFX);
            }

            yield return null;
        }
    }

    private IEnumerator PerformBash()
    {
        // health.canTakeDamage = false;
        print("Performing");
        isBashing = true;
        while (isBashing)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("doneBashing");
                Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                direction.z = 0;

                rb.velocity = Vector2.zero;
                rb.AddForce(direction.normalized * bashForce, ForceMode2D.Impulse);
                isBashing = false;
                yield return new WaitForSeconds(1f);

                //health.canTakeDamage = true;
            }

            yield return null;
        }
    }

    private void FixedUpdate()
    {
        // shoots linecast to check for ground

        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, whatIsGround);

        if (isGrounded && currentJumps > 0)

            currentJumps = 0;

            currentJumps = 2;


        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, whatIsGround);

        if (isGrounded && currentJumps > 0)

            currentJumps = 0;
            currentJumps = 1;


        if (jumping)
        {
            jumping = false;

            currentJumps++;
            Vector2 vel = rb.velocity;
            vel.y = 0;
            rb.velocity = vel;

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void Update()
    {
        // only activates if both on the ground and button is pressed
        if (Input.GetKeyDown(KeyCode.Space) && currentJumps < maxJumps)
        {
            jumping = true;
            //audioSource.PlayOneShot(jumpSFX);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetSprinting();
        }



        movementDir = new Vector2(Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        MoveCharacter(movementDir);
    }

    private void SetSprinting()
    {
        // toggles sprinting
        isSprinting = !isSprinting;
        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = speed;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BashableProjectile"))
        {
            SpriteRenderer rend = collision.GetComponentInParent<SpriteRenderer>();
            rend.color = Color.red;
            Debug.Log("Entering Trigger");
            StartCoroutine(CheckBash());
        }
        else if (collision.gameObject.CompareTag("Spawnpoint"))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BashableProjectile"))
        {
            SpriteRenderer rend = collision.GetComponentInParent<SpriteRenderer>();
            rend.color = Color.white;
            Debug.Log("Exiting trigger");
            StopAllCoroutines();
            // health.canTakeDamage = true;
        }
    }
}

    //private void OnTriggerEnter2D(Collider2D collision)
    //  {
    // if (collision.gameObject.CompareTag("BashableProjectile"))
    // {
    //  SpriteRenderer rend = collision.GetComponentInParent<SpriteRenderer>();
    //  rend.color = Color.red;
    //  Debug.Log("Entering Trigger");
    //  StartCoroutine(CheckBash());
    // }
    // else if (collision.gameObject.CompareTag("Spawnpoint"))
    // {

    // }
    // }
    //private void OnTriggerExit2D(Collider2D collision)
    // {
    //if (collision.gameObject.CompareTag("BashableProjectile"))
    // {
    //   SpriteRenderer rend = collision.GetComponentInParent<SpriteRenderer>();
    //   rend.color = Color.white;
    // Debug.Log("Exiting trigger");
    //  StopAllCoroutines();
    // health.canTakeDamage = true;
}
//  }
//}
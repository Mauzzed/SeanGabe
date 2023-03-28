using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float Movement_Speed;
    [SerializeField] private float Jump_Power;
    float Xdir;

    [SerializeField] private LayerMask LayerMask;
    private Collider2D Col;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Xdir = Input.GetAxis("Horizontal");
        if (Xdir > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Xdir < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
       // Jump();
    }
    void MoveAction(float dir)
    {
        rb.velocity = Vector2.right * dir * Movement_Speed * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        MoveAction(Xdir);
    }

  //  void Jump()
  //  {
     //   if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
       // {
           // rb.AddForce(transform.up * Jump_Power);
       // }
   // }
    bool isGrounded()
    {
        float ExtraHight = 0.0f;
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(Col.bounds.center, Col.bounds.size, 0f, Vector2.down, ExtraHight, LayerMask);
        return raycastHit2D.collider != null;
        {

        }
    }
}


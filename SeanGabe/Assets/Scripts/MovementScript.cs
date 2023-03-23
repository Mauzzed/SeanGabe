using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    float Xdir;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Xdir = Input.GetAxis("Horizontal");
    }
    void MoveAction(float dir)
    {
        rb.velocity = Vector2.right * dir * speed * Time.deltaTime;
        {
        private void FixedUpdate()
            {
                MoveAction(Xdir);
            }
    {
        
    }
}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashSCript : MonoBehaviour
{
    public float bashForce = 3;
    public bool isBashing;
    bool canBash;
    private Rigidbody2D rb;
    // private Health health;
    private IEnumerator CheckBash()
    {
        while (true)
        {
            Debug.Log("insideBash");
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StopAllCoroutines();
                StartCoroutine(PerformBash());
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
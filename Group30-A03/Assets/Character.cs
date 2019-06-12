using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    private Rigidbody2D playerRigidbody;
    private Collider2D playerCollider;
    private bool onGround;
    public float movespeed;
    public float jumpspeed;
    public float maxspeed;
    public GameObject ground;
    int groundID;
    private bool FacingRight = true;
    int combo = 0;
    private float lastClickedTime = 0;
    public float maxComboDelay = 1;
    public void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        groundID = ground.GetInstanceID();
        onGround = false;
    }
     

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playerRigidbody != null)
        {
            GetInput();
            Capvelocity();
            if(Input.GetButtonDown("Fire2") == true)
            {
                animator.SetTrigger("Attack");
            }
        }
        else
        {
            Debug.LogWarning("Rigidbody not attached to" + gameObject.name);
        }
    }

    public void Capvelocity()
    {
        float cappedXVelocity = Mathf.Min(Mathf.Abs(playerRigidbody.velocity.x), maxspeed)*Mathf.Sign(playerRigidbody.velocity.x);
        float cappedYVelocity = Mathf.Min(Mathf.Abs(playerRigidbody.velocity.y), maxspeed) * Mathf.Sign(playerRigidbody.velocity.y);
        playerRigidbody.velocity = new Vector2(cappedXVelocity, cappedYVelocity);
        animator.SetFloat("Speed", Mathf.Abs(playerRigidbody.velocity.x));
    }

    public void GetInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        float yForce = 0;
        float xForce = xInput * movespeed * Time.deltaTime;
        if (onGround == true && yInput > 0)
        {
            yForce = 200;
            animator.SetBool("On Ground", false);
        }

        Vector2 force = new Vector2(xForce, yForce);
        playerRigidbody.AddForce(force, ForceMode2D.Impulse);
        if (playerRigidbody.velocity.x > 0 && FacingRight == false)
        {
            Flip();
        } else if (playerRigidbody.velocity.x < 0 && FacingRight == true)
            {
                Flip();
            }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetInstanceID() == groundID)
        {
            onGround = false;
            Debug.Log("not on ground");
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetInstanceID() == groundID)
        {
            onGround = true;

            animator.SetBool("On Ground", true);
            Debug.Log("On ground");
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetInstanceID() == groundID)
        {
            onGround = true;

            animator.SetBool("On Ground", true);
            Debug.Log("On ground");
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

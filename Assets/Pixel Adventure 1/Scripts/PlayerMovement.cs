using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;

    [SerializeField] private AudioSource collectionSound;


    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private float DoubleJumpForce = 12f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    private int DJitem;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //if(IsGrounded() && !Input.GetButton("Jump"))
        //{
        //    DoubleJump = false;
        //}

        //if (Input.GetButtonDown("Jump"))
        //{
        //    if(IsGrounded() || DJitem>0)
        //    {
        //        jumpSoundEffect.Play();
        //        rb.velocity = new Vector2(rb.velocity.x, DJitem>0 ? DoubleJumpForce : jumpForce);

        //        //DoubleJump = !DoubleJump;
        //        DJitem--;
        //    }

        //}

        if (Input.GetButtonDown("Jump"))
        {
            if(IsGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                
                
            }
            else if (DJitem>0)
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, DoubleJumpForce);
                DJitem--;
            }
            
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DJ"))
        {
            //collectionSound.Play();
            Destroy(collision.gameObject);

            DJitem++;

        }

    }

    //public void TakingDamage()
    //{
    //    anim.SetBool("tknDmg", true);
    //}
}
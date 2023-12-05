using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyWaypoint : MonoBehaviour
{
    Rigidbody2D enemyRB;

    private SpriteRenderer sprite;

    [SerializeField] float enemyVelocity = 2f;

    private PlayerLife life;

    private Animator anim;



    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        life = FindObjectOfType<PlayerLife>();
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        enemyRB.velocity = new Vector2(enemyVelocity, .1f);
        sprite.flipX = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyVelocity = -enemyVelocity;
        FlipSprite();
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector2(-Mathf.Sign(enemyRB.velocity.x), 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.collider as BoxCollider2D)
            {
                Destroy(gameObject);
            }
            else
            {
                life.Die();
            }
        }
    }
}

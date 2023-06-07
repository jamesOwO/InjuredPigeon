using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject weapon, feather;
    private Rigidbody2D rb;
    public float moveSpeed, jumpforce;
    private float movehorizontal;
    private bool isjumping;
    public Animator animator;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;
    public float cooldowntime;
    private float nextfiretime;
    bool isGrounded = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

    }
    private void Update()
    {        


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(feather, weapon.transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        movehorizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(movehorizontal * moveSpeed, rb.velocity.y);

        if (movehorizontal > 0.1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            animator.SetBool("Moving", true);
        }
        else if (movehorizontal < -0.1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            animator.SetBool("Moving", true);
        }
        else 
        {
            animator.SetBool("Moving", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerGround")
        {
            isGrounded = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerGround")
        {
            isGrounded = false;
        }

    }
}

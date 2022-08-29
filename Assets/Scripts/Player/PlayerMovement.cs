using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpSpeed = 10f;

    [SerializeField] Bow bow;
    Vector2 moveInput;
    Rigidbody2D rb;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
    }
    void FlipSprite()
    {
        bool playerHasHorizonSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizonSpeed) transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
    }
    void OnFire(InputValue value)
    {
        Instantiate(bow.arrow, bow.gunPoint.position, bow.gunPoint.rotation);
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    void OnJump(InputValue value)
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        
        if (value.isPressed)
        {
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpForce = 5f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, 0f);
    }
    private void FixedUpdate()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed;

    bool isHit;
    Rigidbody2D rb;
    PlayerMovement player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        arrowSpeed *= Mathf.Sign(player.transform.localScale.x);
        Destroy(gameObject, 3f);

        //flight to the right
        rb.velocity = transform.right * arrowSpeed;
    }

    void Update()
    {
        //alway align with vector v
        if (isHit) return;
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isHit = true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}

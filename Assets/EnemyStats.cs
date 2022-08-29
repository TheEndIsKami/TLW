using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] float hp = 100;
    [SerializeField] Vector2 knockbackForce;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            hp -= 40;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);

            //add knockback
            rb.AddForce(knockbackForce * transform.localScale.x);
        }
    }
}

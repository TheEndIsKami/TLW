using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float arrowSpeed;
    Rigidbody2D rb;
    PlayerMovement player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        arrowSpeed *= Mathf.Sign(player.transform.localScale.x);
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        //flight to the right
        rb.velocity = Vector2.right * arrowSpeed;
    }

}

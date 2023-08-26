using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private ParticleSystem jumpEffect;

    private float groundCircleRadius = 0.2f;
    private float horizontal;

    private Rigidbody2D rb;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);     
    }
    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

       if(Input.GetButtonDown("Jump") && isGrounded()){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpEffect.Play();
        }
    }

    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, groundCircleRadius, groundLayer);
    }
}

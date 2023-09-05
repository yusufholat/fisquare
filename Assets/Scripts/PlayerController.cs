using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private ParticleSystem jumpEffectPrefab;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private float groundCircleRadius = 0.55f;
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
            Instantiate(jumpEffectPrefab, transform.position - new Vector3(0, playerSprite.bounds.size.y * 0.5f, 0), Quaternion.identity);
        }
    }

    private bool isGrounded(){
        return Physics2D.OverlapCircle(transform.position, groundCircleRadius, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, groundCircleRadius);
    }
}


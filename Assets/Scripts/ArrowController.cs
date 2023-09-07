using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float arrowSpeed;

    void FixedUpdate(){
        transform.Translate(transform.right * arrowSpeed * Time.deltaTime, Space.World);
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float arrowSpeed;
  
    [SerializeField] private LayerMask hitLayers;
    [SerializeField] private Transform frontPoint;
    [SerializeField] private float arrowRadius;

    private Collider2D hitColl;

    void FixedUpdate(){
        transform.Translate(transform.right * arrowSpeed * Time.deltaTime, Space.World);
        hitColl = Physics2D.OverlapCircle(frontPoint.position, arrowRadius, hitLayers);
        if(hitColl != null) Destroy(gameObject);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(frontPoint.position, arrowRadius);
    }
}

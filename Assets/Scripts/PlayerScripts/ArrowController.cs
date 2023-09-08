using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    
    [SerializeField] private Player mainPlayer;

    [SerializeField] private float arrowSpeed;
    [SerializeField] private float arrowRadius;
    [SerializeField] private Transform frontPoint;
    [SerializeField] private LayerMask hitLayers;
    [SerializeField] private GameObject destroyEffect;

    private Collider2D hitColl;

    private Bullet bullet;

    void Start(){
        bullet = new Bullet(mainPlayer.element, arrowSpeed);
    }

    void FixedUpdate(){
        transform.Translate(transform.right * bullet.bulletSpeed * Time.deltaTime, Space.World);
        hitColl = Physics2D.OverlapCircle(frontPoint.position, arrowRadius, hitLayers);
        if(hitColl != null && hitColl.CompareTag("Ground")) {
            Destroy(gameObject);
        }
        else if(hitColl != null && hitColl.CompareTag("Enemy")){
            if(hitColl.gameObject.GetComponent<EnemyController>().enemy.element ==
            bullet.bulletElement){
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(hitColl.gameObject);
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(frontPoint.position, arrowRadius);
    }
}

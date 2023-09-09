using System;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private Player mainPlayer;

    [SerializeField] private float arrowSpeed;
    [SerializeField] private float arrowRadius;
    [SerializeField] private Transform frontPoint;
    [SerializeField] private LayerMask hitLayers;

    private Collider2D hitColl;

    private Bullet bullet;

    void Start(){
        bullet = new Bullet(mainPlayer.element, arrowSpeed);
        GetComponent<SpriteRenderer>().color = mainPlayer.element.color;
    }

    void FixedUpdate(){
        transform.Translate(transform.right * bullet.bulletSpeed * Time.deltaTime, Space.World);
        hitColl = Physics2D.OverlapCircle(frontPoint.position, arrowRadius, hitLayers);
        if(hitColl != null && hitColl.CompareTag("Ground")) {
            Destroy(gameObject);
        }
        else if(hitColl != null && hitColl.CompareTag("Enemy")){
            Destroy(gameObject);
            EventManager.OnMatchCollision(bullet.bulletElement, hitColl.gameObject.transform.position);
            EventManager.OnEnemyScale(bullet.bulletElement, hitColl.gameObject.transform.position);
        }
    }
    
}

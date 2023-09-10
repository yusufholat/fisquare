using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    [SerializeField] private ElementGroup allElements;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float scaleMultiplier;

    private SpriteRenderer enemySprite;
    private Vector2 randomDirection;
    
    [SerializeField] private LayerMask hitGroundLayers;
    [SerializeField] private float enemyRadius;
    private Collider2D hitColl;
    
    [SerializeField] private GameObject destroyEffect;

    public static event Action OnScoreUpdate;

    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        enemy = new Enemy(allElements, enemySpeed);
        enemySprite.color = enemy.element.color;
        randomDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 0)).normalized;
        
        EventManager.MatchElementEvent += CompareElements;
    }
    
    void FixedUpdate(){
        hitColl = Physics2D.OverlapCircle(transform.position, enemyRadius, hitGroundLayers);
        if(hitColl != null && hitColl.CompareTag("Ground")){
            Destroy(gameObject);
        }
        transform.Translate(randomDirection * enemy.speed * Time.deltaTime);
    }

    private void CompareElements(ElementData data, Vector3 tform)
    {
        if(tform != transform.position) return; //check the true arrow-enemy match

        if(data.type == enemy.element.type){
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            OnScoreUpdate?.Invoke();
        }
        else EnemyScale();
    }
    
    private void EnemyScale()
    {
        transform.localScale *= scaleMultiplier;
        enemyRadius *= scaleMultiplier;
    }

    private void OnDestroy(){
        EventManager.MatchElementEvent -= CompareElements;
    }
}

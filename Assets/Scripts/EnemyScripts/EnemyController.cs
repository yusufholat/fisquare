using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private ElementGroup allElements;
    public Enemy enemy;
    [SerializeField] private float enemySpeed;

    private SpriteRenderer enemySprite;
    private Vector2 randomDirection;
    
    [SerializeField] private LayerMask hitLayers;
    [SerializeField] private float enemyRadius;
    private Collider2D hitColl;

    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        enemy = new Enemy(allElements, enemySpeed);
        enemySprite.color = enemy.element.color;
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 0)).normalized;
    }
    
    void FixedUpdate(){
        hitColl = Physics2D.OverlapCircle(transform.position, enemyRadius, hitLayers);
        if(hitColl != null){
            Destroy(gameObject);
        }
        transform.Translate(randomDirection * enemy.speed * Time.deltaTime);
    }


}

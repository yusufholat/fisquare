using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private ElementGroup allElements;
    [SerializeField] private Enemy enemy;

    private SpriteRenderer enemySprite;
    private Vector2 randomDirection;
    
    [SerializeField] private LayerMask hitLayers;
    [SerializeField] private float enemyRadius;
    private Collider2D hitColl;
    private bool canMove = true;

    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        enemy.element = (ElementData)allElements.elements.GetValue
            (Random.Range(0, allElements.elements.Length));
        enemySprite.color = enemy.element.color;
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 0)).normalized;
    }
    
    void FixedUpdate(){
        hitColl = Physics2D.OverlapCircle(transform.position, enemyRadius, hitLayers);
        if(hitColl != null) canMove = false;
        if(canMove) transform.Translate(randomDirection * enemy.speed * Time.deltaTime);
    }


}

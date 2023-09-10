using Unity.VisualScripting;
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

    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
        enemy = new Enemy(allElements, enemySpeed);
        enemySprite.color = enemy.element.color;
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 0)).normalized;
        
        EventManager.MatchElementEvent += CheckElement;
        EventManager.EnemyScale += CheckEnemyScale;
    }
    
    void FixedUpdate(){
        hitColl = Physics2D.OverlapCircle(transform.position, enemyRadius, hitGroundLayers);
        if(hitColl != null && hitColl.CompareTag("Ground")){
            Destroy(gameObject);
        }
        transform.Translate(randomDirection * enemy.speed * Time.deltaTime);
        

    }

    private void CheckElement(ElementData data, Vector3 tform)
    {
        if(data.type == enemy.element.type && tform == transform.position){
            Destroy(gameObject);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            UIManager.Instance.ScoreUpdate();
        }
    }
    
    private void CheckEnemyScale(ElementData data, Vector3 tform)
    {
        if(data.type != enemy.element.type && tform == transform.position){
            transform.localScale *= scaleMultiplier;
            enemyRadius *= scaleMultiplier;
        }
    }

    private void OnDestroy(){
        EventManager.MatchElementEvent -= CheckElement;
        EventManager.EnemyScale -= CheckEnemyScale;
    }
}

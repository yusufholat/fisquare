using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject pfEnemy;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy(){
        while(true){
            Instantiate(pfEnemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}

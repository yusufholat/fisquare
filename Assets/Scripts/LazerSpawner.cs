using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject lazer;
    [SerializeField] float spawnRate = 2.0f;
    private float timeSinceLastSpawn = 0f;
    
    void Update()
    {
        
    }
}

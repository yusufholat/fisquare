using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyHimself : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 1.0f;

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);

    }
}

using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<ElementData, Vector3> MatchElementEvent;
    public static event Action<ElementData, Vector3> EnemyScale;

    public static void OnMatchCollision(ElementData edata, Vector3 transform)
    {
        MatchElementEvent?.Invoke(edata, transform);
    }
    
    public static void OnEnemyScale(ElementData edata, Vector3 transform)
    {
        EnemyScale?.Invoke(edata, transform);
    }

}

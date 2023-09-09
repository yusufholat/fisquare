using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<ElementData> MatchElementEvent;
    public static event Action<ElementData> EnemyScale;

    public static void OnMatchCollision(ElementData edata)
    {
        MatchElementEvent?.Invoke(edata);
    }
    
    public static void OnEnemyScale(ElementData edata)
    {
        EnemyScale?.Invoke(edata);
    }

}

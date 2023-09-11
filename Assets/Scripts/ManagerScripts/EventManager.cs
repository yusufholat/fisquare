using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<ElementData, Vector3> MatchElementEvent;
    public static event Action OnTouchEnemy;
    public static event Action OnScoreUpdate;

    public static void MatchColorAndCollision(ElementData edata, Vector3 transform)
    {
        MatchElementEvent?.Invoke(edata, transform);
    }

    public static void TouchEnemy(){
        OnTouchEnemy?.Invoke();
    }

    public static void ScoreUpdate(){
        OnScoreUpdate?.Invoke();
    }

}

using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action<ElementData, Vector3> MatchElementEvent;
    public static event Action<ElementData, Vector3> EnemyScale;

    public static void MatchColorAndCollision(ElementData edata, Vector3 transform)
    {
        MatchElementEvent?.Invoke(edata, transform);
    }

}

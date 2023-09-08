using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScpObjects/Enemy")]
public class Enemy : ScriptableObject
{
    public float hp;
    public float speed;
    public ElementData element;
}

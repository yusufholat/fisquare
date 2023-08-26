using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float durability;
}

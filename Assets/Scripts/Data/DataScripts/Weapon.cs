using UnityEngine;

[CreateAssetMenu(menuName ="ScpObjects/Weapon")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public float damage;
    public Sprite weaponSprite;
    public GameObject pfBullet;
}

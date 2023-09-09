using UnityEngine;

[CreateAssetMenu(menuName ="ScpObjects/Player")]
public class Player : ScriptableObject
{
    public float hp;
    public Weapon weapon;
    public ElementData element;
}

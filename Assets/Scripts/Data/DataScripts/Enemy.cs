using UnityEngine;

public class Enemy
{
    public float speed {get; }
    public ElementData element {get; }

    public Enemy(ElementGroup _allElements, float _speed){
        speed = _speed;
        element = (ElementData)_allElements.elements.GetValue
            (Random.Range(0, _allElements.elements.Length));
    }
}

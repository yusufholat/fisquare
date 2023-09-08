
public class Bullet
{
    public float bulletSpeed{get; }
    public ElementData bulletElement{get; }

    public Bullet(ElementData element, float _speed){
        bulletElement = element;
        bulletSpeed = _speed;
    }
}

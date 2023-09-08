using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Player mainPlayer;

    private Vector3 mousePosition;
    private Vector3 aimDirection;
    private float rotationAngle;

    void Update()
    {
        HandleAiming();
        HandleShooting();
    }

    void HandleAiming(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        aimDirection =  (mousePosition - transform.position).normalized;
        rotationAngle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
    }

    void HandleShooting(){
        if(Input.GetMouseButtonDown(0)){
            Instantiate(mainPlayer.weapon.pfBullet, bulletSpawnPoint.position, Quaternion.Euler(0,0, rotationAngle));
        }
    }
}

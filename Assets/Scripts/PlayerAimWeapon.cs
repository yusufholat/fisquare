using System;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
  
    // public event EventHandler<OnMouseShootEventArgs> OnMouseShoot;
    
    // public class OnMouseShootEventArgs : EventArgs{
    //     public Vector3 shootPosition;
    //     public Vector3 aimDirection;
    // }

    
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject arrowPrefab;

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
            // OnMouseShoot?.Invoke(this, new OnMouseShootEventArgs{
            //     shootPosition = mousePosition,
            //     aimDirection = aimDirection
            // });
            Instantiate(arrowPrefab, bulletSpawnPoint.position, Quaternion.Euler(0,0, rotationAngle));
        }
    }
}

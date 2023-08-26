using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRotateControl : MonoBehaviour
{
    
    [SerializeField] private float rotationSpeed = 5f;
    
    private Quaternion targetRotation;
    private Quaternion initialRotation;
    [SerializeField] AnimationCurve rotationCurve;
    private bool isRotating = false;
    private bool lastTurnRight = true;
    
    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A) && !isRotating)
        {
            targetRotation = initialRotation * Quaternion.Euler(0, 0, 90);
            lastTurnRight = false;
            isRotating = true;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D) && !isRotating)
        {
            targetRotation = initialRotation * Quaternion.Euler(0, 0, -90);
            lastTurnRight = true;
            isRotating = true;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W) && !isRotating)
        {
            if(lastTurnRight) targetRotation = initialRotation * Quaternion.Euler(0, 0, 180);
            else targetRotation = initialRotation * Quaternion.Euler(0, 0, -180);
            isRotating = true;
        }
        if(isRotating){
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationCurve.Evaluate(rotationSpeed * Time.deltaTime));
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                initialRotation = targetRotation;
                isRotating = false;
            }
        }
    }
    private void FixedUpdate(){

    }
}
 
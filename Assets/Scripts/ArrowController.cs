using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private float arrowSpeed;

    void Start(){

    }

    void FixedUpdate(){
        transform.Translate(transform.right * arrowSpeed * Time.deltaTime, Space.World);
    }

}

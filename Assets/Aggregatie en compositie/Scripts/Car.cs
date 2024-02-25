using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float mass;
    
    [SerializeField] private WheelBase steeringWheelBase;

    [SerializeField] private Engine engine;

    private void Update()
    {
        //Steer car
        //Power engine
        //Apply Physics
    }
}

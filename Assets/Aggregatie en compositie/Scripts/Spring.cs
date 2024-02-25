using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float strength;
    [SerializeField] private float minCompression;
    [SerializeField] private float maxCompression;
    [SerializeField] private float restCompression;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    private void ApplyForces()
    {
        //add forces between point a and point b
    }
}

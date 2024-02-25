using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private StatDecorator powerUpType;
    
    public IStats PickUp()
    {
        return powerUpType;
    }
}

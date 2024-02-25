using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : IStats
{
    public float MovementSpeed()
    {
        return 5;
    }

    public float JumpForce()
    {
        return 10;
    }
}

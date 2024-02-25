using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderNPC : NPC
{
    [SerializeField] private int goldAmount;
    
    public override void Speak()
    {
        Debug.Log("I'M A TRADER AND I HAVE " + goldAmount + " GOLD!");
    }
}

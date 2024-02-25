using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public string npcName;
    public float health;

    public abstract void Speak();
}

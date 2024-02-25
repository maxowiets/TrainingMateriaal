using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyNPC : NPC
{
    [SerializeField] private EnemyType type;
    [SerializeField] private int cost;
    
    public int Cost => cost;
    public EnemyType Type => type;

    public override void Speak()
    {
        Debug.Log("I'M A " + System.Enum.GetName(typeof(EnemyType),type) + " ENEMY");
    }
}

public enum EnemyType
{
    GoblinGrunt = 0,
    SkeletonArcher,
    OrcWarrior,
    GiantSpider,
    DarkMage,
    Werewolf,
    OgreBrute,
    Banshee,
    LichKing,
    Dragon
}
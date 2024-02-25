using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCFactory
{
    public void CreateNpc(int totalNpcValue);
}

public enum NPCType
{
    Ally = 0,
    Enemy,
    Trader,
}
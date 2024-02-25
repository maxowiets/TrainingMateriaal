using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, INPCFactory
{
    [SerializeField] private List<EnemyNPC> enemyList = new List<EnemyNPC>();
    
    public void CreateNpc(int totalNpcValue)
    {
        var tempEnemyList = enemyList;
        var remainingValue = totalNpcValue;
        
        while (tempEnemyList.Count > 0)
        {
            //spawn enemy
            var randomEnemy = tempEnemyList[Random.Range(0, tempEnemyList.Count)];
            
            if (randomEnemy.Cost <= remainingValue) 
            {
                remainingValue -= randomEnemy.Cost;
                randomEnemy.Speak();
            }
            else
            {
                //reduce enemy list based on remaining value
                tempEnemyList = ReduceListByCost(tempEnemyList, remainingValue);
            }
        }
    }
    
    private List<EnemyNPC> ReduceListByCost(List<EnemyNPC> currentList, int remainingValue)
    {
        return currentList.Where(enemy => enemy.Cost <= remainingValue).ToList();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryGameManager : MonoBehaviour
{
    [SerializeField] private AllyFactory allyFactory;
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private TraderFactory traderFactory;

    private int _currentEnemyValue = 100;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyFactory.CreateNpc(_currentEnemyValue);
            _currentEnemyValue += 20;
        }
    }
}

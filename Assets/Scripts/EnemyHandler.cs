using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private Transform _enemyParent;
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>(50);

    private void Awake()
    {
        if (_enemyParent == null)
            _enemyParent = transform;

        Enemy[] enemies = _enemyParent.GetComponentsInChildren<Enemy>();
        
        foreach(Enemy enemy in enemies)
        {
            _enemies.Add(enemy);
        }
    }
}

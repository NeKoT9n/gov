using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    public override void Init()
    {
        _movement = new SimpleEnemyMovement(_agent, _speed);
        _atack = new SimpleEnemyAtack();
    }
}

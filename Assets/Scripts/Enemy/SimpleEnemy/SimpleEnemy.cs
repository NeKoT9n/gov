using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : Enemy
{
    public override void Init()
    {
        _movement = new SimpleEnemyMovement(_agent, _speed);
        _atack = new SimpleEnemyAtack();
    }
}

using UnityEngine;

public class RangeEnemy : Enemy
{
    [SerializeField] private Gun _currentGun;
    private IGun _gun => _currentGun;
    public override void Init()
    {
        _movement = new SimpleEnemyMovement(_agent, _speed);
        _atack = new RangeEnemyAtack(_gun);
    }
}

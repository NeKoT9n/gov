using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyAtack : IAtack
{
    private IGun _gun;

    public RangeEnemyAtack(IGun gun)
    {
        _gun = gun;
    }
    public void Atack()
    {
        _gun.Shoot();
    }
}

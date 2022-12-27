using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _parentBullet;
    
    private PoolMono<Bullet> _bullets;

    private void Start()
    {
        _bullets = new PoolMono<Bullet>(_bulletPrefab, _parentBullet, 6);
    }

    public void Create(Vector3 position)
    {
        var bullet = _bullets.GetFreeElement(position);
    }
}

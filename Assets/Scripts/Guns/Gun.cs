using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour, IGun
{
    [SerializeField] protected Transform _parentBullet;
    [SerializeField] protected Bullet _bulletPrefab;
    [SerializeField] protected Transform _firePoint;
    [SerializeField] protected float _timeBetweenFire = 0.2f;
    [SerializeField] protected float _bulletOffset;
    [field: SerializeField] public bool IsAutomatic { get; private set; } = true;

    protected PoolMono<Bullet> _bullets;


    protected float _timer;

    private void Start()
    {
        _bullets = new PoolMono<Bullet>(_bulletPrefab, _parentBullet, 10);
        _timer = 0;
    }

    private void Update()
    {
        if (_timer >= 0)
            _timer -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (_timer >= 0)
            return;

        var bullet = _bullets.GetFreeElement(_firePoint.position);
        Vector2 direction = _firePoint.right;
        Vector2 offset = new Vector2(direction.x + Random.Range(-_bulletOffset, _bulletOffset), direction.y + Random.Range(-_bulletOffset, _bulletOffset));
        bullet.Rigidbody.AddForce(offset.normalized * 20f, ForceMode2D.Impulse);

        _timer = _timeBetweenFire;
    }
}

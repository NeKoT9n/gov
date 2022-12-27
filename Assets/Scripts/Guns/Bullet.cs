using UnityEngine;

public class Bullet : MonoBehaviour
{
    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    [SerializeField] private float _damage;

    private readonly float _lifeTime = 1f;
    private float _timer;


    private void Update()
    {
        if (_timer <= 0)
        {
            Destroy();
        }
        else
        {
            _timer -= Time.deltaTime;
        }
     

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent(out IApplyDamage comp))
        {
            comp.ApplyDamage(_damage);
        }

        Destroy();
    }

    private void Destroy()
    {
        _timer = _lifeTime;
        gameObject.SetActive(false);
    }

}

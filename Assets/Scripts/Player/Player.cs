using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IMovement, IApplyDamage
{
    [SerializeField] private float _speed;
    [SerializeField] private float _hp;

    private float _currentHp;
    

    private IMovement _movement;
    private Rigidbody2D _rigidbody;
    

    private void Start()
    {
        _currentHp = _hp;
        _rigidbody = GetComponent<Rigidbody2D>();
        _movement = new PlayerMovement(_rigidbody, _speed);
    }

    public void Move(Vector2 target)
    {
        _movement.Move(target);
    }

    public void ApplyDamage(float damage)
    {
        _currentHp -= damage / 2;
        Debug.Log(_currentHp);
        if (_currentHp <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

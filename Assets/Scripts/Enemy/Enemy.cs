using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent),typeof(BoxCollider2D), typeof(Rigidbody2D))]
public abstract class Enemy : MonoBehaviour, IApplyDamage
{
    [SerializeField] private LayerMask _playerLayerMask;
    [SerializeField, Range(0, 50)] protected float _sightRange;
    [SerializeField, Range(0, 1000)] protected float _maxHp = 100;
    [SerializeField] protected float _speed;
    [SerializeField] float _atackDistance = 2f;

    protected NavMeshAgent _agent;
    protected Transform _target;

    protected IMovement _movement;
    protected IAtack _atack;

    protected float _currentHp;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentHp = _maxHp;
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.stoppingDistance = _atackDistance;

        Init();
    }

    virtual public void Init()
    {
        _movement = new SimpleEnemyMovement(_agent, _speed);
        _a
            tack = new SimpleEnemyAtack();
    }
    private void Update()
    {
        if (PlayerInSight() == true)
        {
            Vector2 lookDirection = (Vector2)_target.position - _rigidbody.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            _rigidbody.rotation = angle;

            float distance = Vector2.Distance(transform.position, _target.position);
            if (distance <= _atackDistance)
                _atack.Atack();

            _movement.Move(_target.position);
        }
    }

    private bool PlayerInSight()
    {
        var hit = Physics2D.OverlapCircle(transform.position, _sightRange, _playerLayerMask);

        if (_target == null)
            _target = hit != null ? hit.transform : null;
        
        return hit != null;
    }


    private void Die()
    {
        gameObject.SetActive(false);
        _currentHp = _maxHp;
    }

    public void ApplyDamage(float damage)
    {
        _currentHp -= damage;
        if (_currentHp <= 0)
            Die();
        Debug.Log(_currentHp);
    }
}

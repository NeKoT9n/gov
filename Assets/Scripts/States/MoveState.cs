using UnityEngine;
class MoveState : IState
{
    private IStateSwitcher _stateSwitcher;
    private Transform _target;
    private IMovement _movement;
    private float _stopDistance;
    private Transform _transform;

    public MoveState(IStateSwitcher switcher, IMovement movement,Transform transform,Transform target, float stopDistance)
    {
        _stateSwitcher = switcher;
        _target = target;
        _movement = movement;
        _stopDistance = stopDistance;
        _transform = transform;
    }
    public void Update()
    {
        _movement.Move(_target.position);
        float distanse = Mathf.Sqrt(Mathf.Pow(_transform.position.x - _target.position.x, 2) + Mathf.Pow(_transform.position.y - _target.position.y, 2));
        Debug.Log(distanse);
        if (_stopDistance <= distanse)
            _stateSwitcher.SwitchState<AtackState>();
    }
}


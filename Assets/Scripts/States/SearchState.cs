using UnityEngine;
class SearchState : IState
{
    private IStateSwitcher _stateSwitcher;
    private Transform _transform;
    private float _range;
    private LayerMask _playerMask;


    public SearchState(IStateSwitcher switcher, Transform transform, float range, LayerMask playerMask)
    {
        _stateSwitcher = switcher;
        _transform = transform;
        _range = range;
        _playerMask = playerMask;
    }


    public void Update()
    {
        if (PlayerInSight() == true)
        {
            _stateSwitcher.SwitchState<MoveState>();
        }
    }

    private bool PlayerInSight()
    {
        var hit = Physics2D.OverlapCircle(_transform.position, _range, _playerMask);

        return hit != null;
    }
}


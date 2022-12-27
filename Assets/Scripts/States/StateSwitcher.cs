using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateSwitcher : MonoBehaviour,IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    private void Start()
    {
        _states = new List<IState>();
    }

    public void Init(float range, LayerMask playerLayer, Transform target, IMovement movement, IAtack atack)
    {
        _states.Add(new SearchState(this, transform, range, playerLayer));
        _states.Add(new MoveState(this, movement,transform, target, 3));
        _states.Add(new AtackState(atack));
        SwitchState<SearchState>();
    }

    private void Update()
    {
        _currentState.Update();
    }

    public void SwitchState<T>() where T : IState
    {
        var state = _states.FirstOrDefault(s => s is T);
        _currentState = state;
    }
}

using UnityEngine;
class AtackState : IState
{
    private IAtack _atack;

    public AtackState(IAtack atack)
    {
        _atack = atack;
    }

    public void Update()
    {
        _atack.Atack();
    }
}


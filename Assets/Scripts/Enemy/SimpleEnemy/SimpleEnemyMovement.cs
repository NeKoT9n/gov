using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyMovement: IMovement
{
    private NavMeshAgent _agent;
    public SimpleEnemyMovement(NavMeshAgent agent, float speed)
    {
        _agent = agent;
        _agent.speed = speed;
    }
    
    void IMovement.Move(Vector2 target)
    {
        _agent.SetDestination(target);
    }
}

using UnityEngine.AI;
using UnityEngine;

public class Solder : HeroBase
{
    private NavMeshAgent agent;
    [Header("對方主堡")]
    public Transform target;
    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = data.speed;
    }
    protected override void Update()
    {
        base.Update();
        Move(target);
    }
    protected override void Move(Transform target)
    {
        agent.SetDestination(target.position);
    }
}

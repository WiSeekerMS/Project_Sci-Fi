using Assets.Scripts.Common;
using Assets.Scripts.Interfaces;
using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour, IInteractiveItem
{
    [SerializeField] private Enums.ItemType itemType;
    [SerializeField] private TriggerHandler triggerHandler;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distanceToTarget = 0.5f;
    
    private NavMeshAgent agent;
    public Action<Enemy> Destroyed;
    
    public Enums.ItemType GetItemType => itemType;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.speed = moveSpeed;
        GotoNextPoint();
    }

    private void OnDestroy()
    {
        Destroyed?.Invoke(this);
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < distanceToTarget)
            GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        if (!PatrolPoints.Instance) return;
        agent.destination = PatrolPoints.Instance.GetRandomPoint();
    }

    public void DestroyMy()
    {
        Destroy(gameObject);
    }
}

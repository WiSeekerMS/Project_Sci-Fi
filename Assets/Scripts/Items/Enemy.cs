using Assets.Scripts.Common;
using Assets.Scripts.Interfaces;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour, IInteractiveItem
{
    [SerializeField] private Enums.ItemType itemType;
    [SerializeField] private TriggerHandler triggerHandler;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distanceToTarget = 0.1f;
    private bool isTrigger;
    private NavMeshAgent agent;
    private Transform target;

    public Action<Enemy> CatchAction;
    public Action<Enemy> Destroyed;
    
    public Enums.ItemType GetItemType => itemType;

    private void Awake()
    {
        if (triggerHandler)
            triggerHandler.EnterEvent += OnTrigger;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.speed = moveSpeed;
        GoTo();
    }

    private void OnDestroy()
    {
        if (triggerHandler)
            triggerHandler.EnterEvent -= OnTrigger;

        Destroyed?.Invoke(this);
    }

    private void Update()
    {
        if (!isTrigger && !agent.pathPending && agent.remainingDistance < distanceToTarget)
        {
            GoTo();
        }
    }

    private Vector3 GetTargetPoint()
    {
        return isTrigger && target 
            ? target.position 
            : PatrolPoints.Instance.GetRandomPoint();
    }

    private void GoTo()
    {
        if (!PatrolPoints.Instance) return;
        agent.destination = GetTargetPoint();
    }

    private void OnTrigger(Collider other)
    {
        if (isTrigger) return;
        isTrigger = true;

        target = other.transform;
        StopAllCoroutines();
        StartCoroutine(FollowCor(0.7f));
    }

    private IEnumerator FollowCor(float distance)
    {
        while (Vector3.Distance(transform.position, target.position) > distance)
        {
            agent.SetDestination(target.position);
            yield return null;
        }

        CatchAction?.Invoke(this);
    }

    public void DestroyMy()
    {
        Destroy(gameObject);
    }
}

using System;
using UnityEngine;
using UnityEngine.AI;

public class PoliceCar : Vehicle
{
    [SerializeField] private int numberOfPatrolPoints = 5;
    [SerializeField] private float minX, maxX, minZ, maxZ;
    private Vector3[] patrolPoints;
    private int currentPatrolIndex = 0;
    private NavMeshAgent navMeshAgent;
    private bool isPersecuting;
    private Transform target;

    protected override void Start()
    {
        SetTypeOfVehicle("Police Car");
        SetPlate("CNP 001");
        SetSpeed(30.0f);
        base.Start();
        isPersecuting = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
        GeneratePatrolPoints();
    }

    private void Update()
    {
        if (!isPersecuting)
        {
            Patrol();
        }
        else
        {
            ChaseTarget();
        }
    }

    private void GeneratePatrolPoints()
    {
        patrolPoints = new Vector3[numberOfPatrolPoints];
        for (int i = 0; i < numberOfPatrolPoints; i++)
        {
            patrolPoints[i] = new Vector3(
                UnityEngine.Random.Range(minX, maxX),
                0, // Asumiendo que la y es siempre 0, ajusta si es necesario
                UnityEngine.Random.Range(minZ, maxZ)
            );
        }
    }

    private void Patrol()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            SetRandomPatrolDestination();
        }
    }
    private void SetRandomPatrolDestination()
    {
        if (patrolPoints.Length == 0) return;

        navMeshAgent.destination = patrolPoints[currentPatrolIndex];
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length; // Loop through patrol points
    }

    public void ChaseTarget()
    {
        if (target != null)
        {
            navMeshAgent.destination = target.position;
        }
    }

    public void StartPersecution(Transform crimeTarget)
    {
        target = crimeTarget;
        isPersecuting = true;
        navMeshAgent.speed = 40.0f; 
    }

    public void StopPersecution()
    {
        isPersecuting = false;
        navMeshAgent.speed = 50.0f; 
        SetRandomPatrolDestination(); 
    }

    public void OnSpeedingDetected(Transform speeder)
    {
        StartPersecution(speeder);
    }
}

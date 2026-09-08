using UnityEngine;
using UnityEngine.AI;

public enum MonsterState
{
    Patrolling,
    Chasing,
    Listening
}
public class MonsterMovement : MonoBehaviour
{
    public Transform[] waypoints;

    public float patrolWaitTime = 2.0f;
    public float stoppingDistance = 0.5f;
    public float losePlayerTime = 3.0f;

    MonsterSensor sensor;
    Transform playerTransform;
    NavMeshAgent agent;
    int currentPatrolIndex;
    bool isWaiting;
    float timeWaited;
    MonsterState state = MonsterState.Patrolling;
    float timeSinceLostPlayer;
    bool listeningForPlayer;
    Vector3 listeningSpot;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        sensor = GetComponent<MonsterSensor>();

        GoToNextWaypoint();
    }

    void Update()
    {
        if(sensor.foundPlayer != null)
            playerTransform = sensor.foundPlayer.transform;

        if (sensor.heardSpot != Vector3.zero)
            listeningSpot = sensor.heardSpot;


        if (isWaiting)
        {
            timeWaited += Time.deltaTime;
            WaitAtWaypoint();
        }

        switch (state)
        {
            case MonsterState.Patrolling:
                Patrol();

                if (sensor.foundPlayer != null)
                {
                    state = MonsterState.Chasing;
                }
                if (sensor.heardSpot != Vector3.zero && sensor.foundPlayer == null)
                    state = MonsterState.Listening;

                break;

            case MonsterState.Chasing:
                isWaiting = false;
                ChasePlayer();
                if(sensor.foundPlayer == null)
                {
                    timeSinceLostPlayer += Time.deltaTime;
                    if (timeSinceLostPlayer >= losePlayerTime)
                    {
                        state = MonsterState.Patrolling;
                        GoToClosestWaypoint();
                    }
                }
                else
                {
                    timeSinceLostPlayer = 0.0f;
                }

                break;

            case MonsterState.Listening:
                ListenForPlayer();

                if (sensor.foundPlayer != null)
                {
                    state = MonsterState.Chasing;
                }
                else if (sensor.heardSpot != Vector3.zero)
                    state = MonsterState.Listening;

                if(sensor.heardSpot == Vector3.zero && listeningForPlayer == false)
                {
                    state = MonsterState.Patrolling;
                    GoToClosestWaypoint();
                }

                break;
        }
    }

    void ChasePlayer()
    {
        agent.stoppingDistance = 0.0f;
        agent.SetDestination(playerTransform.position);
    }

    void Patrol()
    {
        agent.stoppingDistance = 0.0f;

        if (isWaiting)
            return;

        if(!agent.pathPending && agent.remainingDistance <= stoppingDistance)
        {
            isWaiting = true;
            timeWaited = 0.0f;
        }
    }

    void ListenForPlayer()
    {
        agent.stoppingDistance = sensor.closeDistance;
        listeningForPlayer = true;
        agent.SetDestination(listeningSpot);

        if (!agent.pathPending && agent.remainingDistance <= stoppingDistance + sensor.closeDistance && !isWaiting)
        {
            agent.stoppingDistance = 0.0f;
            isWaiting = true;
            timeWaited = 0.0f;
        }
    }

    void WaitAtWaypoint()
    {
        if(timeWaited >= patrolWaitTime)
        {
            listeningForPlayer = false;
            isWaiting = false;
            GoToNextWaypoint();
        }
    }

    void GoToClosestWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        int closestIndex = 0;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < waypoints.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, waypoints[i].position);
            if(distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        currentPatrolIndex = closestIndex;
        agent.SetDestination(waypoints[currentPatrolIndex].position);
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0)
            return;

        state = MonsterState.Patrolling;

        currentPatrolIndex = Random.Range(0, waypoints.Length);

        agent.SetDestination(waypoints[currentPatrolIndex].position);
    }
}

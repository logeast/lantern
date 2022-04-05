using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { GUAND, PATROL, CHASE, DEAD }
[RequireComponent(typeof(NavMeshAgent))]
public class LanternController : MonoBehaviour
{
    public EnemyStates enemyStates;
    private NavMeshAgent agent;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void SwitchStates()
    {
        switch (enemyStates)
        {
            case EnemyStates.GUAND:
                break;
            case EnemyStates.PATROL:
                break;
            case EnemyStates.CHASE:
                break;
            case EnemyStates.DEAD:
                break;
            default:
                break;
        }
    }
}

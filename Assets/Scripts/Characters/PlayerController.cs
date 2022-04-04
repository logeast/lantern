using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        MouseManager.Instance.OnMouseClicked += MoveToTaget;
    }

    /// <summary>
    /// Receive the mouse click position and move to the target
    /// </summary>
    /// <param name="target">Must same as the event target</param>
    public void MoveToTaget(Vector3 target)
    {
        agent.destination = target;
    }
}

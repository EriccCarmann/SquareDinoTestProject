using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Navigation : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform destination;
    private Transform lookDestination;
    private Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (destination != null)
        {
            agent.destination = destination.position;

            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {                 
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDestination.rotation, 0.2f);
                        animator.SetBool("isRunning", false);

                        if (lookDestination.tag == "Finish")
                        {
                            animator.SetBool("isRunning", true);
                            destination = lookDestination;
                        }
                    }
                }
            }
        }
    }

    public void AddNewDestination(Transform dest, Transform lookDest)
    {
        destination = dest;
        lookDestination = lookDest;
        animator.SetBool("isRunning", true);
    }
}

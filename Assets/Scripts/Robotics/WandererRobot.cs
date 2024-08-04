using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WandererRobot : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] float LengthLimit,WidthLimit;
    Vector3 newLocation;
    [SerializeField] float tolerance;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoSomewhere();
    }

    private void FixedUpdate()
    {
        if(agent.remainingDistance < tolerance)
        {
            GoSomewhere();
        }
    }

    void GoSomewhere()
    {
        newLocation = new Vector3(Random.Range(-LengthLimit, LengthLimit), 0, Random.Range(-WidthLimit, WidthLimit));
        agent.SetDestination(newLocation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Robot")
        {
            GoSomewhere();
        }
    }
}

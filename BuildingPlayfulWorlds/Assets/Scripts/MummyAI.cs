using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MummyAI : MonoBehaviour
{
    public GameObject Target;
    [SerializeField] GameObject Ragdoll;
    [SerializeField]float distance;

    NavMeshAgent agent;

    [SerializeField] Animator anim;


    public bool hasDied;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        distance = Vector3.Distance(transform.position, Target.transform.position); 

        agent.destination = Target.transform.position;

    }

   
}

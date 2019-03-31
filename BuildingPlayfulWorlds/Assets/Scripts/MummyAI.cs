using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MummyAI : MonoBehaviour
{
    /*
     Hoofd class van Mummy AI enemy, deze bestuurt de navmesh agent 
     en achtervolgt de speler vanaf een bepaalde range.
     */

    

    [Space]
    public GameObject Target;
    [SerializeField] GameObject Ragdoll;

    [Space]
    [SerializeField]float distance;

    [Space]
    [SerializeField] float FollowDistance;
    [SerializeField] float attackDistance;

    [Space]
    [SerializeField] Animator anim;

    [Space]
    [SerializeField] int attackDamage;

    [SerializeField] float attackTimer;
    [SerializeField] float attackDelay;

    [SerializeField] AudioClip[] AttackSounds;
    [SerializeField] AudioClip DieSound;

    NavMeshAgent agent;
    AudioSource source;

    public bool hasDied;
    bool isAttacking;

    public enum AI_States
    {
        Idle,
        Following,
        Attack
    }

    [SerializeField] AI_States currentState;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player");
        source = GetComponent<AudioSource>();

        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        anim.SetBool("isAttacking", isAttacking);

        distance = Vector3.Distance(transform.position, Target.transform.position);

        
        if(distance < attackDistance && currentState != AI_States.Attack)
        {
            currentState = AI_States.Attack;
        }

        if (distance < FollowDistance && distance > attackDistance && currentState != AI_States.Following)
        {
            currentState = AI_States.Following;
        }

        States();
    }

    void States()
    {
        if(currentState == AI_States.Following)
        {
            agent.destination = Target.transform.position;

        }

        if (currentState == AI_States.Attack)
        {
            Attack();
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    void Attack()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackDelay)
        {
            try
            {
                Target.GetComponent<iDamagable>().DoDamage(attackDamage);
            }
            catch
            {}

            source.PlayOneShot(AttackSounds[Random.Range(0, AttackSounds.Length)]);
            attackTimer = 0;
        }
    }


   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enamieControler : MonoBehaviour {

    public float lookReadias = 10f;
    public Transform target;
    public NavMeshAgent agent;
    public float stopingPoint = 1f ;
    private enamiesProperties enimeiesProb;
    private float nextTimeToHit = 0f;
    public float HitRate = 10f;
    private Animator An;
    public int distanceBetweenOneTowHandAttach = 2;
    private int counteAttachs = 0;
    private bool dead = false;

    // Use this for initialization
	void Start () {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        An = GetComponent<Animator>();
        enimeiesProb = GetComponent<enamiesProperties>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float distance = Vector3.Distance(target.position, transform.position);
        An.SetBool("AttackOneHand", false);
        An.SetBool("AttackTwoHand", false);
        An.SetBool("running", false);

        if (enimeiesProb.health <= 0f)
            dead = true;

        if (distance <= lookReadias && !dead)
        {
            agent.SetDestination(target.position);
            An.SetBool("running", true);
            if (distance <= stopingPoint && Time.time >= nextTimeToHit)
            {
                nextTimeToHit = Time.time + HitRate;
                //attack;
                if (counteAttachs <= distanceBetweenOneTowHandAttach)
                {
                    An.SetBool("AttackOneHand", true);
                    counteAttachs += 1;
                }
                else
                {
                    An.SetBool("AttackTwoHand", true);
                    counteAttachs = 0;
                }
                playerPropertice prob = target.GetComponent<playerPropertice>();
                prob.updatePlayerHelth(enimeiesProb.impact);
            }
        }
        else 
        {
            if (dead)
                An.SetBool("death", true);                
            else
                An.SetBool("running", false);            
        }
	}

    private void waitforsecond()
    {}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookReadias);
    }
}

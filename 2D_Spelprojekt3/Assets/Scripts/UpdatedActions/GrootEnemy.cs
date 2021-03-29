using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrootEnemy : MonoBehaviour
{
    [SerializeField]
    public List<EnemyAttackObject> Attacks;
    private List<EnemyAttackObject> AvailableAttacks;

    public float Health;
    public float MaxHP;

    public GameObject left;
    public GameObject right;
    public GameObject center;
    public GameObject recover;

    [HideInInspector]
    public bool canHit;

    private bool madeAHit;

    private int attackToInitiate;
    private Animator animator;
    private List<string> canTransitionTo = new List<string>();

    private EnemyAttackObject LastAttack;

    private void Awake() 
    {
        canHit = false;
        animator = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        AvailableAttacks = new List<EnemyAttackObject>(Attacks);
        StartCoroutine(InitiateAttack(AvailableAttacks));
    }
    private IEnumerator WhatToDoNext(float waitTime)
    {
        transform.position = recover.transform.position;
        animator.Play("EnemyIdle");
        canTransitionTo = LastAttack.canTransitionTo;
        AvailableAttacks.Clear();
        yield return new WaitForSeconds(waitTime);
        if (canTransitionTo.Count > 0)
        {
            for (int i = 0; i < Attacks.Count; i++)
            {
                for (int a = 0; a < canTransitionTo.Count; a++)
                {
                    if (Attacks[i].name == canTransitionTo[a])
                    {
                        AvailableAttacks.Add(Attacks[i]);
                    }
                }
            }
            StartCoroutine(InitiateAttack(AvailableAttacks));
        }
        else
        {
            AvailableAttacks = new List<EnemyAttackObject>(Attacks);
            AvailableAttacks.Remove(LastAttack);

            StartCoroutine(InitiateAttack(AvailableAttacks));
        }
        
    }

    private IEnumerator InitiateAttack(List<EnemyAttackObject> attackList)
    {
        attackToInitiate = Random.Range(0, attackList.Count);
        animator.Play(attackList[attackToInitiate].attackAnimation.name);
        LastAttack = attackList[attackToInitiate];
        WhereToMove(attackList[attackToInitiate].moveToSpace);
        yield return new WaitForSeconds(attackList[attackToInitiate].attackAnimation.length);

        StartCoroutine(WhatToDoNext(1));
    }

    void WhereToMove(MovementSpaces spaces)
    {
        switch (spaces)
        {
            default: 
                break;
            case MovementSpaces.Right:
                transform.position = right.transform.position;
                break;
            case MovementSpaces.Left:
                transform.position = left.transform.position;
                break;
            case MovementSpaces.Center:
                transform.position = center.transform.position;
                break;
        }
    }

    public bool CheckIfPlayerCanBeHit(MovementSpaces space)
    {
        foreach (var item in LastAttack.attackedSpaces)
        {
            if (space == item && madeAHit == false)
            {
                madeAHit = !madeAHit;
                return true;
            }
            else
            { return false;  }
            
        }
        return false;
    }

    public float ReturnDamage()
    {
        return LastAttack.attackDamage;
    }

    public void VulnerabilityActivate()
    {
        //Debug.Log("Definitely want to hit now");
    }

    public void VulnerabilityDeactivate()
    {
    }

    public void HitActivate()
    {
        madeAHit = false;
        canHit = true;
    }
    public void HitDeactivate()
    {
        canHit = false;
    }
}

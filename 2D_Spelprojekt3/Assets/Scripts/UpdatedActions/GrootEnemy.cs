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

    private int attackToInitiate;
    private Animator animator;
    private List<string> canTransitionTo = new List<string>();

    private EnemyAttackObject LastAttack;

    private void Awake() 
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        AvailableAttacks = new List<EnemyAttackObject>(Attacks);
        StartCoroutine(InitiateAttack(AvailableAttacks));
    }
    private IEnumerator WhatToDoNext(float waitTime)
    {
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

        yield return new WaitForSeconds(attackList[attackToInitiate].attackAnimation.length);

        StartCoroutine(WhatToDoNext(1));
    }

    void Update()
    {
        
    }

    public void VulnerabilityActivate()
    {
        //Debug.Log("Definitely want to hit now");
    }

    public void VulnerabilityDeactivate()
    {
        //Debug.Log("Can't hit now anymore too bad you monkey");
    }

    public void HitActivate()
    {
        //Debug.Log("You're gonna get hit REAL bad, buddy");
    }
    public void HitDeactivate()
    {
        //Debug.Log("Oh nooo...... PlsdonthitIdidntmeantostabormurderyouimeantnoharmplsrespondtothepleeofanevilmonsterasareasonablehumanbeing");
    }
}

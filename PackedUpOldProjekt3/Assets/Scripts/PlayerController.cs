using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject enemy;
    SmallEnemyAI nememy;

    // Idle Animation
    public GameObject IdleSprite;

    // Attack sprites
    public GameObject AttackReady;
    public GameObject AttackHit;
    public GameObject BlockSprite;

    public bool blocking = false;

    bool canAttack = true;


    // Health stuff
    public float health = 100;
    float maxHealth = 100;

    
    void Update()
    {
        nememy = enemy.GetComponent<SmallEnemyAI>();

        // Block when press button
        if (Input.GetKey(KeyCode.LeftShift))
        {
            BlockSprite.SetActive(true);
            blocking = true;
        } else
        {
            BlockSprite.SetActive(false);
            blocking = false;
        }

        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            StartCoroutine(Attack1());
        }
    }

    public IEnumerator Attack1()
    {
        if (canAttack)
        {
            canAttack = false;
            AttackReady.SetActive(true);
            IdleSprite.SetActive(false);
            yield return new WaitForSecondsRealtime(0.2f);
            AttackReady.SetActive(false);
            AttackHit.SetActive(true);
            if (nememy.canBeHit)
            {
                nememy.TakeDamage(12);
            }
            yield return new WaitForSecondsRealtime(0.5f);
            AttackHit.SetActive(false);
            IdleSprite.SetActive(true);
            canAttack = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallEnemyAI : MonoBehaviour
{
    PlayerController pC;
    [SerializeField] GameObject player;

    // Stats
    int damage = 12;
    int maxHealth = 100;
    int health = 100;

    // UI things
    public Slider HealthBar;

    // Idle Animation
    public GameObject IdleSprite;
    
    // Attack sprites
    public GameObject Attack1Ready;
    public GameObject Attack1Hit;
    public GameObject Attack2Ready;
    public GameObject Attack2Hit;

    public GameObject BlockSprite;

    // Stun/block variables
    int timesHit;
    public bool stunned;
    public bool canBeHit;
    public bool gotHit;
    public bool staggered;

    public float sTimer;
    
    void Awake()
    {
        // Randomised stats?

        Attack1Ready.SetActive(false);
        Attack1Hit.SetActive(false);
        Attack();
    }

    void Update()
    {
        HealthBar.maxValue = maxHealth;
        HealthBar.value = health;
        if (Input.GetKey(KeyCode.E))
        {
            health -= 1;
        }

        if (staggered)
        {
            canBeHit = true;
            sTimer -= Time.deltaTime;
            if (timesHit >= 3 || sTimer >= 2)
            {
                canBeHit = false;
                staggered = false;
                timesHit = 0;
            }
        }
    }

    void Attack()
    {
        int tempCount = 1; //Random.Range(1, 2);
        if (tempCount == 1) { StartCoroutine(Attack1()); }
        if (tempCount == 2) { StartCoroutine(Attack2()); }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2);
        Attack();
    }

    public IEnumerator Attack1()
    {
        Attack1Ready.SetActive(true);
        IdleSprite.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        Attack1Ready.SetActive(false);
        Attack1Hit.SetActive(true);
        if (pC.blocking)
        {
            Attack1Hit.SetActive(false);
            IdleSprite.SetActive(true);
            canBeHit = true;
            yield return new WaitForSecondsRealtime(0.3f);
            if (gotHit)
            {
                staggered = true;
                gotHit = false;
                yield break;

            }
            canBeHit = false;
            yield return new WaitForSecondsRealtime(0.7f);
        } else
        {
            pC.health -= damage;
            Attack1Hit.SetActive(false);
            IdleSprite.SetActive(true);
            StartCoroutine(Wait());
        }
        
        
    }

    public IEnumerator Attack2()
    {
        Attack2Ready.SetActive(true);
        IdleSprite.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        Attack2Ready.SetActive(false);
        Attack2Hit.SetActive(true);
        // If player is not dodging, deal damage
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        gotHit = true;
        timesHit += 1;
    }
}

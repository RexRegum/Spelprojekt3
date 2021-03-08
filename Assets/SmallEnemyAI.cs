using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyAI : MonoBehaviour
{
    // Stats
    int damage;
    int maxHealth;
    int health;

    // Idle Animation
    public GameObject IdleSprite;
    
    // Attack sprites
    public GameObject Attack1Ready;
    public GameObject Attack1Hit;
    public GameObject Attack2Ready;
    public GameObject Attack2Hit;

    public GameObject BlockSprite;

    void Awake()
    {
        // Randomised stats?
    }

    void Attack()
    {
        int tempCount = Random.Range(1, 2);
        if (tempCount == 1) { StartCoroutine(Attack1()); }
        if (tempCount == 2) { StartCoroutine(Attack2()); }
    }

    public IEnumerator Attack1()
    {
        Attack1Ready.SetActive(true);
        IdleSprite.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        Attack1Ready.SetActive(false);
        Attack1Hit.SetActive(true);
        // If player is not blocking, deal damage
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
}

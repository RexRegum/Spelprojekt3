using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallEnemyAI : MonoBehaviour
{
    // Stats
    int damage = 10;
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
        // If player is not blocking, deal damage
        yield return new WaitForSecondsRealtime(0.5f);
        Attack1Hit.SetActive(false);
        IdleSprite.SetActive(true);
        StartCoroutine(Wait());
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

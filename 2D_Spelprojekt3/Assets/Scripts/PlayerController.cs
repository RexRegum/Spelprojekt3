using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Idle Animation
    public GameObject IdleSprite;

    // Attack sprites
    public GameObject AttackReady;
    public GameObject AttackHit;
    public GameObject BlockSprite;

    public bool blocking = false;

    // Health stuff
    public float health = 100;
    float maxHealth = 100;

    void Update()
    {
        // Block when press button
        if (Input.GetKey(KeyCode.LeftShift))
        {
            blocking = true;
        } else
        {
            blocking = false;
        }
    }

    public IEnumerator Attack1()
    {
        AttackReady.SetActive(true);
        IdleSprite.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        AttackReady.SetActive(false);
        AttackHit.SetActive(true);
        // If enemy is not blocking, deal damage (epicly)
        yield return new WaitForSecondsRealtime(0.5f);
        AttackHit.SetActive(false);
        IdleSprite.SetActive(true);
    }
}

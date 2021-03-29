using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerBehaviour player;
    public GrootEnemy enemy;

    public Image enemyHealth;
    public Image playerHealth;

    private bool gotHit;

    // Start is called before the first frame update
    void Awake ()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyHealth.fillAmount = Mathf.Clamp(enemy.Health / enemy.MaxHP, 0f, 1f);
        playerHealth.fillAmount = Mathf.Clamp(player.Health / player.MaxHP, 0f, 1f);

        if (enemy.canHit)
        {
            if (enemy.CheckIfPlayerCanBeHit(player.currentSpace))
            {
                player.Health -= enemy.ReturnDamage();
            }
        }
    }
}

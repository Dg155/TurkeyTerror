using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] [Range(0, 100)] private int maxHealth = 100;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void SubtractHealth()
    {
        health -= 25;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    public void AddHealth()
    {
        health += 25;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Die()
    {
        StartCoroutine(playerMovement.lose());
    }


    /** GOOD EXAMPLES OF DESIGNER FRIENDLY FUNCTIONS **/

    public int GetHealth()
    {
        return health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetHealth(int amount)
    {
        health = amount;
    }

    public void SetMaxHealth(int amount)
    {
        maxHealth = amount;
    }

}

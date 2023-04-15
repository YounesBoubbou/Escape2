using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        //Play hurt animation
        animator.SetTrigger("Hurt");
        //subtract damage from health
        currentHealth -= damage;
        //if health is less than or equal to 0, die
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //Play death animation
        animator.SetBool("IsDead", true);
        //Disable enemy
        this.enabled = false;
        
    }

    
}

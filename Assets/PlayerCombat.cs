using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Attack();
        }
        
        
    }
    void Attack()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");


    }

    void onAttackHit()
    {
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    
 
    void OnDrawGizmosSelected()
    {
            if(attackPoint == null)
            {
                return;
            }
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

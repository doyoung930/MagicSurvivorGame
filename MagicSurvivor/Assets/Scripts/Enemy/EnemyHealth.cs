using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hp = 100f;
    
    private bool isDead = false;
    
    
    public bool IsDead () { return isDead; }
    
    public void TakeDamage(float damage)
    {
        hp -= damage;
        
        if (hp <= 0){
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        Destroy(this.gameObject);
        //GetComponent<Animator>().SetTrigger("die");
        
        
    }
    
    
}

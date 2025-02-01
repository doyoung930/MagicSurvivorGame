using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickup : MonoBehaviour
{
    [SerializeField] private int increaseExp = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            
            PlayerExpSystem playerExpSystem = FindObjectOfType<PlayerExpSystem>();

            if (playerExpSystem != null)
            {
                playerExpSystem.IncreaseExp(increaseExp);
            }
            
        }
    }
    
}

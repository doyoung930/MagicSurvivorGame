using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawn : MonoBehaviour
{
    public GameObject shieldPrefab;
    private int shieldLevel = 1;
    
    void Start()
    {
        Fire();
    }

    void Fire()
    {
        Vector3 spawnPosition = transform.position + new Vector3(5f, 0, 0); 
        GameObject shield = Instantiate(shieldPrefab, spawnPosition, Quaternion.identity);
        
    }
    
    public void LevelUp()
    {
        shieldLevel++;
        Debug.Log(shieldLevel);
        ShieldMove shieldMove = FindObjectOfType<ShieldMove>();
        shieldMove.IncreaseDamage();
    }
    
}

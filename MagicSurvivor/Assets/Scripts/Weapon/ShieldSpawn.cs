using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawn : MonoBehaviour
{
    public GameObject shieldPrefab;
    [SerializeField] private int shieldLevel = 1;

    void Start()
    {
        Fire();
    }

    void Fire()
    {
        Vector3 spawnPosition = transform.position + new Vector3(5f, 0, 0); 
        
        
        
        
        GameObject shield = Instantiate(shieldPrefab, spawnPosition, Quaternion.identity);
        //shield.transform.parent = this.transform;
        //spear.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawn : MonoBehaviour
{
    public GameObject shieldPrefab;
    [SerializeField] private int shieldLevel = 1;
    [SerializeField] private int fireInterval = 1;

    void Start()
    {
        Fire();
    }

    void Fire()
    {
        Vector3 spawnPosition = transform.position + new Vector3(3, 0, 0); 
        
        
        
        
        GameObject spear = Instantiate(shieldPrefab, spawnPosition, Quaternion.identity);
        //spear.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        
    }
    
}

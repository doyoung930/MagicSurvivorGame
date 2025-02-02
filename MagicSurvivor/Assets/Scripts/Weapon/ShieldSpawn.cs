using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawn : MonoBehaviour
{
    public GameObject shieldPrefab;
    private int shieldLevel = 1;
    private float damageLevel = 1;
    private float speedLevel = 1;
    private float distanceLevel = 1;
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
        speedLevel++;
        damageLevel++;
        distanceLevel++;
    }

    public void SpeedLevelUp()
    {
        shieldLevel++;
    }

    public void DamageLevelUp()
    {
        damageLevel++;
    }
    
}

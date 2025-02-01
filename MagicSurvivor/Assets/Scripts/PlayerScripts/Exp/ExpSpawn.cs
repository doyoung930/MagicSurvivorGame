using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawn : MonoBehaviour
{
    public GameObject expPrefab; // 소환할 적 프리팹
    
    
    public void SpawnExp(Vector3 spawnPosition)
    {
        // 적 소환 및 부모 설정
        GameObject exp = Instantiate(expPrefab, spawnPosition, Quaternion.identity);
        exp.transform.parent = this.transform;
    }
}

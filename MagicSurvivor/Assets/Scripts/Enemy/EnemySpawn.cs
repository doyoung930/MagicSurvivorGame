using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
        public GameObject enemyPrefab; // 소환할 적 프리팹
        public float spawnInterval = 1f; // 소환 간격
        public Vector3 spawnRange; // 소환 범위
    
        private void Start()
        {
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
        }
    
        void SpawnEnemy()
        {
            // 랜덤한 위치 생성
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnRange.x, spawnRange.x),
                1,
                Random.Range(-spawnRange.z, spawnRange.z)
            );
    
            // 적 소환
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        
        
}

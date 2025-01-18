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
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnRange.x, spawnRange.x),
                1,
                Random.Range(-spawnRange.z, spawnRange.z)
            );

            // 적 소환 및 부모 설정
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.transform.parent = this.transform; // EnemySpawn 스크립트가 부착된 오브젝트의 자식으로 설정
        }
        
        
}

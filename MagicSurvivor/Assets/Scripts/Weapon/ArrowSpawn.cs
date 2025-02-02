using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    private int arrowLevel = 1; // arrow Level
    private int damageLevel = 0;
    private int speedLevel = 0;
    
    private float fireInterval = 1f;
    
    private float decreaseFireInterval = 0.1f;

    [SerializeField] private float range = 10f;
    
    private Transform enemy;
    private float distanceToEnemy = Mathf.Infinity;
    private float fireTimer;
    
    void Start()
    {
        fireTimer = fireInterval; // 타이머 초기화
    }       

    void Update()
    {
        // 적을 찾기
        FindEnemy();

        if (enemy)
        {
            distanceToEnemy = Vector3.Distance(transform.position, enemy.position);
            if (distanceToEnemy <= range)
            {
                fireTimer -= Time.deltaTime; // 타이머 감소
                if (fireTimer <= 0f)
                {
                    Fire(); // 화살 발사
                    fireTimer = fireInterval; // 타이머 리셋
                }
            }
            else
            {
                fireTimer = fireInterval; // 범위를 벗어나면 타이머 리셋
            }
        }
    }

    void FindEnemy()
    {
        // "Enemy" 태그를 가진 적을 찾기
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            // 가장 가까운 적을 선택
            enemy = enemies[0].transform;
            float closestDistance = Vector3.Distance(transform.position, enemy.position);

            for (int i = 1; i < enemies.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, enemies[i].transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    enemy = enemies[i].transform;
                }
            }
        }
        else
        {
            enemy = null; // 적이 없으면 null
        }
    }

    void Fire()
    {
        // 타깃이 있을 때만 생성 및 발사
        Vector3 spawnPosition = transform.position; 
        Vector3 direction = (enemy.position - spawnPosition).normalized;
        
        GameObject arrow = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);
        arrow.transform.forward = direction; 
        
        ArrowMove arrowMove = arrow.GetComponent<ArrowMove>();
        if (arrowMove != null)
        {
            arrowMove.SetDamage(arrowMove.GetCurrentDamage() + (damageLevel * 5f));
            arrowMove.SetSpeed(arrowMove.GetCurrentSpeed() + (speedLevel * 5f));
        }
    }
    
    public void DecreaseFireInterval()
    {
        fireInterval -= decreaseFireInterval;
        
        CancelInvoke("Fire");
        InvokeRepeating("Fire", fireInterval, fireInterval);
    }

    public void LevelUp()
    {
        arrowLevel++;
        damageLevel++;
        speedLevel++;
        DecreaseFireInterval();
    }

    public void DamageLevelUp()
    {
        damageLevel++;
    }

    public void SpeedLevelUp()
    {
        speedLevel++;
    }

    public int GetArrowLevel()
    {
        return arrowLevel;
    }
}

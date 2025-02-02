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
    
    private List<GameObject> shields = new List<GameObject>(); // 방패 목록
    void Start()
    {
        Fire();
    }

    void Fire()
    {
        // 기존 방패 삭제
        foreach (GameObject shield in shields)
        {
            Destroy(shield);
        }
        shields.Clear(); // 목록 초기화

        // 새 방패 생성
        CreateShields(shieldLevel);
        
    }
    void CreateShields(int numberOfShields)
    {
        float angleStep = 360f / numberOfShields; // 각도 간격 계산

        for (int i = 0; i < numberOfShields; i++)
        {
            float initialAngle = i * angleStep; // 각도 계산
            Vector3 spawnPosition = transform.position + Quaternion.Euler(0, initialAngle, 0) * new Vector3(5f, 0, 0); // 원형 위치 계산
            GameObject shield = Instantiate(shieldPrefab, spawnPosition, Quaternion.identity);
            ShieldMove shieldMove = shield.GetComponent<ShieldMove>();
            if (shieldMove != null)
            {
                shieldMove.SetDamage(shieldMove.GetCurrentDamage() + (damageLevel * 5f));
                shieldMove.SetSpeed(shieldMove.GetCurrentSpeed() + (speedLevel * 10f));
                shieldMove.Initialize(initialAngle); // 초기 각도 설정
            }
            shields.Add(shield); // 생성한 방패를 목록에 추가
        }
    }
    
    public void LevelUp()
    {
        shieldLevel++;
        speedLevel++;
        damageLevel++;
        distanceLevel++;
        Fire();
    }

    public void SpeedLevelUp()
    {
        speedLevel++;
    }

    public void DamageLevelUp()
    {
        damageLevel++;
    }

    public int GetShieldLevel()
    {
        return shieldLevel;
    }
}

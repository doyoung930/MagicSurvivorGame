using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMove : MonoBehaviour
{
    private float rotationSpeed = 300f; 
    private float distanceFromPlayer = 5f;
    private float damage = 100f; 
    public Transform player;

    private float currentAngle; // 현재 각도

    public void Initialize(float initialAngle)
    {
        currentAngle = initialAngle; // 초기 각도 설정
    }

    void Start()
    {
        player = GameObject.Find("PlayerCapsule").transform;
    }

    void Update()
    {
        // 방패의 각도를 업데이트
        currentAngle += rotationSpeed * Time.deltaTime; // Time.deltaTime 사용

        // 각도를 라디안으로 변환
        float radians = currentAngle * Mathf.Deg2Rad;

        // 새로운 위치 계산
        float x = Mathf.Cos(radians) * distanceFromPlayer;
        float z = Mathf.Sin(radians) * distanceFromPlayer;

        // 방패의 위치 설정
        transform.position = new Vector3(player.position.x + x, player.position.y, player.position.z + z);

        // 방패가 항상 플레이어를 바라보도록 회전
        transform.LookAt(player.position);
    }

    void OnTriggerEnter(Collider other)
    {
        Hit(other);
    }

    void Hit(Collider other)
    {
        if (other == null) return;

        EnemyHealth target = other.GetComponent<EnemyHealth>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }

    public float GetCurrentSpeed()
    {
        return rotationSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        rotationSpeed = newSpeed;
    }

    public float GetCurrentDamage()
    {
        return damage;
    }

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }
}